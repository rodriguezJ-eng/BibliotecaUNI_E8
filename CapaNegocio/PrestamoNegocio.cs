using System;
using System.Collections.Generic;
using CapaDatos;
using Entidades;
using EjemplarEntidad = Entidades.Ejemplar;

namespace CapaNegocio
{
    /// <summary>Resultado de registrar la devolución de un préstamo.</summary>
    public class ResultadoDevolucion
    {
        public int DiasAtraso { get; set; }
        public decimal MontoMulta { get; set; }
        public bool MultaGenerada { get; set; }
        public string ErrorMulta { get; set; } = string.Empty;
    }

    /// <summary>
    /// Reglas de negocio de Prestamo: registra el préstamo, marca el ejemplar
    /// como prestado, registra la devolución y genera la multa por atraso.
    /// </summary>
    public class PrestamoNegocio
    {
        /// <summary>Tarifa de multa en córdobas por cada día de atraso.</summary>
        public const decimal TarifaPorDiaAtraso = 5m;

        private readonly PrestamoDatos datos = new PrestamoDatos();
        private readonly LectorDatos lectorDatos = new LectorDatos();
        private readonly MultaDatos multaDatos = new MultaDatos();
        private readonly EjemplarNegocio ejemplares = new EjemplarNegocio();

        public List<Prestamo> ConsultarTodos()
        {
            return datos.ConsultarTodos();
        }

        public Prestamo Buscar(int idPrestamo)
        {
            if (idPrestamo <= 0)
                return null;

            return datos.Buscar(idPrestamo);
        }

        /// <summary>
        /// Registra un préstamo nuevo y deja el ejemplar en estado "Prestado".
        /// </summary>
        public void Registrar(Prestamo prestamo)
        {
            Validar(prestamo);

            Lector lector = lectorDatos.Buscar(prestamo.IDLectores);
            if (lector == null)
                throw new InvalidOperationException("El lector seleccionado no existe en la base de datos.");

            EjemplarEntidad ejemplar = ejemplares.BuscarPorId(prestamo.IDEjemplar);
            if (ejemplar == null)
                throw new InvalidOperationException("El ejemplar seleccionado no existe en la base de datos.");

            if (!string.Equals(ejemplar.Estado, "Disponible", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("El ejemplar seleccionado no está disponible para préstamo.");

            if (datos.ExisteActivoPorEjemplar(prestamo.IDEjemplar))
                throw new InvalidOperationException("El ejemplar seleccionado ya tiene un préstamo activo.");

            prestamo.FechaPrestamo = prestamo.FechaPrestamo.Date;
            prestamo.FechaDevolucion = prestamo.FechaDevolucion.Date;
            prestamo.FechaDevolucionReal = null;
            prestamo.Estado = "Activo";
            prestamo.IdLector = lector.IdLector;
            prestamo.NombreLector = lector.NombreCompleto;
            prestamo.Ejemplar = ejemplar.Codigo + " - " + ejemplar.TituloLibro;

            datos.Insertar(prestamo);

            try
            {
                CambiarEstadoEjemplar(ejemplar, "Prestado");
            }
            catch
            {
                // Si no se pudo marcar el ejemplar, se revierte el préstamo para
                // no dejar datos inconsistentes.
                try
                {
                    datos.Eliminar(prestamo.Id);
                }
                catch
                {
                    // Se conserva el error original.
                }

                throw;
            }
        }

        /// <summary>
        /// Registra la devolución de un préstamo activo. Si hubo atraso genera
        /// una multa pendiente y devuelve el detalle en ResultadoDevolucion.
        /// </summary>
        public ResultadoDevolucion Devolver(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new InvalidOperationException("Debe seleccionar el préstamo que desea devolver.");

            Prestamo prestamo = datos.Buscar(idPrestamo);
            if (prestamo == null)
                throw new InvalidOperationException("No se encontró el préstamo en la base de datos.");

            if (string.Equals(prestamo.Estado, "Devuelto", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Este préstamo ya fue devuelto.");

            DateTime hoy = DateTime.Today;
            int diasAtraso = (hoy - prestamo.FechaDevolucion.Date).Days;
            if (diasAtraso < 0)
                diasAtraso = 0;

            prestamo.FechaDevolucionReal = hoy;
            prestamo.Estado = "Devuelto";
            datos.Actualizar(prestamo);

            EjemplarEntidad ejemplar = ejemplares.BuscarPorId(prestamo.IDEjemplar);
            if (ejemplar != null)
            {
                try
                {
                    CambiarEstadoEjemplar(ejemplar, "Disponible");
                }
                catch
                {
                    // Si no se pudo liberar el ejemplar, se revierte la
                    // devolución para no dejar el préstamo y el ejemplar
                    // en estados contradictorios.
                    prestamo.FechaDevolucionReal = null;
                    prestamo.Estado = "Activo";

                    try
                    {
                        datos.Actualizar(prestamo);
                    }
                    catch
                    {
                        // Se conserva el error original.
                    }

                    throw;
                }
            }

            ResultadoDevolucion resultado = new ResultadoDevolucion
            {
                DiasAtraso = diasAtraso,
                MontoMulta = diasAtraso * TarifaPorDiaAtraso
            };

            if (diasAtraso > 0)
            {
                try
                {
                    Multa existente = multaDatos.BuscarPorPrestamo(prestamo.Id);
                    if (existente == null)
                    {
                        multaDatos.Insertar(new Multa
                        {
                            IdPrestamo = prestamo.Id,
                            Lector = prestamo.NombreLector,
                            Monto = resultado.MontoMulta,
                            Estado = "Pendiente",
                            FechaGeneracion = hoy
                        });

                        resultado.MultaGenerada = true;
                    }
                }
                catch (Exception ex)
                {
                    // La devolución ya quedó guardada; se informa el problema de
                    // la multa sin perder la operación principal.
                    resultado.ErrorMulta = ex.Message;
                }
            }

            return resultado;
        }

        private static void Validar(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new InvalidOperationException("El préstamo no puede ser nulo.");

            if (prestamo.IDLectores <= 0)
                throw new InvalidOperationException("Debe seleccionar un lector para el préstamo.");

            if (prestamo.IDEjemplar <= 0)
                throw new InvalidOperationException("Debe seleccionar un ejemplar para el préstamo.");

            if (prestamo.FechaPrestamo == DateTime.MinValue)
                throw new InvalidOperationException("La fecha del préstamo es obligatoria.");

            if (prestamo.FechaDevolucion == DateTime.MinValue)
                throw new InvalidOperationException("La fecha de devolución es obligatoria.");

            if (prestamo.FechaDevolucion.Date <= prestamo.FechaPrestamo.Date)
                throw new InvalidOperationException("La fecha de devolución debe ser posterior a la fecha del préstamo.");
        }

        private void CambiarEstadoEjemplar(EjemplarEntidad ejemplar, string estado)
        {
            ejemplar.Estado = estado;
            ejemplares.Actualizar(ejemplar);
        }
    }
}
