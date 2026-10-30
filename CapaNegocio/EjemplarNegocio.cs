using System;
using System.Collections.Generic;
using CapaDatos;
using Entidades;
// Definimos un alias para evitar la ambigüedad con el modelo de EF
using EjemplarEntidad = Entidades.Ejemplar;
using Libro = Entidades.Libro;

namespace CapaNegocio
{
    /// <summary>
    /// Reglas de negocio de Ejemplar: valida los datos antes de enviarlos a la
    /// capa de datos y completa información de la entidad auxiliar Libro.
    /// Esta capa NO usa el contexto de Entity Framework ni SQL: todo acceso a la
    /// base de datos se delega a EjemplarDatos (Capa de Datos).
    /// </summary>
    public class EjemplarNegocio
    {
        private static readonly string[] EstadosValidos =
            { "Disponible", "Prestado", "En reparación", "Baja" };

        private readonly EjemplarDatos datos;
        private readonly LibroNegocio libros;

        public EjemplarNegocio()
        {
            datos = new EjemplarDatos();
            libros = new LibroNegocio();
        }

        private void Validar(EjemplarEntidad ejemplar)
        {
            if (ejemplar.IDLibro <= 0)
                throw new Exception("Debe seleccionar el libro al que pertenece el ejemplar.");

            if (libros.BuscarPorId(ejemplar.IDLibro) == null)
                throw new Exception("El libro seleccionado no es válido.");

            if (string.IsNullOrWhiteSpace(ejemplar.Codigo))
                throw new Exception("El código del ejemplar es obligatorio.");

            if (ejemplar.Codigo.Length > 30)
                throw new Exception("El código no puede tener más de 30 caracteres.");

            if (string.IsNullOrWhiteSpace(ejemplar.Estado))
                throw new Exception("Debe seleccionar el estado del ejemplar.");

            if (Array.IndexOf(EstadosValidos, ejemplar.Estado) < 0)
                throw new Exception("El estado seleccionado no es válido.");

            ejemplar.Codigo = ejemplar.Codigo.Trim();
        }

        public bool Insertar(EjemplarEntidad ejemplar)
        {
            Validar(ejemplar);
            return datos.Insertar(ejemplar);
        }

        public bool Actualizar(EjemplarEntidad ejemplar)
        {
            if (ejemplar.IDEjemplar <= 0)
                throw new Exception("Debe seleccionar el ejemplar que desea actualizar.");

            Validar(ejemplar);
            return datos.Actualizar(ejemplar);
        }

        public bool Eliminar(int idEjemplar)
        {
            if (idEjemplar <= 0)
                throw new Exception("Debe seleccionar el ejemplar que desea eliminar.");

            return datos.Eliminar(idEjemplar);
        }

        public List<EjemplarEntidad> ConsultarTodos()
        {
            return CompletarTitulos(datos.ConsultarTodos());
        }

        /// <summary>Busca un ejemplar por su clave primaria (null si no existe).</summary>
        public EjemplarEntidad BuscarPorId(int idEjemplar)
        {
            if (idEjemplar <= 0)
                return null;

            EjemplarEntidad ejemplar = datos.Buscar(idEjemplar);

            if (ejemplar != null)
                CompletarTitulos(new List<EjemplarEntidad> { ejemplar });

            return ejemplar;
        }

        /// <summary>Filtro 1: por estado. "Todos" o vacío devuelve todos los ejemplares.</summary>
        public List<EjemplarEntidad> BuscarPorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado) || estado == "Todos")
                return ConsultarTodos();

            if (Array.IndexOf(EstadosValidos, estado) < 0)
                throw new Exception("El estado seleccionado no es válido.");

            return CompletarTitulos(datos.BuscarPorEstado(estado));
        }

        /// <summary>Ejemplares que se pueden prestar (usado por la pantalla de préstamos).</summary>
        public List<EjemplarEntidad> ConsultarDisponibles()
        {
            return BuscarPorEstado("Disponible");
        }

        /// <summary>Filtro 2 (cálculo): cantidad de ejemplares por estado.</summary>
        public List<(string Estado, int Cantidad)> ConsultarEstadisticasPorEstado()
        {
            return datos.ConsultarEstadisticasPorEstado();
        }

        /// <summary>Busca un ejemplar por su código exacto. Devuelve null si no existe.</summary>
        public EjemplarEntidad BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("Escriba el código del ejemplar que desea buscar.");

            EjemplarEntidad ejemplar = datos.BuscarPorCodigo(codigo.Trim());

            if (ejemplar != null)
                CompletarTitulos(new List<EjemplarEntidad> { ejemplar });

            return ejemplar;
        }

        public List<EjemplarEntidad> OrdenarCodigoAscendente()
        {
            return CompletarTitulos(datos.OrdenarCodigoAscendente());
        }

        public List<EjemplarEntidad> OrdenarCodigoDescendente()
        {
            return CompletarTitulos(datos.OrdenarCodigoDescendente());
        }

        public List<EjemplarEntidad> OrdenarEstadoAscendente()
        {
            return CompletarTitulos(datos.OrdenarEstadoAscendente());
        }

        public List<EjemplarEntidad> OrdenarEstadoDescendente()
        {
            return CompletarTitulos(datos.OrdenarEstadoDescendente());
        }

        /// <summary>Completa TituloLibro usando la lista auxiliar de Libro (no la base de datos).</summary>
        private List<EjemplarEntidad> CompletarTitulos(List<EjemplarEntidad> lista)
        {
            List<Libro> catalogo = libros.ConsultarTodos();

            foreach (EjemplarEntidad ejemplar in lista)
            {
                Libro libro = catalogo.Find(l => l.IDLibro == ejemplar.IDLibro);
                ejemplar.TituloLibro = libro != null ? libro.Titulo : "(libro no encontrado)";
            }

            return lista;
        }
    }
}
