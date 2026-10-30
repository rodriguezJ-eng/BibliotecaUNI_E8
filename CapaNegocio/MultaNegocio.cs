using System;
using System.Collections.Generic;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    /// <summary>
    /// Reglas de negocio de Multa. La multa se genera automáticamente al
    /// registrar una devolución con atraso; desde esta capa también se puede
    /// marcar como pagada o eliminarla.
    /// </summary>
    public class MultaNegocio
    {
        private readonly MultaDatos datos = new MultaDatos();
        private readonly PrestamoDatos prestamoDatos = new PrestamoDatos();

        public List<Multa> ConsultarTodos()
        {
            return datos.ConsultarTodos();
        }

        public Multa Buscar(int idMulta)
        {
            if (idMulta <= 0)
                return null;

            return datos.Buscar(idMulta);
        }

        public Multa BuscarPorPrestamo(int idPrestamo)
        {
            if (idPrestamo <= 0)
                return null;

            return datos.BuscarPorPrestamo(idPrestamo);
        }

        public void Insertar(Multa multa)
        {
            Validar(multa);

            if (prestamoDatos.Buscar(multa.IdPrestamo) == null)
                throw new InvalidOperationException("El préstamo asociado a la multa no existe.");

            if (datos.BuscarPorPrestamo(multa.IdPrestamo) != null)
                throw new InvalidOperationException("Ya existe una multa registrada para ese préstamo.");

            datos.Insertar(multa);
        }

        public void Actualizar(Multa multa)
        {
            if (multa == null)
                throw new InvalidOperationException("La multa no puede ser nula.");

            if (multa.Id <= 0)
                throw new InvalidOperationException("Debe seleccionar la multa que desea actualizar.");

            Validar(multa);

            datos.Actualizar(multa);
        }

        public void MarcarPagada(int idMulta)
        {
            Multa multa = Buscar(idMulta);
            if (multa == null)
                throw new InvalidOperationException("No se encontró la multa en la base de datos.");

            if (string.Equals(multa.Estado, "Pagada", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Esta multa ya se encuentra registrada como pagada.");

            multa.Estado = "Pagada";
            datos.Actualizar(multa);
        }

        public void Eliminar(int idMulta)
        {
            if (idMulta <= 0)
                throw new InvalidOperationException("Debe seleccionar la multa que desea eliminar.");

            datos.Eliminar(idMulta);
        }

        private static void Validar(Multa multa)
        {
            if (multa == null)
                throw new InvalidOperationException("La multa no puede ser nula.");

            if (multa.IdPrestamo <= 0)
                throw new InvalidOperationException("La multa debe estar asociada a un préstamo.");

            if (multa.Monto < 0)
                throw new InvalidOperationException("El monto de la multa no puede ser negativo.");

            multa.Estado = (multa.Estado ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(multa.Estado))
                multa.Estado = "Pendiente";

            if (!string.Equals(multa.Estado, "Pendiente", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(multa.Estado, "Pagada", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("El estado de la multa debe ser 'Pendiente' o 'Pagada'.");

            if (multa.FechaGeneracion == DateTime.MinValue)
                multa.FechaGeneracion = DateTime.Today;
        }
    }
}
