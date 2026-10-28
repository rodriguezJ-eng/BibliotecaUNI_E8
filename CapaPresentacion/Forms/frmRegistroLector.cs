using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroLector : Form
    {
        /// <summary>
        /// Lectores registrados en el sistema. Es "static" a propósito: pertenece a la
        /// CLASE frmRegistroLector, no a una ventana en particular, así que sigue viva
        /// mientras la aplicación esté corriendo, aunque esta ventana se cierre y frmMenu
        /// cree una instancia nueva la próxima vez que se abra. Si fuera una lista de
        /// instancia (un "public List<Lector>" normal, sin static), cada
        /// "using var frm = new frmRegistroLector()" tendría su propia lista vacía y, al
        /// cerrar la ventana y perderse la referencia a esa instancia, esos datos se
        /// perderían
        /// </summary>
        public static List<Lector> Lectores { get; } = new List<Lector>();

        /// <summary>ID de lector con el que se abre esta ventana (por ejemplo, desde Préstamos).</summary>
        public string IdLectorSugerido { get; set; } = string.Empty;

        public frmRegistroLector()
        {
            InitializeComponent();
            dgvUsuarios.CellClick += DgvUsuarios_CellClick;
            CargarLectoresEnGrid();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrWhiteSpace(IdLectorSugerido))
            {
                txtIdLector.Text = IdLectorSugerido;
            }
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvUsuarios.Rows[e.RowIndex];
            txtIdLector.Text = fila.Cells[0].Value?.ToString();
            txtNombres.Text = fila.Cells[1].Value?.ToString();
            txtApellidos.Text = fila.Cells[2].Value?.ToString();
            txtTelefono.Text = fila.Cells[3].Value?.ToString();
            txtCorreo.Text = fila.Cells[4].Value?.ToString();
            txtCarrera.Text = fila.Cells[5].Value?.ToString();
            txtTipo.Text = fila.Cells[6].Value?.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtIdLector.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string idLector = txtIdLector.Text.Trim();

            if (Lectores.Any(l => l.IdLector == idLector))
            {
                MessageBox.Show("Ya existe un lector registrado con ese ID de lector.",
                    "Registro de lectores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lectores.Add(new Lector
            {
                IdLector = idLector,
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Carrera = txtCarrera.Text.Trim(),
                Tipo = txtTipo.Text.Trim()
            });

            CargarLectoresEnGrid();
            LimpiarCampos();

            MessageBox.Show("Lector guardado.", "Registro de lectores",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un lector de la lista.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            string idLectorOriginal = dgvUsuarios.CurrentRow.Cells[0].Value?.ToString();
            var lector = Lectores.FirstOrDefault(l => l.IdLector == idLectorOriginal);
            if (lector == null) return;

            lector.IdLector = txtIdLector.Text.Trim();
            lector.Nombres = txtNombres.Text.Trim();
            lector.Apellidos = txtApellidos.Text.Trim();
            lector.Telefono = txtTelefono.Text.Trim();
            lector.Correo = txtCorreo.Text.Trim();
            lector.Carrera = txtCarrera.Text.Trim();
            lector.Tipo = txtTipo.Text.Trim();

            CargarLectoresEnGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un lector de la lista.", "Registro de lectores",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idLector = dgvUsuarios.CurrentRow.Cells[0].Value?.ToString();
            var lector = Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector == null) return;

            var respuesta = MessageBox.Show($"¿Eliminar al lector {lector.NombreCompleto}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            Lectores.Remove(lector);
            CargarLectoresEnGrid();
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private void CargarLectoresEnGrid()
        {
            dgvUsuarios.Rows.Clear();
            foreach (var l in Lectores)
            {
                dgvUsuarios.Rows.Add(l.IdLector, l.Nombres, l.Apellidos, l.Telefono, l.Correo, l.Carrera, l.Tipo);
            }
        }
    }
}
