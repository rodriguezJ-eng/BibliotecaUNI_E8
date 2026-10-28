using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using LibroEntidad = Entidades.Libro;

namespace CapaNegocio
{
    /// <summary>
    /// Catálogo único de libros de la solución. Lo comparten el módulo de
    /// Ejemplar (combo de libros y validación de la clave foránea IDLibro) y el
    /// módulo de registro y consulta de libros.
    ///
    /// Libro NO se conecta a la base de datos (por eso no existe LibroDatos): el
    /// catálogo vive en una lista estática en memoria que sobrevive mientras la
    /// aplicación esté abierta. Arranca con los libros de la tabla Libro real.
    ///
    /// IMPORTANTE: los IDLibro de la lista inicial deben existir en la tabla
    /// Libro de la base de datos (son los que se guardan como clave foránea en
    /// Ejemplar). Verifica con:  SELECT IDLibro, Titulo FROM Libro;
    /// Los libros nuevos que se registren en pantalla reciben un IDLibro
    /// consecutivo, pero solo existen en memoria: no se pueden usar en un
    /// Ejemplar hasta que se inserten también en la tabla Libro.
    /// </summary>
    public class LibroNegocio
    {
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

        /// <summary>Devuelve una copia de la lista del catálogo (los objetos Libro son los mismos).</summary>
        public List<LibroEntidad> ConsultarTodos()
        {
            return new List<LibroEntidad>(catalogo);
        }

        /// <summary>Busca un libro por su identificador (null si no existe).</summary>
        public LibroEntidad BuscarPorId(int idLibro)
        {
            return catalogo.Find(l => l.IDLibro == idLibro);
        }

        /// <summary>Indica si ya hay un libro con ese ISBN. idExcluido permite ignorar el libro que se está editando.</summary>
        public bool ExisteIsbn(string isbn, int idExcluido = 0)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            return catalogo.Any(l => l.IDLibro != idExcluido &&
                                     l.ISBN.Equals(isbn.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        private void Validar(LibroEntidad libro)
        {
            if (string.IsNullOrWhiteSpace(libro.ISBN))
                throw new Exception("El ISBN es obligatorio.");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título es obligatorio.");

            if (ExisteIsbn(libro.ISBN, libro.IDLibro))
                throw new Exception("Ya existe un libro registrado con ese ISBN.");
        }

        /// <summary>Agrega un libro al catálogo y le asigna su IDLibro.</summary>
        public void Insertar(LibroEntidad libro)
        {
            Validar(libro);

            libro.IDLibro = siguienteId++;
            catalogo.Add(libro);
        }

        /// <summary>Actualiza los datos del libro con el mismo IDLibro.</summary>
        public void Actualizar(LibroEntidad libro)
        {
            LibroEntidad existente = BuscarPorId(libro.IDLibro);
            if (existente == null)
                throw new Exception("No se encontró el libro seleccionado.");

            Validar(libro);

            existente.ISBN = libro.ISBN;
            existente.Titulo = libro.Titulo;
            existente.Autor = libro.Autor;
            existente.Categoria = libro.Categoria;
            existente.Anio = libro.Anio;
            existente.Edicion = libro.Edicion;
            existente.Editorial = libro.Editorial;
        }

        public void Eliminar(int idLibro)
        {
            LibroEntidad existente = BuscarPorId(idLibro);
            if (existente == null)
                throw new Exception("No se encontró el libro seleccionado.");

            catalogo.Remove(existente);
        }
    }
}
