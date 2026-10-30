using System;
using System.Collections.Generic;
using CapaDatos;
using AutorEntidad = Entidades.Autor;

namespace CapaNegocio
{
    /// <summary>
    /// Reglas de negocio de Autor. Valida los datos y delega el acceso a datos
    /// en AutorDatos (Entity Framework 6).
    /// </summary>
    public class AutorNegocio
    {
        private readonly AutorDatos datos = new AutorDatos();

        public List<AutorEntidad> ConsultarTodos()
        {
            return datos.ConsultarTodos();
        }

        public AutorEntidad Buscar(int idAutor)
        {
            if (idAutor <= 0)
                return null;

            return datos.Buscar(idAutor);
        }

        public void Insertar(AutorEntidad autor)
        {
            Validar(autor);

            if (datos.Existe(autor.Nombre, autor.Apellido))
                throw new InvalidOperationException("Ya existe un autor con ese nombre y apellido.");

            datos.Insertar(autor);
        }

        public void Actualizar(AutorEntidad autor)
        {
            if (autor == null)
                throw new InvalidOperationException("El autor no puede ser nulo.");

            if (autor.IDAutor <= 0)
                throw new InvalidOperationException("Debe seleccionar el autor que desea actualizar.");

            Validar(autor);

            if (datos.Existe(autor.Nombre, autor.Apellido, autor.IDAutor))
                throw new InvalidOperationException("Ya existe otro autor con ese nombre y apellido.");

            datos.Actualizar(autor);
        }

        public void Eliminar(int idAutor)
        {
            if (idAutor <= 0)
                throw new InvalidOperationException("Debe seleccionar el autor que desea eliminar.");

            datos.Eliminar(idAutor);
        }

        private static void Validar(AutorEntidad autor)
        {
            if (autor == null)
                throw new InvalidOperationException("El autor no puede ser nulo.");

            autor.Nombre = (autor.Nombre ?? string.Empty).Trim();
            autor.Apellido = (autor.Apellido ?? string.Empty).Trim();
            autor.Nacionalidad = (autor.Nacionalidad ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(autor.Nombre))
                throw new InvalidOperationException("El nombre del autor es obligatorio.");

            if (autor.Nombre.Length > 100)
                throw new InvalidOperationException("El nombre del autor no puede tener más de 100 caracteres.");

            if (string.IsNullOrWhiteSpace(autor.Apellido))
                throw new InvalidOperationException("El apellido del autor es obligatorio.");

            if (autor.Apellido.Length > 100)
                throw new InvalidOperationException("El apellido del autor no puede tener más de 100 caracteres.");

            if (autor.Nacionalidad.Length > 80)
                throw new InvalidOperationException("La nacionalidad no puede tener más de 80 caracteres.");

            if (string.IsNullOrWhiteSpace(autor.Nacionalidad))
                autor.Nacionalidad = "Desconocida";
        }
    }
}
