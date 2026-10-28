using System;
namespace Entidades
{
    /// <summary>Representa un préstamo de un ejemplar a un lector.</summary>
    public class Prestamo
    {
        public int Id { get; set; }
        public string IdLector { get; set; } = string.Empty;
        public string NombreLector { get; set; } = string.Empty;
        public string Ejemplar { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public int DiasCredito { get; set; }
        public DateTime FechaDevolucion { get; set; }

        /// <summary>"Activo", "Devuelto". El atraso se calcula a partir de FechaDevolucion, no se guarda aparte.</summary>
        public string Estado { get; set; } = "Activo";
    }
}
