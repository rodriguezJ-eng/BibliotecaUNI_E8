using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Entidades;
using MultaEntidad = Entidades.Multa;

namespace CapaDatos
{
    /// <summary>
    /// Capa de datos de Multa con Entity Framework 6.
    /// La columna Pagada (bit) se expone como Estado ("Pagada" / "Pendiente").
    /// El nombre del lector se obtiene desde Prestamo -> Lectores.
    /// </summary>
    public class MultaDatos
    {
        // ---------------------------------------------------------------
        // R - Consultar / Buscar
        // ---------------------------------------------------------------

        public List<MultaEntidad> ConsultarTodos()
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                List<MultaDb> multas = contexto.Multas
                    .Include(m => m.Prestamo.Lector)
                    .AsNoTracking()
                    .OrderByDescending(m => m.IDMulta)
                    .ToList();

                return multas.Select(ConvertirEntidad).ToList();
            }
        }

        public MultaEntidad Buscar(int idMulta)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                MultaDb multa = contexto.Multas
                    .Include(m => m.Prestamo.Lector)
                    .AsNoTracking()
                    .FirstOrDefault(m => m.IDMulta == idMulta);

                return ConvertirEntidad(multa);
            }
        }

        public MultaEntidad BuscarPorPrestamo(int idPrestamo)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                MultaDb multa = contexto.Multas
                    .Include(m => m.Prestamo.Lector)
                    .AsNoTracking()
                    .FirstOrDefault(m => m.IDPrestamo == idPrestamo);

                return ConvertirEntidad(multa);
            }
        }

        // ---------------------------------------------------------------
        // C - Insertar
        // ---------------------------------------------------------------

        public void Insertar(MultaEntidad multa)
        {
            if (multa == null)
                throw new InvalidOperationException("La multa no puede ser nula.");

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                MultaDb nueva = new MultaDb
                {
                    IDPrestamo = multa.IdPrestamo,
                    Monto = multa.Monto,
                    Pagada = string.Equals(multa.Estado, "Pagada", StringComparison.OrdinalIgnoreCase),
                    FechaMulta = multa.FechaGeneracion == DateTime.MinValue
                        ? DateTime.Today
                        : multa.FechaGeneracion.Date
                };

                contexto.Multas.Add(nueva);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                multa.Id = nueva.IDMulta;
                multa.Estado = nueva.Pagada ? "Pagada" : "Pendiente";
                multa.FechaGeneracion = nueva.FechaMulta;
            }
        }

        // ---------------------------------------------------------------
        // U - Actualizar
        // ---------------------------------------------------------------

        public void Actualizar(MultaEntidad multa)
        {
            if (multa == null)
                throw new InvalidOperationException("La multa no puede ser nula.");

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                MultaDb encontrada = contexto.Multas
                    .FirstOrDefault(m => m.IDMulta == multa.Id);

                if (encontrada == null)
                    throw new InvalidOperationException("No se encontró la multa en la base de datos.");

                encontrada.Monto = multa.Monto;
                encontrada.Pagada = string.Equals(multa.Estado, "Pagada", StringComparison.OrdinalIgnoreCase);
                encontrada.FechaMulta = multa.FechaGeneracion == DateTime.MinValue
                    ? encontrada.FechaMulta
                    : multa.FechaGeneracion.Date;

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
        // D - Eliminar
        // ---------------------------------------------------------------

        public void Eliminar(int idMulta)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                MultaDb encontrada = contexto.Multas
                    .FirstOrDefault(m => m.IDMulta == idMulta);

                if (encontrada == null)
                    throw new InvalidOperationException("No se encontró la multa en la base de datos.");

                contexto.Multas.Remove(encontrada);

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

        private static MultaEntidad ConvertirEntidad(MultaDb multa)
        {
            if (multa == null)
                return null;

            string lector = string.Empty;

            if (multa.Prestamo != null && multa.Prestamo.Lector != null)
            {
                lector = (multa.Prestamo.Lector.Nombre + " " + multa.Prestamo.Lector.Apellido).Trim();
            }

            return new MultaEntidad
            {
                Id = multa.IDMulta,
                IdPrestamo = multa.IDPrestamo,
                Lector = lector,
                Monto = multa.Monto,
                Estado = multa.Pagada ? "Pagada" : "Pendiente",
                FechaGeneracion = multa.FechaMulta
            };
        }

        private static Exception TraducirError(DbUpdateException ex, bool esEliminacion)
        {
            SqlException errorSql = BuscarSqlException(ex);

            if (errorSql != null)
            {
                if (errorSql.Number == 2627 || errorSql.Number == 2601)
                {
                    return new InvalidOperationException(
                        "Ya existe una multa registrada para ese préstamo.");
                }

                if (errorSql.Number == 547)
                {
                    return new InvalidOperationException(esEliminacion
                        ? "No se puede eliminar la multa porque tiene información relacionada."
                        : "El préstamo asociado a la multa no existe.");
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
