using System;
using System.Collections.Generic;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    /// <summary>
    /// Reglas de negocio de Lector. Valida los datos y delega el acceso a datos
    /// en LectorDatos (Entity Framework 6).
    /// </summary>
    public class LectorNegocio
    {
        private readonly LectorDatos datos = new LectorDatos();

        public List<Lector> ConsultarTodos()
        {
            return datos.ConsultarTodos();
        }

        public Lector Buscar(int idLectores)
        {
            if (idLectores <= 0)
                return null;

            return datos.Buscar(idLectores);
        }

        public Lector BuscarPorIdentificador(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                return null;

            return datos.BuscarPorIdentificador(identificador);
        }

        public void Insertar(Lector lector)
        {
            Validar(lector);

            if (datos.ExisteIdentificador(lector.IdLector))
                throw new InvalidOperationException("Ya existe un lector registrado con ese ID de lector.");

            if (datos.ExisteCorreo(lector.Correo))
                throw new InvalidOperationException("Ya existe un lector registrado con ese correo.");

            datos.Insertar(lector);
        }

        public void Actualizar(Lector lector)
        {
            if (lector == null)
                throw new InvalidOperationException("El lector no puede ser nulo.");

            if (lector.IDLectores <= 0)
                throw new InvalidOperationException("Debe seleccionar el lector que desea actualizar.");

            Validar(lector);

            if (datos.ExisteIdentificador(lector.IdLector, lector.IDLectores))
                throw new InvalidOperationException("Ya existe otro lector registrado con ese ID de lector.");

            if (datos.ExisteCorreo(lector.Correo, lector.IDLectores))
                throw new InvalidOperationException("Ya existe otro lector registrado con ese correo.");

            datos.Actualizar(lector);
        }

        public void Eliminar(int idLectores)
        {
            if (idLectores <= 0)
                throw new InvalidOperationException("Debe seleccionar el lector que desea eliminar.");

            datos.Eliminar(idLectores);
        }

        private static void Validar(Lector lector)
        {
            if (lector == null)
                throw new InvalidOperationException("El lector no puede ser nulo.");

            lector.IdLector = (lector.IdLector ?? string.Empty).Trim();
            lector.Nombres = (lector.Nombres ?? string.Empty).Trim();
            lector.Apellidos = (lector.Apellidos ?? string.Empty).Trim();
            lector.Telefono = (lector.Telefono ?? string.Empty).Trim();
            lector.Correo = (lector.Correo ?? string.Empty).Trim();
            lector.Carrera = (lector.Carrera ?? string.Empty).Trim();
            lector.Tipo = (lector.Tipo ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(lector.IdLector))
                throw new InvalidOperationException("La identificación del lector es obligatoria.");

            if (lector.IdLector.Length > 20)
                throw new InvalidOperationException("La identificación del lector no puede tener más de 20 caracteres.");

            if (string.IsNullOrWhiteSpace(lector.Nombres))
                throw new InvalidOperationException("Los nombres del lector son obligatorios.");

            if (lector.Nombres.Length > 100)
                throw new InvalidOperationException("Los nombres del lector no pueden tener más de 100 caracteres.");

            if (string.IsNullOrWhiteSpace(lector.Apellidos))
                throw new InvalidOperationException("Los apellidos del lector son obligatorios.");

            if (lector.Apellidos.Length > 100)
                throw new InvalidOperationException("Los apellidos del lector no pueden tener más de 100 caracteres.");

            if (string.IsNullOrWhiteSpace(lector.Correo))
                throw new InvalidOperationException("El correo del lector es obligatorio.");

            if (lector.Correo.Length > 150)
                throw new InvalidOperationException("El correo del lector no puede tener más de 150 caracteres.");

            if (!lector.Correo.Contains("@") || !lector.Correo.Contains("."))
                throw new InvalidOperationException("Escriba un correo electrónico válido para el lector.");

            if (lector.Telefono.Length > 20)
                throw new InvalidOperationException("El teléfono del lector no puede tener más de 20 caracteres.");

            if (lector.Carrera.Length > 150)
                throw new InvalidOperationException("La carrera del lector no puede tener más de 150 caracteres.");

            if (lector.Tipo.Length > 20)
                throw new InvalidOperationException("El tipo de lector no puede tener más de 20 caracteres.");

            if (string.IsNullOrWhiteSpace(lector.Tipo))
                lector.Tipo = "Estudiante";
        }
    }
}
