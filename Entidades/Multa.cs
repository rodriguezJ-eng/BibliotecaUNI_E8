using System;
namespace Entidades
{
    /// <summary>Representa una multa generada por la devolución tardía de un préstamo.</summary>
    public class Multa
    {
        public int Id { get; set; }
        public int IdPrestamo { get; set; }
        public string Lector { get; set; } = string.Empty;
        public decimal Monto { get; set; }

        /// <summary>"Pendiente" o "Pagada".</summary>
        public string Estado { get; set; } = "Pendiente";
        public DateTime FechaGeneracion { get; set; }
    }
}
