using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core;                 // UpdateException (ObjectContext.SaveChanges)
using System.Data.SqlClient;
using Entidades;
using AutorEntidad = Entidades.Autor;
using AutorModelo = CapaDatos.Autor;

namespace CapaDatos
{
    /// <summary>
    /// Capa de datos de Autor usando el modelo EDMX y Entity Framework 6.
    /// Recibe y devuelve Entidades.Autor; internamente trabaja con el Autor
    /// generado por el modelo (CapaDatos.Autor).
    /// </summary>
    public class AutorDatos
    {
        // ---------------------------------------------------------------
        // R - Consultar / Buscar
        // ---------------------------------------------------------------

        public List<AutorEntidad> ConsultarTodos()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<AutorModelo> autores = contexto.CreateObjectSet<AutorModelo>()
                    .AsNoTracking()
                    .OrderBy(a => a.Apellido)
                    .ThenBy(a => a.Nombre)
                    .ToList();

                return autores.Select(a => ConvertirEntidad(a)).ToList();
            }
        }

        public AutorEntidad Buscar(int idAutor)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                AutorModelo autor = contexto.CreateObjectSet<AutorModelo>()
                    .AsNoTracking()
                    .FirstOrDefault(a => a.IDAutor == idAutor);

                return ConvertirEntidad(autor);
            }
        }

        /// <summary>
        /// Indica si ya existe un autor con el mismo nombre y apellido.
        /// Se usa para dar un mensaje claro antes de llegar a la restricción
        /// UNIQUE de SQL Server.
        /// </summary>
        public bool Existe(string nombre, string apellido, int idExcluido = 0)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                return contexto.CreateObjectSet<AutorModelo>()
                    .Any(a => a.Nombre == nombre &&
                              a.Apellido == apellido &&
                              a.IDAutor != idExcluido);
            }
        }

        // ---------------------------------------------------------------
        // C - Insertar
        // ---------------------------------------------------------------

        public void Insertar(AutorEntidad autor)
        {
            if (autor == null)
                throw new InvalidOperationException("El autor no puede ser nulo.");

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                AutorModelo nuevo = new AutorModelo
                {
                    Nombre = autor.Nombre ?? string.Empty,
                    Apellido = autor.Apellido ?? string.Empty,
                    Nacionalidad = string.IsNullOrWhiteSpace(autor.Nacionalidad)
                        ? "Desconocida"
                        : autor.Nacionalidad
                };

                contexto.AddToAutors(nuevo);

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                autor.IDAutor = nuevo.IDAutor;
                autor.Id = nuevo.IDAutor.ToString();
            }
        }

        // ---------------------------------------------------------------
        // U - Actualizar
        // ---------------------------------------------------------------

        public void Actualizar(AutorEntidad autor)
        {
            if (autor == null)
                throw new InvalidOperationException("El autor no puede ser nulo.");

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                AutorModelo encontrado = contexto.CreateObjectSet<AutorModelo>()
                    .FirstOrDefault(a => a.IDAutor == autor.IDAutor);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el autor en la base de datos.");

                encontrado.Nombre = autor.Nombre ?? string.Empty;
                encontrado.Apellido = autor.Apellido ?? string.Empty;
                encontrado.Nacionalidad = string.IsNullOrWhiteSpace(autor.Nacionalidad)
                    ? "Desconocida"
                    : autor.Nacionalidad;

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }
            }
        }

        // ---------------------------------------------------------------
        // D - Eliminar
        // ---------------------------------------------------------------

        public void Eliminar(int idAutor)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                AutorModelo encontrado = contexto.CreateObjectSet<AutorModelo>()
                    .FirstOrDefault(a => a.IDAutor == idAutor);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el autor en la base de datos.");

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
        // Conversión Modelo EF -> Entidad
        // ---------------------------------------------------------------

        private AutorEntidad ConvertirEntidad(AutorModelo autor)
        {
            if (autor == null)
                return null;

            return new AutorEntidad
            {
                IDAutor = autor.IDAutor,
                Id = autor.IDAutor.ToString(),
                Nombre = autor.Nombre ?? string.Empty,
                Apellido = autor.Apellido ?? string.Empty,
                Nacionalidad = autor.Nacionalidad ?? string.Empty
            };
        }

        private static Exception TraducirError(UpdateException ex, bool esEliminacion)
        {
            SqlException errorSql = ex.InnerException as SqlException;

            if (errorSql != null)
            {
                if (errorSql.Number == 2627 || errorSql.Number == 2601)
                {
                    return new InvalidOperationException(
                        "Ya existe un autor con ese nombre y apellido.");
                }

                if (errorSql.Number == 547)
                {
                    return new InvalidOperationException(esEliminacion
                        ? "No se puede eliminar el autor porque tiene libros asociados."
                        : "No fue posible guardar el autor porque hay datos relacionados.");
                }
            }

            return new InvalidOperationException(
                "No fue posible guardar los cambios en la base de datos: " +
                (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
        }
    }
}
