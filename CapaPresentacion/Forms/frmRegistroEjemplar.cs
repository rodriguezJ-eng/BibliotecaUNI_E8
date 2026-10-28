using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    /// <summary>
    /// CAPA DE PRESENTACIÓN - CRUD de Ejemplar.
    ///
    /// Este formulario solo captura datos, muestra resultados y mensajes. NO
    /// contiene SQL ni usa el contexto de Entity Framework: todo pasa por
    /// EjemplarNegocio (validaciones) que a su vez usa EjemplarDatos (Entity
    /// Framework + LINQ). el catálogo de Libro lo administra
    /// LibroNegocio con una lista en memoria.
    /// </summary>
    public partial class frmRegistroEjemplar : Form
    {
        private readonly EjemplarNegocio negocio = new EjemplarNegocio();
        private readonly LibroNegocio libroNegocio = new LibroNegocio();

        /// <summary>Libros en el mismo orden en que aparecen en cmbLibro.</summary>
        private List<Libro> _librosParaCombo = new List<Libro>();

        /// <summary>IDEjemplar de la fila seleccionada en el grid (null = modo "nuevo").</summary>
        private int? _idEjemplarSeleccionado = null;

        public frmRegistroEjemplar()
        {
            InitializeComponent();

            CargarLibrosParaCombo();
            cmbFiltroEstado.SelectedIndex = 0; // "Todos"

            ConsultarTodosYMostrar();
        }

        // ---------------------------------------------------------------
        // CRUD
        // ---------------------------------------------------------------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCodigo.Focus();
        }

        /// <summary>C - Crear un nuevo ejemplar.</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Ejemplar ejemplar = LeerEjemplarDelFormulario();

                if (negocio.Insertar(ejemplar))
                {
                    MessageBox.Show("El ejemplar se ha registrado exitosamente.", "Ejemplar registrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos(mantenerLibroSeleccionado: true);
                    ConsultarTodosYMostrar();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el ejemplar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>U - Actualizar el ejemplar seleccionado en el grid.</summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_idEjemplarSeleccionado == null)
            {
                MessageBox.Show("Selecciona en el listado el ejemplar que deseas editar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Ejemplar ejemplar = LeerEjemplarDelFormulario();
                ejemplar.IDEjemplar = _idEjemplarSeleccionado.Value;

                if (negocio.Actualizar(ejemplar))
                {
                    MessageBox.Show("El ejemplar se ha actualizado exitosamente.", "Ejemplar actualizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    ConsultarTodosYMostrar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el ejemplar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>D - Eliminar el ejemplar seleccionado en el grid.</summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idEjemplarSeleccionado == null)
            {
                MessageBox.Show("Selecciona en el listado el ejemplar que deseas eliminar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar este ejemplar?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (negocio.Eliminar(_idEjemplarSeleccionado.Value))
                {
                    MessageBox.Show("Ejemplar eliminado correctamente.", "Eliminado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    ConsultarTodosYMostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------------------------------------------------------------
        // R - Consultar / Filtros / Estadística
        // ---------------------------------------------------------------

        /// <summary>R - Consulta todos los ejemplares y los muestra en el grid.</summary>
        private void ConsultarTodosYMostrar()
        {
            try
            {
                cmbOrdenar.SelectedIndex = -1;
                MostrarEnGrid(negocio.ConsultarTodos());
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible consultar los ejemplares:\n" + ex.Message,
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0; // "Todos"
            ConsultarTodosYMostrar();
        }

        /// <summary>Filtro 1: consulta los ejemplares por Estado.</summary>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarEnGrid(negocio.BuscarPorEstado(cmbFiltroEstado.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>Buscar: localiza un ejemplar por su código y carga sus datos en los controles.</summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Ejemplar ejemplar = negocio.BuscarPorCodigo(txtBuscarCodigo.Text);

                if (ejemplar == null)
                {
                    MessageBox.Show("No se encontró un ejemplar con ese código.", "Búsqueda",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBuscarCodigo.SelectAll();
                    txtBuscarCodigo.Focus();
                    return;
                }

                MostrarEnGrid(new List<Ejemplar> { ejemplar });
                MostrarEjemplar(ejemplar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No fue posible realizar la búsqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Ordenar: muestra el listado ordenado según la opción elegida.</summary>
        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOrdenar.SelectedIndex == -1)
                {
                    return;
                }

                switch (cmbOrdenar.Text)
                {
                    case "Código (A-Z)":
                        MostrarEnGrid(negocio.OrdenarCodigoAscendente());
                        break;
                    case "Código (Z-A)":
                        MostrarEnGrid(negocio.OrdenarCodigoDescendente());
                        break;
                    case "Estado (A-Z)":
                        MostrarEnGrid(negocio.OrdenarEstadoAscendente());
                        break;
                    case "Estado (Z-A)":
                        MostrarEnGrid(negocio.OrdenarEstadoDescendente());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No fue posible ordenar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Filtro 2 (cálculo): cantidad de ejemplares agrupados por Estado.</summary>
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                List<(string Estado, int Cantidad)> estadisticas = negocio.ConsultarEstadisticasPorEstado();

                if (estadisticas.Count == 0)
                {
                    txtEstadisticas.Text = "No hay ejemplares registrados.";
                    return;
                }

                List<string> lineas = new List<string>();
                foreach (var fila in estadisticas)
                {
                    lineas.Add($"{fila.Estado}: {fila.Cantidad}");
                }

                txtEstadisticas.Text = string.Join("   |   ", lineas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al calcular las estadísticas:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Carga en el grid una lista de ejemplares ya consultada.</summary>
        private void MostrarEnGrid(List<Ejemplar> lista)
        {
            dgvEjemplares.Rows.Clear();

            foreach (Ejemplar ejemplar in lista)
            {
                dgvEjemplares.Rows.Add(
                    ejemplar.IDEjemplar,
                    ejemplar.IDLibro,
                    ejemplar.Codigo,
                    ejemplar.Estado,
                    ejemplar.TituloLibro);
            }
        }

        /// <summary>Al seleccionar una fila del grid, sus datos se cargan en los controles para editar o eliminar.</summary>
        private void dgvEjemplares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvEjemplares.Rows[e.RowIndex];

            _idEjemplarSeleccionado = Convert.ToInt32(fila.Cells["colIDEjemplar"].Value);
            int idLibro = Convert.ToInt32(fila.Cells["colIDLibro"].Value);

            cmbLibro.SelectedIndex = _librosParaCombo.FindIndex(l => l.IDLibro == idLibro);
            txtCodigo.Text = Convert.ToString(fila.Cells["colCodigo"].Value);
            cmbEstado.SelectedItem = Convert.ToString(fila.Cells["colEstado"].Value);
        }

        // ---------------------------------------------------------------
        // Auxiliares
        // ---------------------------------------------------------------

        /// <summary>Arma un objeto Ejemplar con lo que hay en los controles (sin validar: eso lo hace la capa de negocio).</summary>
        private Ejemplar LeerEjemplarDelFormulario()
        {
            Libro libro = ObtenerLibroSeleccionado();

            return new Ejemplar
            {
                IDLibro = libro != null ? libro.IDLibro : 0,
                Codigo = txtCodigo.Text.Trim(),
                Estado = cmbEstado.Text
            };
        }

        /// <summary>Carga un ejemplar en los controles y lo deja seleccionado para editar o eliminar.</summary>
        private void MostrarEjemplar(Ejemplar ejemplar)
        {
            _idEjemplarSeleccionado = ejemplar.IDEjemplar;

            cmbLibro.SelectedIndex = _librosParaCombo.FindIndex(l => l.IDLibro == ejemplar.IDLibro);
            txtCodigo.Text = ejemplar.Codigo;
            cmbEstado.SelectedItem = ejemplar.Estado;
        }

        private void LimpiarCampos(bool mantenerLibroSeleccionado = false)
        {
            if (!mantenerLibroSeleccionado)
            {
                cmbLibro.SelectedIndex = -1;
            }

            txtCodigo.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
            _idEjemplarSeleccionado = null;
        }

        /// <summary>Llena cmbLibro con el catálogo que entrega LibroNegocio (en memoria, sin base de datos).</summary>
        private void CargarLibrosParaCombo()
        {
            _librosParaCombo = libroNegocio.ConsultarTodos();

            cmbLibro.Items.Clear();
            foreach (Libro libro in _librosParaCombo)
            {
                cmbLibro.Items.Add($"{libro.IDLibro} - {libro.Titulo}");
            }
        }

        private Libro ObtenerLibroSeleccionado()
        {
            if (cmbLibro.SelectedIndex < 0 || cmbLibro.SelectedIndex >= _librosParaCombo.Count)
            {
                return null;
            }

            return _librosParaCombo[cmbLibro.SelectedIndex];
        }

        /// <summary>
        /// Punto de acceso para otras pantallas (por ejemplo frmGestionPrestamos)
        /// que necesitan los ejemplares disponibles. Ahora se piden a la capa de
        /// negocio; si no hay conexión se devuelve una lista vacía.
        /// </summary>
        public static List<Ejemplar> ObtenerEjemplaresDisponibles()
        {
            try
            {
                return new EjemplarNegocio().ConsultarDisponibles();
            }
            catch (Exception)
            {
                return new List<Ejemplar>();
            }
        }

        private void btnImprimirTodos_Click(object sender, EventArgs e)
        {
            try
            {
                List<Ejemplar> ejemplares = negocio.ConsultarTodos();

                if (ejemplares == null || ejemplares.Count == 0)
                {
                    MessageBox.Show("No existen ejemplares para mostrar.",
                        "Reporte", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (frmReporteEjemplares formulario =
                    new frmReporteEjemplares(ejemplares))
                {
                    formulario.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No fue posible generar el reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnImprimirEjemplar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtBuscarCodigo.Text.Trim();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("Escriba el código del ejemplar.",
                        "Reporte individual", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtBuscarCodigo.Focus();
                    return;
                }

                Ejemplar ejemplar = negocio.BuscarPorCodigo(codigo);

                if (ejemplar == null)
                {
                    MessageBox.Show("No se encontró un ejemplar con ese código.",
                        "Reporte individual", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    txtBuscarCodigo.SelectAll();
                    txtBuscarCodigo.Focus();
                    return;
                }

                List<Ejemplar> ejemplares = new List<Ejemplar> { ejemplar };

                using (frmReporteEjemplares formulario =
                    new frmReporteEjemplares(ejemplares))
                {
                    formulario.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No fue posible generar el reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } 
    }
}
