using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entidades;
using AutorEntidad = Entidades.Autor;

namespace CapaDatos
{
    public class AutorDatos
    {
        public List<AutorEntidad> ConsultarTodos()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<CapaDatos.Autor> autores = contexto.CreateObjectSet<CapaDatos.Autor>()
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
                CapaDatos.Autor autor = contexto.CreateObjectSet<CapaDatos.Autor>()
                    .AsNoTracking()
                    .FirstOrDefault(a => a.IDAutor == idAutor);

                return ConvertirEntidad(autor);
            }
        }

        private AutorEntidad ConvertirEntidad(CapaDatos.Autor autor)
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
    }
}
