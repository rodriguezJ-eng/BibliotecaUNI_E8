namespace Entidades
{
    /// <summary>Representa a un autor que puede asociarse a uno o varios libros.</summary>
    public class Autor
    {
        public int IDAutor { get; set; }
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;

        public string NombreCompleto => string.IsNullOrWhiteSpace(Nombre) && string.IsNullOrWhiteSpace(Apellido)
            ? Id
            : $"{Nombre} {Apellido}".Trim();
    }
}
