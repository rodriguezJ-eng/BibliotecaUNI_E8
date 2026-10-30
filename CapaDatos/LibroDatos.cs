using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;                 // UpdateException (ObjectContext.SaveChanges)
using System.Data.SqlClient;
using System.Linq;
using Entidades;
using LibroEntidad = Entidades.Libro;
using LibroModelo = CapaDatos.Libro;
using AutorEntidad = Entidades.Autor;

namespace CapaDatos
{
    /// <summary>
    /// Capa de datos de Libro con Entity Framework 6.
    ///
    /// La tabla Libro se administra con el modelo EDMX. La relación con Autor
    /// se guarda en la tabla intermedia LibroAutor y la categoría se resuelve
    /// contra la tabla Categoria; ambas se manejan con BibliotecaContexto.
    /// </summary>
    public class LibroDatos
    {
        // ---------------------------------------------------------------
        // R - Consultar / Buscar
        // ---------------------------------------------------------------

        public List<LibroEntidad> ConsultarTodos()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<LibroModelo> libros = contexto.CreateObjectSet<LibroModelo>()
                    .AsNoTracking()
                    .OrderBy(l => l.Titulo)
                    .ToList();

                return CompletarDatos(libros);
            }
        }

        public LibroEntidad Buscar(int idLibro)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                LibroModelo libro = contexto.CreateObjectSet<LibroModelo>()
                    .AsNoTracking()
                    .FirstOrDefault(l => l.IDLibro == idLibro);

                if (libro == null)
                    return null;

                return CompletarDatos(new List<LibroModelo> { libro }).FirstOrDefault();
            }
        }

        public bool ExisteIsbn(string isbn, int idExcluido = 0)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            string valor = isbn.Trim();

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                return contexto.CreateObjectSet<LibroModelo>()
                    .Any(l => l.ISBN == valor && l.IDLibro != idExcluido);
            }
        }

        public List<string> ConsultarCategorias()
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                return contexto.Categorias
                    .AsNoTracking()
                    .OrderBy(c => c.Nombre)
                    .Select(c => c.Nombre)
                    .ToList();
            }
        }

        public List<AutorEntidad> ConsultarAutores()
        {
            AutorDatos autorDatos = new AutorDatos();
            return autorDatos.ConsultarTodos();
        }

        // ---------------------------------------------------------------
        // C - Insertar
        // ---------------------------------------------------------------

        public void Insertar(LibroEntidad libro)
        {
            if (libro == null)
                throw new InvalidOperationException("El libro no puede ser nulo.");

            int idCategoria;

            using (BibliotecaContexto auxiliar = new BibliotecaContexto())
            {
                idCategoria = ObtenerIdCategoria(auxiliar, libro.Categoria);
            }

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                LibroModelo nuevo = new LibroModelo
                {
                    ISBN = libro.ISBN ?? string.Empty,
                    Titulo = libro.Titulo ?? string.Empty,
                    Anio = (short)(libro.Anio == 0 ? 0 : libro.Anio),
                    IDCategoria = idCategoria,
                    Editorial = libro.Editorial ?? string.Empty,
                    Edicion = ParsearEdicion(libro.Edicion)
                };

                contexto.AddToLibroes(nuevo);

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                libro.IDLibro = nuevo.IDLibro;
                libro.IDCategoria = idCategoria;
            }

            GuardarAutor(libro);
        }

        // ---------------------------------------------------------------
        // U - Actualizar
        // ---------------------------------------------------------------

        public void Actualizar(LibroEntidad libro)
        {
            if (libro == null)
                throw new InvalidOperationException("El libro no puede ser nulo.");

            int idCategoria;

            using (BibliotecaContexto auxiliar = new BibliotecaContexto())
            {
                idCategoria = ObtenerIdCategoria(auxiliar, libro.Categoria);
            }

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                LibroModelo encontrado = contexto.CreateObjectSet<LibroModelo>()
                    .FirstOrDefault(l => l.IDLibro == libro.IDLibro);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el libro en la base de datos.");

                encontrado.ISBN = libro.ISBN ?? string.Empty;
                encontrado.Titulo = libro.Titulo ?? string.Empty;
                encontrado.Anio = (short)(libro.Anio == 0 ? 0 : libro.Anio);
                encontrado.IDCategoria = idCategoria;
                encontrado.Editorial = libro.Editorial ?? string.Empty;
                encontrado.Edicion = ParsearEdicion(libro.Edicion);

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                libro.IDCategoria = idCategoria;
            }

            GuardarAutor(libro);
        }

        // ---------------------------------------------------------------
        // D - Eliminar
        // ---------------------------------------------------------------

        public void Eliminar(int idLibro)
        {
            using (BibliotecaContexto auxiliar = new BibliotecaContexto())
            {
                if (!auxiliar.Libros.Any(l => l.IDLibro == idLibro))
                    throw new InvalidOperationException("No se encontró el libro en la base de datos.");

                // Se comprueba antes de tocar LibroAutor: si el libro tiene
                // ejemplares, la eliminación fallará y no debe perder su autor.
                if (auxiliar.Ejemplares.Any(e => e.IDLibro == idLibro))
                    throw new InvalidOperationException(
                        "No se puede eliminar este libro porque tiene ejemplares registrados.");

                List<LibroAutorDb> relaciones = auxiliar.LibroAutores
                    .Where(relacion => relacion.IDLibro == idLibro)
                    .ToList();

                if (relaciones.Count > 0)
                {
                    auxiliar.LibroAutores.RemoveRange(relaciones);
                    auxiliar.SaveChanges();
                }
            }

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                LibroModelo encontrado = contexto.CreateObjectSet<LibroModelo>()
                    .FirstOrDefault(l => l.IDLibro == idLibro);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el libro en la base de datos.");

                contexto.DeleteObject(encontrado);

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: true);
                }
            }
        }

        // ---------------------------------------------------------------
        // Auxiliares
        // ---------------------------------------------------------------

        private static void GuardarAutor(LibroEntidad libro)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                List<LibroAutorDb> relaciones = contexto.LibroAutores
                    .Where(relacion => relacion.IDLibro == libro.IDLibro)
                    .ToList();

                if (relaciones.Count > 0)
                    contexto.LibroAutores.RemoveRange(relaciones);

                if (libro.IDAutor > 0)
                {
                    contexto.LibroAutores.Add(new LibroAutorDb
                    {
                        IDLibro = libro.IDLibro,
                        IDAutor = libro.IDAutor
                    });
                }

                try
                {
                    contexto.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    throw new InvalidOperationException(
                        "El libro se guardó, pero no fue posible asociarle el autor seleccionado: " +
                        (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
                }
            }
        }

        private static int ObtenerIdCategoria(BibliotecaContexto contexto, string nombreCategoria)
        {
            if (!string.IsNullOrWhiteSpace(nombreCategoria))
            {
                string nombre = nombreCategoria.Trim();

                CategoriaDb existente = contexto.Categorias
                    .FirstOrDefault(c => c.Nombre == nombre);

                if (existente != null)
                    return existente.IDCategoria;

                CategoriaDb nueva = new CategoriaDb { Nombre = nombre };
                contexto.Categorias.Add(nueva);
                contexto.SaveChanges();

                return nueva.IDCategoria;
            }

            CategoriaDb porDefecto = contexto.Categorias
                .FirstOrDefault(c => c.Nombre == "Sin categoría");

            if (porDefecto == null)
            {
                porDefecto = new CategoriaDb { Nombre = "Sin categoría" };
                contexto.Categorias.Add(porDefecto);
                contexto.SaveChanges();
            }

            return porDefecto.IDCategoria;
        }

        private static List<LibroEntidad> CompletarDatos(List<LibroModelo> libros)
        {
            Dictionary<int, string> categorias;
            Dictionary<int, AutorDb> autores;
            List<LibroAutorDb> relaciones;

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                categorias = contexto.Categorias
                    .AsNoTracking()
                    .ToDictionary(c => c.IDCategoria, c => c.Nombre);

                autores = contexto.Autores
                    .AsNoTracking()
                    .ToDictionary(a => a.IDAutor);

                relaciones = contexto.LibroAutores
                    .AsNoTracking()
                    .ToList();
            }

            List<LibroEntidad> resultado = new List<LibroEntidad>();

            foreach (LibroModelo libro in libros)
            {
                string nombreCategoria = string.Empty;

                if (categorias.ContainsKey(libro.IDCategoria))
                    nombreCategoria = categorias[libro.IDCategoria];

                LibroEntidad entidad = new LibroEntidad
                {
                    IDLibro = libro.IDLibro,
                    ISBN = libro.ISBN ?? string.Empty,
                    Titulo = libro.Titulo ?? string.Empty,
                    Anio = libro.Anio,
                    IDCategoria = libro.IDCategoria,
                    Categoria = nombreCategoria,
                    Editorial = libro.Editorial ?? string.Empty,
                    Edicion = libro.Edicion.ToString()
                };

                LibroAutorDb relacion = relaciones
                    .FirstOrDefault(r => r.IDLibro == libro.IDLibro);

                if (relacion != null && autores.ContainsKey(relacion.IDAutor))
                {
                    AutorDb autor = autores[relacion.IDAutor];

                    entidad.IDAutor = autor.IDAutor;
                    entidad.AutorNombre =
                        (autor.Nombre + " " + autor.Apellido).Trim();
                }

                resultado.Add(entidad);
            }

            return resultado;
        }

        private static int ParsearEdicion(string edicion)
        {
            int numero;
            return int.TryParse(edicion, out numero) && numero > 0 ? numero : 1;
        }

        private static Exception TraducirError(UpdateException ex, bool esEliminacion)
        {
            SqlException errorSql = ex.InnerException as SqlException;

            if (errorSql != null)
            {
                if (errorSql.Number == 2627 || errorSql.Number == 2601)
                {
                    return new InvalidOperationException("Ya existe un libro con ese ISBN.");
                }

                if (errorSql.Number == 547)
                {
                    return new InvalidOperationException(esEliminacion
                        ? "No se puede eliminar este libro porque tiene ejemplares registrados."
                        : "La categoría o el autor seleccionado no existe en la base de datos.");
                }
            }

            return new InvalidOperationException(
                "No fue posible guardar los cambios en la base de datos: " +
                (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
        }
    }
}
