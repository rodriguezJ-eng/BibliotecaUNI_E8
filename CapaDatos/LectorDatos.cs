using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Entidades;
using LectorEntidad = Entidades.Lector;

namespace CapaDatos
{
    /// <summary>
    /// Capa de datos de Lector con Entity Framework 6.
    /// Trabaja contra la tabla Lectores y resuelve el nombre de la carrera
    /// mediante la tabla Carrera. Recibe y devuelve Entidades.Lector.
    /// </summary>
    public class LectorDatos
    {
        // ---------------------------------------------------------------
        // R - Consultar / Buscar
        // ---------------------------------------------------------------

        public List<LectorEntidad> ConsultarTodos()
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                List<LectorDb> lectores = contexto.Lectores
                    .Include(l => l.Carrera)
                    .AsNoTracking()
                    .OrderBy(l => l.Apellido)
                    .ThenBy(l => l.Nombre)
                    .ToList();

                return lectores.Select(ConvertirEntidad).ToList();
            }
        }

        public LectorEntidad Buscar(int idLectores)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                LectorDb lector = contexto.Lectores
                    .Include(l => l.Carrera)
                    .AsNoTracking()
                    .FirstOrDefault(l => l.IDLectores == idLectores);

                return ConvertirEntidad(lector);
            }
        }

        public LectorEntidad BuscarPorIdentificador(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                return null;

            string valor = identificador.Trim();

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                LectorDb lector = contexto.Lectores
                    .Include(l => l.Carrera)
                    .AsNoTracking()
                    .FirstOrDefault(l => l.Identificador == valor);

                return ConvertirEntidad(lector);
            }
        }

        public bool ExisteIdentificador(string identificador, int idExcluido = 0)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                return contexto.Lectores.Any(l => l.Identificador == identificador &&
                                                   l.IDLectores != idExcluido);
            }
        }

        public bool ExisteCorreo(string correo, int idExcluido = 0)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                return contexto.Lectores.Any(l => l.Correo == correo &&
                                                   l.IDLectores != idExcluido);
            }
        }

        // ---------------------------------------------------------------
        // C - Insertar
        // ---------------------------------------------------------------

        public void Insertar(LectorEntidad lector)
        {
            if (lector == null)
                throw new InvalidOperationException("El lector no puede ser nulo.");

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                LectorDb nuevo = new LectorDb
                {
                    Identificador = lector.IdLector ?? string.Empty,
                    Nombre = lector.Nombres ?? string.Empty,
                    Apellido = lector.Apellidos ?? string.Empty,
                    Correo = lector.Correo ?? string.Empty,
                    Telefono = lector.Telefono ?? string.Empty,
                    Rol = string.IsNullOrWhiteSpace(lector.Tipo) ? "Estudiante" : lector.Tipo,
                    IDCarrera = ResolverCarrera(contexto, lector.Carrera)
                };

                contexto.Lectores.Add(nuevo);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                lector.IDLectores = nuevo.IDLectores;
                lector.IDCarrera = nuevo.IDCarrera;
            }
        }

        // ---------------------------------------------------------------
        // U - Actualizar
        // ---------------------------------------------------------------

        public void Actualizar(LectorEntidad lector)
        {
            if (lector == null)
                throw new InvalidOperationException("El lector no puede ser nulo.");

            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                LectorDb encontrado = contexto.Lectores
                    .FirstOrDefault(l => l.IDLectores == lector.IDLectores);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el lector en la base de datos.");

                encontrado.Identificador = lector.IdLector ?? string.Empty;
                encontrado.Nombre = lector.Nombres ?? string.Empty;
                encontrado.Apellido = lector.Apellidos ?? string.Empty;
                encontrado.Correo = lector.Correo ?? string.Empty;
                encontrado.Telefono = lector.Telefono ?? string.Empty;
                encontrado.Rol = string.IsNullOrWhiteSpace(lector.Tipo) ? "Estudiante" : lector.Tipo;
                encontrado.IDCarrera = ResolverCarrera(contexto, lector.Carrera);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: false);
                }

                lector.IDCarrera = encontrado.IDCarrera;
            }
        }

        // ---------------------------------------------------------------
        // D - Eliminar
        // ---------------------------------------------------------------

        public void Eliminar(int idLectores)
        {
            using (BibliotecaContexto contexto = new BibliotecaContexto())
            {
                LectorDb encontrado = contexto.Lectores
                    .FirstOrDefault(l => l.IDLectores == idLectores);

                if (encontrado == null)
                    throw new InvalidOperationException("No se encontró el lector en la base de datos.");

                contexto.Lectores.Remove(encontrado);

                try
                {
                    contexto.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw TraducirError(ex, esEliminacion: true);
                }
            }
        }

        // ---------------------------------------------------------------
        // Auxiliares
        // ---------------------------------------------------------------

        /// <summary>
        /// Devuelve el ID de la carrera. Si la carrera no existe, la crea con
        /// la facultad "No registrada" para no perder el dato escrito por el
        /// usuario. Si el texto está vacío devuelve null.
        /// </summary>
        private static int? ResolverCarrera(BibliotecaContexto contexto, string nombreCarrera)
        {
            if (string.IsNullOrWhiteSpace(nombreCarrera))
                return null;

            string nombre = nombreCarrera.Trim();

            CarreraDb carrera = contexto.Carreras
                .FirstOrDefault(c => c.Nombre == nombre);

            if (carrera != null)
                return carrera.IDCarrera;

            carrera = new CarreraDb
            {
                Nombre = nombre,
                Facultad = "No registrada"
            };

            contexto.Carreras.Add(carrera);
            contexto.SaveChanges();

            return carrera.IDCarrera;
        }

        private static LectorEntidad ConvertirEntidad(LectorDb lector)
        {
            if (lector == null)
                return null;

            return new LectorEntidad
            {
                IDLectores = lector.IDLectores,
                IdLector = lector.Identificador ?? string.Empty,
                Nombres = lector.Nombre ?? string.Empty,
                Apellidos = lector.Apellido ?? string.Empty,
                Telefono = lector.Telefono ?? string.Empty,
                Correo = lector.Correo ?? string.Empty,
                Carrera = lector.Carrera != null ? lector.Carrera.Nombre : string.Empty,
                IDCarrera = lector.IDCarrera,
                Tipo = lector.Rol ?? string.Empty
            };
        }

        private static Exception TraducirError(DbUpdateException ex, bool esEliminacion)
        {
            SqlException errorSql = BuscarSqlException(ex);

            if (errorSql != null)
            {
                if (errorSql.Number == 2627 || errorSql.Number == 2601)
                {
                    return new InvalidOperationException(
                        "Ya existe un lector con esa identificación o correo.");
                }

                if (errorSql.Number == 547)
                {
                    return new InvalidOperationException(esEliminacion
                        ? "No se puede eliminar el lector porque tiene préstamos registrados."
                        : "No fue posible guardar el lector porque hay datos relacionados.");
                }
            }

            return new InvalidOperationException(
                "No fue posible guardar los cambios en la base de datos: " +
                (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
        }

        private static SqlException BuscarSqlException(Exception ex)
        {
            while (ex != null)
            {
                SqlException sql = ex as SqlException;
                if (sql != null)
                    return sql;

                ex = ex.InnerException;
            }

            return null;
        }
    }
}
