using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Entidades;
using PrestamoEntidad = Entidades.Prestamo;

namespace CapaDatos
{
    /// <summary>
    /// Capa de datos de Prestamo con Entity Framework 6.
    /// Guarda las claves foráneas IDLectores e IDEjemplar en la tabla Prestamo
    /// y, al consultar, une con Lectores, Ejemplar y Libro para mostrar texto
    /// legible en la pantalla.
    /// </summary>
    public class PrestamoDatos
    {
        // ---------------------------------------------------------------
        // R - Consultar / Buscar
        // ---------------------------------------------------------------

        public List<PrestamoEntidad> ConsultarTodos()
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                List<PrestamoDb> prestamos = contexto.Prestamos
                    .Include(p => p.Lector)
                    .Include(p => p.Ejemplar)
                    .Include(p => p.Ejemplar.Libro)
                    .AsNoTracking()
                    .OrderByDescending(p => p.IDPrestamo)
                    .ToList();

                return prestamos.Select(ConvertirEntidad).ToList();
            }
        }

        public PrestamoEntidad Buscar(int idPrestamo)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                PrestamoDb prestamo = contexto.Prestamos
                    .Include(p => p.Lector)
                    .Include(p => p.Ejemplar)
                    .Include(p => p.Ejemplar.Libro)
                    .AsNoTracking()
                    .FirstOrDefault(p => p.IDPrestamo == idPrestamo);

                return ConvertirEntidad(prestamo);
            }
        }

        /// <summary>Indica si el ejemplar ya tiene un préstamo sin devolver.</summary>
        public bool ExisteActivoPorEjemplar(int idEjemplar)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                return contexto.Prestamos
                    .Any(p => p.IDEjemplar == idEjemplar && p.Estado == "Activo");
            }
        }

        // ---------------------------------------------------------------
        // C - Insertar
        // ---------------------------------------------------------------

        public void Insertar(PrestamoEntidad prestamo)
        {
            if (prestamo == null)
                throw new InvalidOperationException("El préstamo no puede ser nulo.");

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                PrestamoDb nuevo = new PrestamoDb
                {
                    IDLectores = prestamo.IDLectores,
                    IDEjemplar = prestamo.IDEjemplar,
                    FechaPrestamo = prestamo.FechaPrestamo.Date,
                    FechaDevolucion = prestamo.FechaDevolucion.Date,
                    FechaDevReal = prestamo.FechaDevolucionReal,
                    Estado = string.IsNullOrWhiteSpace(prestamo.Estado) ? "Activo" : prestamo.Estado
                };

                contexto.Prestamos.Add(nuevo);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                prestamo.Id = nuevo.IDPrestamo;
            }
        }

        // ---------------------------------------------------------------
        // U - Actualizar
        // ---------------------------------------------------------------

        public void Actualizar(PrestamoEntidad prestamo)
        {
            if (prestamo == null)
                throw new InvalidOperationException("El préstamo no puede ser nulo.");

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                PrestamoDb encontrado = contexto.Prestamos
                    .FirstOrDefault(p => p.IDPrestamo == prestamo.Id);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el préstamo en la base de datos.");

                encontrado.IDLectores = prestamo.IDLectores;
                encontrado.IDEjemplar = prestamo.IDEjemplar;
                encontrado.FechaPrestamo = prestamo.FechaPrestamo.Date;
                encontrado.FechaDevolucion = prestamo.FechaDevolucion.Date;
                encontrado.FechaDevReal = prestamo.FechaDevolucionReal;
                encontrado.Estado = string.IsNullOrWhiteSpace(prestamo.Estado)
                    ? encontrado.Estado
                    : prestamo.Estado;

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }
            }
        }

        // ---------------------------------------------------------------
        // D - Eliminar (se usa para revertir un registro si algo falla)
        // ---------------------------------------------------------------

        public void Eliminar(int idPrestamo)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                PrestamoDb encontrado = contexto.Prestamos
                    .FirstOrDefault(p => p.IDPrestamo == idPrestamo);

                if (encontrado == null)
                    return;

                contexto.Prestamos.Remove(encontrado);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: true);
                }
            }
        }

        // ---------------------------------------------------------------
        // Conversión Modelo EF -> Entidad
        // ---------------------------------------------------------------

        private static PrestamoEntidad ConvertirEntidad(PrestamoDb prestamo)
        {
            if (prestamo == null)
                return null;

            string nombreLector = string.Empty;
            string identificador = string.Empty;

            if (prestamo.Lector != null)
            {
                nombreLector = (prestamo.Lector.Nombre + " " + prestamo.Lector.Apellido).Trim();
                identificador = prestamo.Lector.Identificador ?? string.Empty;
            }

            string descripcionEjemplar = string.Empty;

            if (prestamo.Ejemplar != null)
            {
                string titulo = prestamo.Ejemplar.Libro != null
                    ? prestamo.Ejemplar.Libro.Titulo
                    : string.Empty;

                descripcionEjemplar = string.IsNullOrWhiteSpace(titulo)
                    ? prestamo.Ejemplar.Codigo
                    : prestamo.Ejemplar.Codigo + " - " + titulo;
            }

            return new PrestamoEntidad
            {
                Id = prestamo.IDPrestamo,
                IDLectores = prestamo.IDLectores,
                IDEjemplar = prestamo.IDEjemplar,
                IdLector = identificador,
                NombreLector = nombreLector,
                Ejemplar = descripcionEjemplar,
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaDevolucionReal = prestamo.FechaDevReal,
                DiasCredito = Math.Max(0, (prestamo.FechaDevolucion - prestamo.FechaPrestamo).Days),
                Estado = prestamo.Estado ?? "Activo"
            };
        }

        private static Exception TraducirError(DbUpdateException ex, bool esEliminacion)
        {
            SqlException errorSql = BuscarSqlException(ex);

            if (errorSql != null)
            {
                if (errorSql.Number == 547)
                {
                    return new InvalidOperationException(esEliminacion
                        ? "No se puede eliminar el préstamo porque tiene multas asociadas."
                        : "El lector o el ejemplar seleccionado no existe en la base de datos.");
                }

                if (errorSql.Number == 2627 || errorSql.Number == 2601)
                {
                    return new InvalidOperationException("Ya existe un préstamo con esos datos.");
                }
            }

            return new InvalidOperationException(
                "No fue posible guardar los cambios en la base de datos: " +
                (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
        }

        private static SqlException BuscarSqlException(Exception ex)
        {
            while (ex != null)
            {
                SqlException sql = ex as SqlException;
                if (sql != null)
                    return sql;

                ex = ex.InnerException;
            }

            return null;
        }
    }
}
