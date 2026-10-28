namespace Entidades
{
    /// <summary>
    /// Representa un libro del catálogo de la biblioteca. Es la ÚNICA clase Libro
    /// de la solución: la usan tanto el módulo de Ejemplar (clave foránea
    /// IDLibro) como el registro y las consultas de libros.
    /// Solo contiene propiedades: no tiene lógica ni acceso a datos.
    /// </summary>
    public class Libro
    {
        /// <summary>Identificador del libro (clave foránea IDLibro en Ejemplar).</summary>
        public int IDLibro { get; set; }

        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Edicion { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
    }
}
