using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using LibroEntidad = Entidades.Libro;
using CapaDatos;

namespace CapaNegocio
{
    public class LibroNegocio
    {
        private LibroDatos libroDatos = new LibroDatos();

        private static readonly List<LibroEntidad> catalogo = new List<LibroEntidad>
        {
            new LibroEntidad { IDLibro = 1,  Titulo = "Matemáticas Aplicadas a la Ingeniería" },
            new LibroEntidad { IDLibro = 2,  Titulo = "El prodigio de los números : desafíos, paradojas y curiosidades matemáticas" },
            new LibroEntidad { IDLibro = 3,  Titulo = "Matemática básica" },
            new LibroEntidad { IDLibro = 4,  Titulo = "Matemáticas aplicadas : para administración, economía y ciencias sociales" },
            new LibroEntidad { IDLibro = 5,  Titulo = "Fundamentos de programación : algoritmos y estructuras de datos" },
            new LibroEntidad { IDLibro = 6,  Titulo = "Introducción a la programación estructurada en C." },
            new LibroEntidad { IDLibro = 7,  Titulo = "Metodología y tecnología de la programación." },
            new LibroEntidad { IDLibro = 8,  Titulo = "Mecánica para ingeniería: dinámica" },
            new LibroEntidad { IDLibro = 9,  Titulo = "Mecánica de fluidos para ingenieros" },
            new LibroEntidad { IDLibro = 10, Titulo = "Redes de Computadoras" }
        };

        private static int siguienteId = catalogo.Max(l => l.IDLibro) + 1;

        public List<LibroEntidad> ConsultarTodos()
        {
            try
            {
                List<LibroEntidad> libros = libroDatos.ConsultarTodos();
                if (libros != null && libros.Count > 0)
                    return libros;
            }
            catch
            {
            }
            return new List<LibroEntidad>(catalogo);
        }

        public LibroEntidad BuscarPorId(int idLibro)
        {
            return catalogo.Find(l => l.IDLibro == idLibro);
        }

        public bool ExisteIsbn(string isbn, int idExcluido = 0)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            return catalogo.Any(l => l.IDLibro != idExcluido &&
                                      !string.IsNullOrEmpty(l.ISBN) &&
                                      l.ISBN.Equals(isbn.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        private void Validar(LibroEntidad libro)
        {
            if (libro == null)
                throw new Exception("El libro no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título no puede estar vacío.");

            if (libro.IDAutor <= 0)
                throw new Exception("Debe seleccionar un autor válido.");

            if (string.IsNullOrWhiteSpace(libro.ISBN))
                throw new Exception("El ISBN es obligatorio.");

            if (ExisteIsbn(libro.ISBN, libro.IDLibro))
                throw new Exception("Ya existe un libro registrado con ese ISBN.");
        }

        public void Insertar(LibroEntidad libro)
        {
            Validar(libro);

            try
            {
                libroDatos.Insertar(libro);
                // Sincronizar con catálogo en memoria
                if (!catalogo.Any(c => c.IDLibro == libro.IDLibro))
                {
                    catalogo.Add(libro);
                    if (libro.IDLibro >= siguienteId)
                        siguienteId = libro.IDLibro + 1;
                }
            }
            catch (Exception)
            {
                libro.IDLibro = siguienteId++;
                if (string.IsNullOrEmpty(libro.AutorNombre) && libro.Autor != null)
                    libro.AutorNombre = libro.Autor.NombreCompleto;
                catalogo.Add(libro);
                throw;
            }
        }

        public void Actualizar(LibroEntidad libro)
        {
            if (libro == null)
                throw new Exception("El libro no puede ser nulo.");

            Validar(libro);

            LibroEntidad existente = catalogo.Find(l => l.IDLibro == libro.IDLibro);

            try
            {
                libroDatos.Actualizar(libro);
            }
            catch (Exception)
            {
                // Sin acceso a la base de datos solo se puede actualizar el catálogo en memoria.
                if (existente == null)
                    throw;
            }

            if (existente != null)
            {
                existente.ISBN = libro.ISBN;
                existente.Titulo = libro.Titulo;
                existente.IDAutor = libro.IDAutor;
                if (libro.Autor != null)
                    existente.Autor = libro.Autor;
                existente.AutorNombre = libro.AutorNombre ?? (libro.Autor != null ? libro.Autor.NombreCompleto : existente.AutorNombre);
                existente.Categoria = libro.Categoria;
                existente.Anio = libro.Anio;
                existente.Edicion = libro.Edicion;
                existente.Editorial = libro.Editorial;
            }
        }

        public void Eliminar(int idLibro)
        {
            LibroEntidad existente = catalogo.Find(l => l.IDLibro == idLibro);

            try
            {
                libroDatos.Eliminar(idLibro);
            }
            catch (Exception)
            {
                // Sin acceso a la base de datos solo se puede eliminar del catálogo en memoria.
                if (existente == null)
                    throw;
            }

            if (existente != null)
                catalogo.Remove(existente);
        }

        public List<Entidades.Autor> ConsultarAutores()
        {
            try
            {
                AutorDatos autorDatos = new AutorDatos();
                return autorDatos.ConsultarTodos();
            }
            catch
            {
                return new List<Entidades.Autor>();
            }
        }
    }
}
