namespace Entidades
{
    /// <summary>Representa a un autor que puede asociarse a uno o varios libros.</summary>
    public class Autor
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
