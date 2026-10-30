using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroLector : Form
    {
        private readonly LectorNegocio lectorNegocio = new LectorNegocio();
        private bool cargandoLectores = false;

        /// <summary>ID de lector con el que se abre esta ventana (por ejemplo, desde Préstamos).</summary>
        public string IdLectorSugerido { get; set; } = string.Empty;

        public frmRegistroLector()
        {
            InitializeComponent();
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CargarLectoresEnGrid();

            if (!string.IsNullOrWhiteSpace(IdLectorSugerido))
            {
                dgvUsuarios.ClearSelection();
                txtIdLector.Text = IdLectorSugerido;
            }
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoLectores || dgvUsuarios.CurrentRow == null) return;

            Lector lector = dgvUsuarios.CurrentRow.Tag as Lector;
            if (lector == null) return;

            MostrarLector(lector);
        }

        private void MostrarLector(Lector lector)
        {
            txtIdLector.Text = lector.IdLector;
            txtNombres.Text = lector.Nombres;
            txtApellidos.Text = lector.Apellidos;
            txtTelefono.Text = lector.Telefono;
            txtCorreo.Text = lector.Correo;
            txtCarrera.Text = lector.Carrera;
            txtTipo.Text = lector.Tipo;
        }

        private Lector ObtenerLectorSeleccionado()
        {
            if (dgvUsuarios.CurrentRow == null)
                return null;

            return dgvUsuarios.CurrentRow.Tag as Lector;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdLector.Text) ||
                string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El ID de lector, los nombres y los apellidos son obligatorios.",
                    "Registro de lectores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El correo del lector es obligatorio.",
                    "Registro de lectores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtIdLector.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCarrera.Clear();
            txtTipo.Clear();
            dgvUsuarios.ClearSelection();
        }

        private void CargarLectoresEnGrid()
        {
            cargandoLectores = true;

            try
            {
                List<Lector> lectores = lectorNegocio.ConsultarTodos();

                dgvUsuarios.Rows.Clear();
                foreach (Lector lector in lectores)
                {
                    int indice = dgvUsuarios.Rows.Add(
                        lector.IdLector,
                        lector.Nombres,
                        lector.Apellidos,
                        lector.Telefono,
                        lector.Correo,
                        lector.Carrera,
                        lector.Tipo);

                    dgvUsuarios.Rows[indice].Tag = lector;
                }

                dgvUsuarios.ClearSelection();
                dgvUsuarios.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los lectores: " + ex.Message,
                    "Registro de lectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoLectores = false;
            }
        }

        private Lector ConstruirLector(int idLectores)
        {
            return new Lector
            {
                IDLectores = idLectores,
                IdLector = txtIdLector.Text.Trim(),
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Carrera = txtCarrera.Text.Trim(),
                Tipo = txtTipo.Text.Trim()
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtIdLector.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Lector lector = ObtenerLectorSeleccionado();
            if (lector == null)
            {
                MessageBox.Show("Seleccione un lector de la lista.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar al lector " + lector.NombreCompleto + "?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            try
            {
                lectorNegocio.Eliminar(lector.IDLectores);
                CargarLectoresEnGrid();
                LimpiarCampos();

                MessageBox.Show("Lector eliminado correctamente.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Lector lector = ConstruirLector(0);
                lectorNegocio.Insertar(lector);

                CargarLectoresEnGrid();
                LimpiarCampos();

                MessageBox.Show("Lector guardado.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Lector seleccionado = ObtenerLectorSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un lector de la lista.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                Lector lector = ConstruirLector(seleccionado.IDLectores);
                lectorNegocio.Actualizar(lector);

                CargarLectoresEnGrid();
                LimpiarCampos();

                MessageBox.Show("Lector actualizado correctamente.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
