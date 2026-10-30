using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionPrestamos : Form
    {
        private readonly PrestamoNegocio prestamoNegocio = new PrestamoNegocio();
        private readonly LectorNegocio lectorNegocio = new LectorNegocio();
        private readonly EjemplarNegocio ejemplarNegocio = new EjemplarNegocio();

        private List<Prestamo> prestamos = new List<Prestamo>();

        public frmGestionPrestamos()
        {
            InitializeComponent();

            cmbPrestamos.Items.AddRange(new object[] { "Todos", "Activos", "Devueltos", "Atrasados" });
            cmbPrestamos.SelectedIndex = 0;

            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Enabled = false;

            txtDiasCredito.Text = "7";

            CargarEjemplaresEnCombo();
            CargarPrestamosDesdeBD();
        }

        /// <summary>
        /// Carga en cmbEjemplar únicamente los ejemplares disponibles que
        /// entrega la capa de negocio (base de datos).
        /// </summary>
        private void CargarEjemplaresEnCombo()
        {
            cmbEjemplar.Items.Clear();

            try
            {
                List<Ejemplar> ejemplaresDisponibles = ejemplarNegocio.ConsultarDisponibles();

                foreach (Ejemplar ejemplar in ejemplaresDisponibles)
                {
                    cmbEjemplar.Items.Add(new EjemplarOpcion(ejemplar));
                }

                if (cmbEjemplar.Items.Count > 0)
                    cmbEjemplar.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ejemplares disponibles: " + ex.Message,
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Ejemplar ObtenerEjemplarSeleccionado()
        {
            EjemplarOpcion opcion = cmbEjemplar.SelectedItem as EjemplarOpcion;
            return opcion != null ? opcion.Ejemplar : null;
        }

        /// <summary>
        /// Busca al lector por su identificación en la base de datos. Si no
        /// existe, abre la ventana de registro y vuelve a consultarlo.
        /// </summary>
        private Lector BuscarORegistrarLector(string idLector)
        {
            Lector lector = lectorNegocio.BuscarPorIdentificador(idLector);
            if (lector != null) return lector;

            MessageBox.Show(
                "No se encontró un lector con ese ID. Se abrirá la ventana de registro.",
                "Lector no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (frmRegistroLector frmLector = new frmRegistroLector { IdLectorSugerido = idLector })
            {
                frmLector.ShowDialog();
            }

            lector = lectorNegocio.BuscarPorIdentificador(idLector);
            if (lector == null)
            {
                MessageBox.Show(
                    "El lector no fue registrado, no se puede continuar con el préstamo.",
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return lector;
        }

        private void CargarPrestamosDesdeBD()
        {
            try
            {
                prestamos = prestamoNegocio.ConsultarTodos();
                CargarPrestamosEnGrid(FiltrarPrestamos());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los préstamos: " + ex.Message,
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Prestamo> FiltrarPrestamos()
        {
            DateTime hoy = DateTime.Today;

            switch (cmbPrestamos.SelectedItem?.ToString())
            {
                case "Activos":
                    return prestamos.Where(p => p.Estado == "Activo" && p.FechaDevolucion >= hoy).ToList();
                case "Devueltos":
                    return prestamos.Where(p => p.Estado == "Devuelto").ToList();
                case "Atrasados":
                    return prestamos.Where(p => p.Estado == "Activo" && p.FechaDevolucion < hoy).ToList();
                default:
                    return prestamos.ToList();
            }
        }

        private void CargarPrestamosEnGrid(List<Prestamo> lista)
        {
            dgvPrestamos.Rows.Clear();

            foreach (Prestamo p in lista)
            {
                string estadoMostrado = p.Estado == "Activo" && p.FechaDevolucion < DateTime.Today
                    ? "Atrasado"
                    : p.Estado;

                int indice = dgvPrestamos.Rows.Add(
                    p.Id,
                    p.NombreLector,
                    p.Ejemplar,
                    p.FechaPrestamo.ToShortDateString(),
                    p.FechaDevolucion.ToShortDateString(),
                    estadoMostrado);

                dgvPrestamos.Rows[indice].Tag = p;
            }

            dgvPrestamos.ClearSelection();
            dgvPrestamos.CurrentCell = null;
        }

        private void cmbEjemplar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnBuscarLector_Click(object sender, EventArgs e)
        {
            string idLector = txtIdLector.Text.Trim();
            if (string.IsNullOrWhiteSpace(idLector))
            {
                MessageBox.Show("Ingrese un ID de lector para buscar.", "Buscar lector",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Lector lector = lectorNegocio.BuscarPorIdentificador(idLector);
                if (lector != null)
                {
                    MessageBox.Show("Lector encontrado: " + lector.NombreCompleto + " (" + lector.Tipo + ").",
                        "Buscar lector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "No existe un lector con ese ID. ¿Desea registrarlo ahora?",
                    "Lector no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    using (frmRegistroLector frmLector = new frmRegistroLector { IdLectorSugerido = idLector })
                    {
                        frmLector.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Buscar lector",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un préstamo de la lista.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvPrestamos.CurrentRow.Cells["IDPrestamo"].Value);

            try
            {
                ResultadoDevolucion resultado = prestamoNegocio.Devolver(id);

                if (resultado.DiasAtraso > 0)
                {
                    string mensaje = "El préstamo tenía " + resultado.DiasAtraso + " día(s) de atraso.";

                    if (resultado.MultaGenerada)
                    {
                        mensaje += "\nSe generó una multa de C$" + resultado.MontoMulta.ToString("0.00") + ".";
                    }
                    else if (!string.IsNullOrWhiteSpace(resultado.ErrorMulta))
                    {
                        mensaje += "\nNo fue posible registrar la multa: " + resultado.ErrorMulta;
                    }

                    MessageBox.Show(mensaje, "Multa generada",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Devolución registrada dentro del plazo.", "Gestión de Préstamos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarEjemplaresEnCombo();
                CargarPrestamosDesdeBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPrestamosDesdeBD();
        }

        private void btnRegistroPrestamo_Click(object sender, EventArgs e)
        {
            string idLector = txtIdLector.Text.Trim();

            if (string.IsNullOrWhiteSpace(idLector))
            {
                MessageBox.Show("Ingrese el ID del lector.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Ejemplar ejemplar = ObtenerEjemplarSeleccionado();
            if (ejemplar == null)
            {
                MessageBox.Show("Seleccione el ejemplar a prestar.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDiasCredito.Text.Trim(), out int diasCredito) || diasCredito <= 0)
            {
                MessageBox.Show("Ingrese un número de días de crédito válido (mayor a 0).",
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lector lector = BuscarORegistrarLector(idLector);
            if (lector == null)
                return;

            DateTime fechaPrestamo = dtpFechaPrestamo.Value.Date;
            DateTime fechaDevolucion = fechaPrestamo.AddDays(diasCredito);

            try
            {
                Prestamo prestamo = new Prestamo
                {
                    IDLectores = lector.IDLectores,
                    IDEjemplar = ejemplar.IDEjemplar,
                    IdLector = lector.IdLector,
                    NombreLector = lector.NombreCompleto,
                    Ejemplar = ejemplar.Codigo + " - " + ejemplar.TituloLibro,
                    FechaPrestamo = fechaPrestamo,
                    DiasCredito = diasCredito,
                    FechaDevolucion = fechaDevolucion,
                    Estado = "Activo"
                };

                prestamoNegocio.Registrar(prestamo);

                dtpFechaDevolucion.Value = fechaDevolucion;
                CargarEjemplaresEnCombo();
                CargarPrestamosDesdeBD();

                MessageBox.Show(
                    "Préstamo registrado para " + lector.NombreCompleto + "." +
                    "\nFecha de devolución: " + fechaDevolucion.ToString("dd/MM/yyyy") + ".",
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFechaDevolucion_ValueChanged(object sender, EventArgs e)
        {
        }

        /// <summary>Elemento del combo de ejemplares que conserva el objeto Ejemplar.</summary>
        private sealed class EjemplarOpcion
        {
            public EjemplarOpcion(Ejemplar ejemplar)
            {
                Ejemplar = ejemplar;
            }

            public Ejemplar Ejemplar { get; }

            public override string ToString()
            {
                return Ejemplar.Codigo + " - " + Ejemplar.TituloLibro;
            }
        }
    }
}
