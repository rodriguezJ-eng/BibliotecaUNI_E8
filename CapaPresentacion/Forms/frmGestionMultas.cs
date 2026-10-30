using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionMultas : Form
    {
        /// <summary>
        /// Lista estática global de multas generadas desde la gestión de préstamos.
        /// </summary>
        public static List<Multa> Multas { get; } = new List<Multa>();

        private static int _siguienteIdMulta = 1;

        /// <summary>
        /// Genera el próximo ID incremental para una nueva multa.
        /// </summary>
        public static int SiguienteIdMulta() => _siguienteIdMulta++;

        public frmGestionMultas()
        {
            InitializeComponent();

            // Evento para capturar el ID cuando el usuario selecciona una fila en la tabla
            dgvMultas.SelectionChanged += DgvMultas_SelectionChanged;

            // Cargar multas registradas al abrir la ventana
            CargarMultasEnGrid(Multas);
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



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var multa = ObtenerMultaSeleccionada();
            if (multa == null) return;

            var respuesta = MessageBox.Show($"¿Está seguro de eliminar la multa #{multa.Id} del sistema?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            Multas.Remove(multa);
            CargarMultasEnGrid(Multas);

            MessageBox.Show("Multa eliminada correctamente.", "Gestión de Multas",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Multa ObtenerMultaSeleccionada()
        {
            if (dgvMultas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una multa de la lista para continuar.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int id = Convert.ToInt32(dgvMultas.CurrentRow.Cells["Column1"].Value);
            var multa = Multas.FirstOrDefault(m => m.Id == id);

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

            foreach (var m in lista)
            {
                dgvMultas.Rows.Add(
                    m.Id,
                    m.IdPrestamo,
                    m.Lector,
                    m.Monto.ToString("0.00"),
                    m.Estado,
                    m.FechaGeneracion.ToShortDateString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            var resultado = string.IsNullOrWhiteSpace(filtro)
                ? Multas
                : Multas.Where(m =>
                    m.Lector.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    m.Id.ToString() == filtro ||
                    m.IdPrestamo.ToString() == filtro).ToList();

            CargarMultasEnGrid(resultado);
        }

        private void btnMarcarPagada_Click(object sender, EventArgs e)
        {
            var multa = ObtenerMultaSeleccionada();
            if (multa == null) return;

            if (multa.Estado == "Pagada")
            {
                MessageBox.Show("Esta multa ya se encuentra registrada como pagada.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            multa.Estado = "Pagada";

            MessageBox.Show($"La multa #{multa.Id} ha sido marcada como PAGADA con éxito.", "Pago de Multa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarMultasEnGrid(Multas);
        }
    }
}