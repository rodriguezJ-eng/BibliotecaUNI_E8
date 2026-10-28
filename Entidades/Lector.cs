namespace Entidades
{
    /// <summary>Representa a un lector (usuario) registrado en la biblioteca.</summary>
    public class Lector
    {
        public string IdLector { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}
