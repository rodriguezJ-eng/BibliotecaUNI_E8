namespace Entidades
{
    /// <summary>Representa a un lector (usuario) registrado en la biblioteca.</summary>
    public class Lector
    {
        /// <summary>Clave primaria de la tabla Lectores (IDENTITY).</summary>
        public int IDLectores { get; set; }

        /// <summary>Identificación o cédula del lector (columna Identificador).</summary>
        public string IdLector { get; set; } = string.Empty;

        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        /// <summary>Nombre de la carrera (se obtiene de la tabla Carrera).</summary>
        public string Carrera { get; set; } = string.Empty;

        /// <summary>Clave foránea hacia Carrera (puede ser nula).</summary>
        public int? IDCarrera { get; set; }

        /// <summary>Rol del lector: Estudiante, Docente, etc. (columna Rol).</summary>
        public string Tipo { get; set; } = string.Empty;

        public string NombreCompleto => $"{Nombres} {Apellidos}".Trim();
    }
}
