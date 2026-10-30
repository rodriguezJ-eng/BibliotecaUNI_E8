namespace Entidades
{
    /// <summary>
    /// Representa un libro del catálogo de la biblioteca.
    /// </summary>
    public class Libro
    {
        /// <summary>Identificador del libro (clave foránea IDLibro en Ejemplar).</summary>
        public int IDLibro { get; set; }

        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;

        // Relación con Autor: el libro almacena la referencia/ID del autor
        public int IDAutor { get; set; }
        public Autor Autor { get; set; }

        // Propiedad para compatibilidad con código existente
        public string AutorNombre { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Edicion { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
    }
}
