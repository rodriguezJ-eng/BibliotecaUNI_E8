using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionMultas : Form
    {
        private readonly MultaNegocio multaNegocio = new MultaNegocio();
        private List<Multa> multas = new List<Multa>();

        public frmGestionMultas()
        {
            InitializeComponent();

            dgvMultas.SelectionChanged += DgvMultas_SelectionChanged;

            CargarMultasDesdeBD();
        }

        private void DgvMultas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMultas.CurrentRow != null && dgvMultas.CurrentRow.Cells["Column1"].Value != null)
            {
                txtIdMultaSeleccionada.Text = dgvMultas.CurrentRow.Cells["Column1"].Value.ToString();
            }
            else
            {
                txtIdMultaSeleccionada.Clear();
            }
        }

        private void CargarMultasDesdeBD()
        {
            try
            {
                multas = multaNegocio.ConsultarTodos();
                CargarMultasEnGrid(multas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las multas: " + ex.Message,
                    "Gestión de Multas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Multa multa = ObtenerMultaSeleccionada();
            if (multa == null) return;

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar la multa #" + multa.Id + " del sistema?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            try
            {
                multaNegocio.Eliminar(multa.Id);
                CargarMultasDesdeBD();

                MessageBox.Show("Multa eliminada correctamente.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Multa ObtenerMultaSeleccionada()
        {
            if (dgvMultas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una multa de la lista para continuar.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            Multa multa = dgvMultas.CurrentRow.Tag as Multa;

            if (multa == null)
            {
                int id = Convert.ToInt32(dgvMultas.CurrentRow.Cells["Column1"].Value);
                multa = multaNegocio.Buscar(id);
            }

            if (multa == null)
            {
                MessageBox.Show("No se encontró el registro de la multa seleccionada.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return multa;
        }

        private void CargarMultasEnGrid(List<Multa> lista)
        {
            dgvMultas.Rows.Clear();

            foreach (Multa m in lista)
            {
                int indice = dgvMultas.Rows.Add(
                    m.Id,
                    m.IdPrestamo,
                    m.Lector,
                    m.Monto.ToString("0.00"),
                    m.Estado,
                    m.FechaGeneracion.ToShortDateString());

                dgvMultas.Rows[indice].Tag = m;
            }

            dgvMultas.ClearSelection();
            dgvMultas.CurrentCell = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            try
            {
                multas = multaNegocio.ConsultarTodos();

                List<Multa> resultado = string.IsNullOrWhiteSpace(filtro)
                    ? multas
                    : multas.Where(m =>
                        (m.Lector ?? string.Empty).IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        m.Id.ToString() == filtro ||
                        m.IdPrestamo.ToString() == filtro).ToList();

                CargarMultasEnGrid(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar las multas: " + ex.Message,
                    "Gestión de Multas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarcarPagada_Click(object sender, EventArgs e)
        {
            Multa multa = ObtenerMultaSeleccionada();
            if (multa == null) return;

            try
            {
                multaNegocio.MarcarPagada(multa.Id);
                CargarMultasDesdeBD();

                MessageBox.Show("La multa #" + multa.Id + " ha sido marcada como PAGADA con éxito.",
                    "Pago de Multa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
