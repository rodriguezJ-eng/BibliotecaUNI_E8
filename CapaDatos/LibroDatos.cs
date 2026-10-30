using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entidades;
using LibroEntidad = Entidades.Libro;
using AutorEntidad = Entidades.Autor;

namespace CapaDatos
{
    public class LibroDatos
    {
        public void Insertar(LibroEntidad libro)
        {
            if (libro == null)
                throw new Exception("El libro no puede ser nulo.");

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                CapaDatos.Libro libroEF = new CapaDatos.Libro
                {
                    ISBN = libro.ISBN ?? string.Empty,
                    Titulo = libro.Titulo ?? string.Empty,
                    Anio = (short)(libro.Anio == 0 ? 0 : libro.Anio),
                    IDCategoria = 1,
                    Editorial = libro.Editorial ?? string.Empty,
                    Edicion = ParsearEdicion(libro.Edicion)
                };

                contexto.AddToLibroes(libroEF);
                contexto.SaveChanges();

                libro.IDLibro = libroEF.IDLibro;
            }
        }

        public void Actualizar(LibroEntidad libro)
        {
            if (libro == null)
                throw new Exception("El libro no puede ser nulo.");

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                CapaDatos.Libro libroEF = contexto.CreateObjectSet<CapaDatos.Libro>()
                    .FirstOrDefault(l => l.IDLibro == libro.IDLibro);

                if (libroEF == null)
                    throw new Exception("No se encontró el libro en la base de datos.");

                libroEF.ISBN = libro.ISBN ?? string.Empty;
                libroEF.Titulo = libro.Titulo ?? string.Empty;
                libroEF.Anio = (short)(libro.Anio == 0 ? 0 : libro.Anio);
                libroEF.IDCategoria = 1;
                libroEF.Editorial = libro.Editorial ?? string.Empty;
                libroEF.Edicion = ParsearEdicion(libro.Edicion);

                contexto.SaveChanges();
            }
        }

        public void Eliminar(int idLibro)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                CapaDatos.Libro libroEF = contexto.CreateObjectSet<CapaDatos.Libro>()
                    .FirstOrDefault(l => l.IDLibro == idLibro);

                if (libroEF == null)
                    throw new Exception("No se encontró el libro en la base de datos.");

                contexto.DeleteObject(libroEF);
                contexto.SaveChanges();
            }
        }

        private static int ParsearEdicion(string edicion)
        {
            int numero;
            return int.TryParse(edicion, out numero) && numero > 0 ? numero : 1;
        }

        public List<LibroEntidad> ConsultarTodos()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<CapaDatos.Libro> libros = contexto.CreateObjectSet<CapaDatos.Libro>()
                    .AsNoTracking()
                    .Include(l => l.Ejemplars)
                    .OrderBy(l => l.Titulo)
                    .ToList();

                return libros.Select(l => ConvertirEntidad(l)).ToList();
            }
        }

        public List<AutorEntidad> ConsultarAutores()
        {
            AutorDatos autorDatos = new AutorDatos();
            return autorDatos.ConsultarTodos();
        }

        private LibroEntidad ConvertirEntidad(CapaDatos.Libro libro)
        {
            if (libro == null)
                return null;

            return new LibroEntidad
            {
                IDLibro = libro.IDLibro,
                ISBN = libro.ISBN ?? string.Empty,
                Titulo = libro.Titulo ?? string.Empty,
                Anio = libro.Anio,
                Editorial = libro.Editorial ?? string.Empty,
                Edicion = libro.Edicion.ToString()
            };
        }
    }
}
