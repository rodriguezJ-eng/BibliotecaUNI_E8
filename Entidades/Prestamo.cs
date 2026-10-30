using System;
namespace Entidades
{
    /// <summary>Representa un préstamo de un ejemplar a un lector.</summary>
    public class Prestamo
    {
        /// <summary>Clave primaria (IDPrestamo en la tabla Prestamo).</summary>
        public int Id { get; set; }

        /// <summary>Clave foránea hacia Lectores.</summary>
        public int IDLectores { get; set; }

        /// <summary>Clave foránea hacia Ejemplar.</summary>
        public int IDEjemplar { get; set; }

        public string IdLector { get; set; } = string.Empty;
        public string NombreLector { get; set; } = string.Empty;

        /// <summary>Texto para mostrar: "Código - Título del libro".</summary>
        public string Ejemplar { get; set; } = string.Empty;

        public DateTime FechaPrestamo { get; set; }
        public int DiasCredito { get; set; }
        public DateTime FechaDevolucion { get; set; }

        /// <summary>Fecha en que realmente se devolvió (null si sigue activo).</summary>
        public DateTime? FechaDevolucionReal { get; set; }

        /// <summary>"Activo", "Devuelto". El atraso se calcula a partir de FechaDevolucion, no se guarda aparte.</summary>
        public string Estado { get; set; } = "Activo";
    }
}
