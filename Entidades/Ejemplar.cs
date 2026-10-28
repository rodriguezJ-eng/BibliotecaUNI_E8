namespace Entidades
{
    /// <summary>
    /// Representa una fila de la tabla Ejemplar (una copia física de un libro).
    /// Solo contiene propiedades: no tiene lógica ni acceso a datos.
    ///
    ///   Ejemplar (IDEjemplar PK, IDLibro FK -> Libro, Codigo, Estado)
    /// </summary>
    public class Ejemplar
    {
        /// <summary>Clave primaria (IDENTITY en SQL Server).</summary>
        public int IDEjemplar { get; set; }

        /// <summary>Clave foránea hacia Libro.</summary>
        public int IDLibro { get; set; }

        /// <summary>Código físico único del ejemplar.</summary>
        public string Codigo { get; set; } = string.Empty;

        /// <summary>"Disponible", "Prestado", "En reparación" o "Baja".</summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Título del libro. NO es una columna de la tabla Ejemplar: se completa
        /// en la capa de negocio (con la lista auxiliar de Libro) solo para
        /// mostrar información legible en pantalla.
        /// </summary>
        public string TituloLibro { get; set; } = string.Empty;
    }
}
