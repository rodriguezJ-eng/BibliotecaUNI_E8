using System;
using System.Collections.Generic;
using CapaDatos;
using LibroEntidad = Entidades.Libro;
using AutorEntidad = Entidades.Autor;

namespace CapaNegocio
{
    /// <summary>
    /// Reglas de negocio de Libro. Toda la persistencia se delega en
    /// LibroDatos (Entity Framework 6), incluyendo la relación con Autor
    /// (tabla LibroAutor) y la categoría (tabla Categoria).
    /// </summary>
    public class LibroNegocio
    {
        private readonly LibroDatos datos = new LibroDatos();

        public List<LibroEntidad> ConsultarTodos()
        {
            return datos.ConsultarTodos();
        }

        public LibroEntidad BuscarPorId(int idLibro)
        {
            if (idLibro <= 0)
                return null;

            return datos.Buscar(idLibro);
        }

        public bool ExisteIsbn(string isbn, int idExcluido = 0)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            return datos.ExisteIsbn(isbn.Trim(), idExcluido);
        }

        public List<string> ConsultarCategorias()
        {
            return datos.ConsultarCategorias();
        }

        public List<AutorEntidad> ConsultarAutores()
        {
            return datos.ConsultarAutores();
        }

        public void Insertar(LibroEntidad libro)
        {
            Validar(libro);

            if (datos.ExisteIsbn(libro.ISBN))
                throw new InvalidOperationException("Ya existe un libro registrado con ese ISBN.");

            datos.Insertar(libro);
        }

        public void Actualizar(LibroEntidad libro)
        {
            if (libro == null)
                throw new InvalidOperationException("El libro no puede ser nulo.");

            if (libro.IDLibro <= 0)
                throw new InvalidOperationException("Debe seleccionar el libro que desea actualizar.");

            Validar(libro);

            if (datos.ExisteIsbn(libro.ISBN, libro.IDLibro))
                throw new InvalidOperationException("Ya existe otro libro registrado con ese ISBN.");

            datos.Actualizar(libro);
        }

        public void Eliminar(int idLibro)
        {
            if (idLibro <= 0)
                throw new InvalidOperationException("Debe seleccionar el libro que desea eliminar.");

            datos.Eliminar(idLibro);
        }

        private static void Validar(LibroEntidad libro)
        {
            if (libro == null)
                throw new InvalidOperationException("El libro no puede ser nulo.");

            libro.ISBN = (libro.ISBN ?? string.Empty).Trim();
            libro.Titulo = (libro.Titulo ?? string.Empty).Trim();
            libro.Editorial = (libro.Editorial ?? string.Empty).Trim();
            libro.Edicion = (libro.Edicion ?? string.Empty).Trim();
            libro.Categoria = (libro.Categoria ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new InvalidOperationException("El título no puede estar vacío.");

            if (libro.Titulo.Length > 200)
                throw new InvalidOperationException("El título no puede tener más de 200 caracteres.");

            if (string.IsNullOrWhiteSpace(libro.ISBN))
                throw new InvalidOperationException("El ISBN es obligatorio.");

            if (libro.ISBN.Length > 20)
                throw new InvalidOperationException("El ISBN no puede tener más de 20 caracteres.");

            if (libro.IDAutor <= 0)
                throw new InvalidOperationException("Debe seleccionar un autor válido.");

            if (libro.Editorial.Length > 150)
                throw new InvalidOperationException("La editorial no puede tener más de 150 caracteres.");

            if (libro.Categoria.Length > 50)
                throw new InvalidOperationException("La categoría no puede tener más de 50 caracteres.");

            if (libro.Anio < 0 || libro.Anio > DateTime.Today.Year + 1)
                throw new InvalidOperationException("El año del libro no es válido.");

            int edicion;
            if (!string.IsNullOrWhiteSpace(libro.Edicion) && !int.TryParse(libro.Edicion, out edicion))
                throw new InvalidOperationException("La edición debe ser un número entero.");
        }
    }
}
