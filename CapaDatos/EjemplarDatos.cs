using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Entidades;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;                 // UpdateException (la que lanza ObjectContext.SaveChanges)
using System.Data.SqlClient;                   // SqlException que usa Entity Framework 6
// Hay dos clases Ejemplar: se usan alias para no confundirlas.
using EjemplarEntidad = Entidades.Ejemplar;          // la que viaja entre capas
namespace CapaDatos
{
    /// <summary>
    /// CAPA DE DATOS con Entity Framework (Entregable 5).
    /// Es la única clase que usa el contexto de EF. No escribe SQL ni usa
    /// procedimientos almacenados: las operaciones se expresan con LINQ sobre el
    /// contexto y EF genera el SQL por nosotros. Recibe y devuelve
    /// Entidades.Ejemplar; internamente trabaja con CapaDatos.Modelo.Ejemplar.
    /// </summary>
    public class EjemplarDatos
    {
        // ---------------------------------------------------------------
        // R - Listar / Buscar
        // ---------------------------------------------------------------

        /// <summary>Lista todos los ejemplares.</summary>
        public List<EjemplarEntidad> ConsultarTodos()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<Ejemplar> ejemplares = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .OrderBy(ejemplar => ejemplar.IDEjemplar)
                    .ToList();

                return ConvertirLista(ejemplares);
            }
        }

        /// <summary>Busca un ejemplar por su clave primaria (null si no existe).</summary>
        public EjemplarEntidad Buscar(int idEjemplar)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                Ejemplar ejemplar = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .FirstOrDefault(registro => registro.IDEjemplar == idEjemplar);

                return ConvertirEntidad(ejemplar);
            }
        }

        /// <summary>Busca un ejemplar por su código único (null si no existe).</summary>
        public EjemplarEntidad BuscarPorCodigo(string codigo)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                Ejemplar ejemplar = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .FirstOrDefault(registro => registro.Codigo == codigo);

                return ConvertirEntidad(ejemplar);
            }
        }

        // ---------------------------------------------------------------
        // Filtrar
        // ---------------------------------------------------------------

        /// <summary>Filtra por estado. "Todos" o vacío devuelve todos los ejemplares.</summary>
        public List<EjemplarEntidad> BuscarPorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado) || estado == "Todos")
            {
                return ConsultarTodos();
            }

            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<Ejemplar> ejemplares = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .Where(ejemplar => ejemplar.Estado == estado)
                    .OrderBy(ejemplar => ejemplar.IDEjemplar)
                    .ToList();

                return ConvertirLista(ejemplares);
            }
        }

        /// <summary>Cálculo: cantidad de ejemplares por estado (GroupBy + Count).</summary>
        public List<(string Estado, int Cantidad)> ConsultarEstadisticasPorEstado()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                var filas = contexto.CreateObjectSet<Ejemplar>()
                    .GroupBy(ejemplar => ejemplar.Estado)
                    .Select(grupo => new { Estado = grupo.Key, Cantidad = grupo.Count() })
                    .OrderBy(fila => fila.Estado)
                    .ToList();

                return filas
                    .Select(fila => (fila.Estado, fila.Cantidad))
                    .ToList();
            }
        }

        // ---------------------------------------------------------------
        // Ordenar
        // ---------------------------------------------------------------

        public List<EjemplarEntidad> OrdenarCodigoAscendente()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<Ejemplar> ejemplares = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .OrderBy(ejemplar => ejemplar.Codigo)
                    .ToList();

                return ConvertirLista(ejemplares);
            }
        }

        public List<EjemplarEntidad> OrdenarCodigoDescendente()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<Ejemplar> ejemplares = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .OrderByDescending(ejemplar => ejemplar.Codigo)
                    .ToList();

                return ConvertirLista(ejemplares);
            }
        }

        public List<EjemplarEntidad> OrdenarEstadoAscendente()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<Ejemplar> ejemplares = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .OrderBy(ejemplar => ejemplar.Estado)
                    .ThenBy(ejemplar => ejemplar.Codigo)
                    .ToList();

                return ConvertirLista(ejemplares);
            }
        }

        public List<EjemplarEntidad> OrdenarEstadoDescendente()
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                List<Ejemplar> ejemplares = contexto.CreateObjectSet<Ejemplar>()
                    .AsNoTracking()
                    .OrderByDescending(ejemplar => ejemplar.Estado)
                    .ThenByDescending(ejemplar => ejemplar.Codigo)
                    .ToList();

                return ConvertirLista(ejemplares);
            }
        }

        // ---------------------------------------------------------------
        // C - Insertar
        // ---------------------------------------------------------------

        public bool Insertar(EjemplarEntidad ejemplar)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                bool codigoRegistrado = contexto.CreateObjectSet<Ejemplar>()
                    .Any(registro => registro.Codigo == ejemplar.Codigo);

                if (codigoRegistrado)
                {
                    throw new InvalidOperationException("Ya existe un ejemplar con ese código.");
                }

                Ejemplar nuevoEjemplar = new Ejemplar
                {
                    IDLibro = ejemplar.IDLibro,
                    Codigo = ejemplar.Codigo,
                    Estado = ejemplar.Estado
                };

                contexto.CreateObjectSet<Ejemplar>().AddObject(nuevoEjemplar);

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                // EF completa la clave primaria (IDENTITY) después de guardar.
                ejemplar.IDEjemplar = nuevoEjemplar.IDEjemplar;
                return true;
            }
        }

        // ---------------------------------------------------------------
        // U - Actualizar
        // ---------------------------------------------------------------

        public bool Actualizar(EjemplarEntidad ejemplar)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                Ejemplar ejemplarEncontrado = contexto.CreateObjectSet<Ejemplar>()
                    .FirstOrDefault(registro => registro.IDEjemplar == ejemplar.IDEjemplar);

                if (ejemplarEncontrado == null)
                {
                    return false;
                }

                bool codigoDuplicado = contexto.CreateObjectSet<Ejemplar>()
                    .Any(registro => registro.Codigo == ejemplar.Codigo &&
                                     registro.IDEjemplar != ejemplar.IDEjemplar);

                if (codigoDuplicado)
                {
                    throw new InvalidOperationException("Ya existe otro ejemplar con ese código.");
                }

                ejemplarEncontrado.IDLibro = ejemplar.IDLibro;
                ejemplarEncontrado.Codigo = ejemplar.Codigo;
                ejemplarEncontrado.Estado = ejemplar.Estado;

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                return true;
            }
        }

        // ---------------------------------------------------------------
        // D - Eliminar
        // ---------------------------------------------------------------

        public bool Eliminar(int idEjemplar)
        {
            using (BibliotecaUniversitariaEntities contexto = new BibliotecaUniversitariaEntities())
            {
                Ejemplar ejemplarEncontrado = contexto.CreateObjectSet<Ejemplar>()
                    .FirstOrDefault(registro => registro.IDEjemplar == idEjemplar);

                if (ejemplarEncontrado == null)
                {
                    return false;
                }

                contexto.CreateObjectSet<Ejemplar>().DeleteObject(ejemplarEncontrado);

                try
                {
                    contexto.SaveChanges();
                }
                catch (UpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: true);
                }

                return true;
            }
        }

        // ---------------------------------------------------------------
        // Conversión: Modelo de EF  <->  Entidad que viaja entre capas
        // ---------------------------------------------------------------

        private static EjemplarEntidad ConvertirEntidad(Ejemplar ejemplar)
        {
            if (ejemplar == null)
            {
                return null;
            }

            return new EjemplarEntidad
            {
                IDEjemplar = ejemplar.IDEjemplar,
                IDLibro = ejemplar.IDLibro,
                Codigo = ejemplar.Codigo,
                Estado = ejemplar.Estado
            };
        }

        private static List<EjemplarEntidad> ConvertirLista(IEnumerable<Ejemplar> ejemplares)
        {
            return ejemplares
                .Select(ejemplar => ConvertirEntidad(ejemplar))
                .ToList();
        }

        /// <summary>
        /// Convierte los errores de SQL Server (que EF envuelve en DbUpdateException)
        /// en mensajes comprensibles para el usuario.
        /// </summary>
        private static Exception TraducirError(UpdateException ex, bool esEliminacion)
        {
            SqlException errorSql = ex.InnerException as SqlException;

            if (errorSql != null)
            {
                if (errorSql.Number == 2627 || errorSql.Number == 2601)
                {
                    return new InvalidOperationException("Ya existe un ejemplar con ese código.");
                }

                if (errorSql.Number == 547)
                {
                    return new InvalidOperationException(esEliminacion
                        ? "No se puede eliminar este ejemplar porque tiene información relacionada (por ejemplo, préstamos) en otra tabla."
                        : "El libro seleccionado no existe en la base de datos (IDLibro inválido).");
                }
            }

            return new InvalidOperationException(
                "No fue posible guardar los cambios en la base de datos: " +
                (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
        }
    }
}
