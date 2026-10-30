using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CapaDatos
{
    // -----------------------------------------------------------------------
    // Entidades de persistencia (EF) para las tablas que todavía no forman
    // parte del modelo EDMX (ModeloBibliotecaUniversitaria).
    //
    // El modelo EDMX existente contiene Autor, Libro y Ejemplar. Para no
    // alterar ese modelo ya probado, las tablas Lectores, Prestamo, Multa,
    // Carrera, Categoria y LibroAutor se mapean aquí con un DbContext de
    // Entity Framework 6 (Code First sobre una base de datos existente).
    //
    // NO se crean ni se modifican tablas: Database.SetInitializer(null)
    // desactiva por completo la inicialización/migraciones de EF.
    // -----------------------------------------------------------------------

    [Table("Lectores")]
    public class LectorDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLectores { get; set; }

        [Required]
        [StringLength(20)]
        public string Identificador { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(150)]
        public string Correo { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(20)]
        public string Rol { get; set; }

        public int? IDCarrera { get; set; }

        [ForeignKey("IDCarrera")]
        public virtual CarreraDb Carrera { get; set; }

        public virtual ICollection<PrestamoDb> Prestamos { get; set; }
    }

    [Table("Carrera")]
    public class CarreraDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCarrera { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string Facultad { get; set; }

        public virtual ICollection<LectorDb> Lectores { get; set; }
    }

    [Table("Prestamo")]
    public class PrestamoDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPrestamo { get; set; }

        public int IDLectores { get; set; }

        public int IDEjemplar { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public DateTime? FechaDevReal { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        [ForeignKey("IDLectores")]
        public virtual LectorDb Lector { get; set; }

        [ForeignKey("IDEjemplar")]
        public virtual EjemplarDb Ejemplar { get; set; }

        public virtual ICollection<MultaDb> Multas { get; set; }
    }

    [Table("Multa")]
    public class MultaDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDMulta { get; set; }

        public int IDPrestamo { get; set; }

        public decimal Monto { get; set; }

        public bool Pagada { get; set; }

        public DateTime FechaMulta { get; set; }

        [ForeignKey("IDPrestamo")]
        public virtual PrestamoDb Prestamo { get; set; }
    }

    [Table("Ejemplar")]
    public class EjemplarDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDEjemplar { get; set; }

        public int IDLibro { get; set; }

        [Required]
        [StringLength(30)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        [ForeignKey("IDLibro")]
        public virtual LibroDb Libro { get; set; }
    }

    [Table("Libro")]
    public class LibroDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLibro { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        public short Anio { get; set; }

        public int IDCategoria { get; set; }

        [Required]
        [StringLength(150)]
        public string Editorial { get; set; }

        public int Edicion { get; set; }
    }

    [Table("Categoria")]
    public class CategoriaDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCategoria { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }

    [Table("Autor")]
    public class AutorDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAutor { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(80)]
        public string Nacionalidad { get; set; }
    }

    [Table("LibroAutor")]
    public class LibroAutorDb
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDLibro { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAutor { get; set; }
    }

    /// <summary>
    /// Contexto de Entity Framework 6 para las tablas que no están incluidas
    /// en el modelo EDMX. Reutiliza la misma cadena de conexión que
    /// BibliotecaUniversitariaEntities para no duplicar credenciales.
    /// </summary>
    public class BibliotecaContexto : DbContext
    {
        static BibliotecaContexto()
        {
            // La base de datos ya existe: EF no debe crearla ni modificarla.
            Database.SetInitializer<BibliotecaContexto>(null);
        }

        public BibliotecaContexto()
            : base(ObtenerCadenaConexion())
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<LectorDb> Lectores { get; set; }
        public DbSet<CarreraDb> Carreras { get; set; }
        public DbSet<PrestamoDb> Prestamos { get; set; }
        public DbSet<MultaDb> Multas { get; set; }
        public DbSet<EjemplarDb> Ejemplares { get; set; }
        public DbSet<LibroDb> Libros { get; set; }
        public DbSet<CategoriaDb> Categorias { get; set; }
        public DbSet<AutorDb> Autores { get; set; }
        public DbSet<LibroAutorDb> LibroAutores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Los nombres de tabla se controlan con [Table]; evitamos que EF
            // intente pluralizarlos.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Obtiene la cadena de conexión "de proveedor" a partir de la cadena
        /// EntityClient usada por el modelo EDMX. Así solo se mantiene una
        /// cadena en App.config.
        /// </summary>
        private static string ObtenerCadenaConexion()
        {
            ConnectionStringSettings configurada =
                ConfigurationManager.ConnectionStrings["BibliotecaUniversitariaEntities"];

            if (configurada != null && !string.IsNullOrWhiteSpace(configurada.ConnectionString))
            {
                EntityConnectionStringBuilder builder =
                    new EntityConnectionStringBuilder(configurada.ConnectionString);

                if (!string.IsNullOrWhiteSpace(builder.ProviderConnectionString))
                {
                    return builder.ProviderConnectionString;
                }
            }

            ConnectionStringSettings directa =
                ConfigurationManager.ConnectionStrings["BibliotecaUniversitariaDB"];

            if (directa != null && !string.IsNullOrWhiteSpace(directa.ConnectionString))
            {
                return directa.ConnectionString;
            }

            throw new InvalidOperationException(
                "No se encontró la cadena de conexión 'BibliotecaUniversitariaEntities' en App.config.");
        }
    }
}
