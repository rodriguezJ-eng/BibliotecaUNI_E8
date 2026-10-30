using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionPrestamos : Form
    {
        /// <summary>
        /// Préstamos registrados. Static por la misma razón que Lectores en
        /// frmRegistroLector: debe sobrevivir a que esta ventana se cierre y se
        /// vuelva a abrir con una instancia nueva desde frmMenu.
        /// </summary>
        public static List<Prestamo> Prestamos { get; } = new List<Prestamo>();

        private static int _siguienteIdPrestamo = 1;

        /// <summary>Tarifa de multa en córdobas por cada día de atraso en la devolución.</summary>
        private const decimal TarifaPorDiaAtraso = 5m;

        public frmGestionPrestamos()
        {
            InitializeComponent();

            cmbPrestamos.Items.AddRange(new object[] { "Todos", "Activos", "Devueltos", "Atrasados" });
            cmbPrestamos.SelectedIndex = 0;

            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Enabled = false;

            CargarEjemplaresEnCombo();

            CargarPrestamosEnGrid(Prestamos);
        }

        /// <summary>
        /// Carga en cmbEjemplar únicamente los ejemplares en estado "Disponible".
        /// Los ejemplares ahora se administran en la base de datos (ver
        /// frmRegistroEjemplar / EjemplarNegocio), por lo que se consultan desde
        /// allí; el título del libro ya viene incluido en cada Ejemplar.
        /// </summary>
        private void CargarEjemplaresEnCombo()
        {
            cmbEjemplar.Items.Clear();

            var ejemplaresDisponibles = frmRegistroEjemplar.ObtenerEjemplaresDisponibles();

            foreach (var ej in ejemplaresDisponibles)
            {
                // Agregamos el formato: [Código Ejemplar] - Título Libro
                cmbEjemplar.Items.Add($"{ej.Codigo} - {ej.TituloLibro}");
            }
        }



        /// <summary>
        /// Busca al lector por su ID en frmRegistroLector.Lectores. Si no existe,
        /// abre esa ventana (modal) para registrarlo; al cerrarla, vuelve a buscarlo.
        /// Devuelve null si el usuario cerró la ventana sin registrar al lector.
        /// </summary>
        private Lector BuscarORegistrarLector(string idLector)
        {
            var lector = frmRegistroLector.Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector != null) return lector;

            MessageBox.Show(
                "No se encontró un lector con ese ID. Se abrirá la ventana de registro.",
                "Lector no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (var frmLector = new frmRegistroLector { IdLectorSugerido = idLector })
            {
                frmLector.ShowDialog();
            }

            lector = frmRegistroLector.Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector == null)
            {
                MessageBox.Show(
                    "El lector no fue registrado, no se puede continuar con el préstamo.",
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return lector;
        }



       

        private List<Prestamo> FiltrarPrestamos()
        {
            DateTime hoy = DateTime.Today;

            // La "expresión switch" (x switch { ... }) es de C# 8: en C# 7.3 se usa el switch de siempre.
            switch (cmbPrestamos.SelectedItem?.ToString())
            {
                case "Activos":
                    return Prestamos.Where(p => p.Estado == "Activo" && p.FechaDevolucion >= hoy).ToList();
                case "Devueltos":
                    return Prestamos.Where(p => p.Estado == "Devuelto").ToList();
                case "Atrasados":
                    return Prestamos.Where(p => p.Estado == "Activo" && p.FechaDevolucion < hoy).ToList();
                default:
                    return Prestamos.ToList();
            }
        }

        private void CargarPrestamosEnGrid(List<Prestamo> lista)
        {
            dgvPrestamos.Rows.Clear();

            foreach (var p in lista)
            {
                string estadoMostrado = p.Estado == "Activo" && p.FechaDevolucion < DateTime.Today
                    ? "Atrasado"
                    : p.Estado;

                dgvPrestamos.Rows.Add(
                    p.Id,
                    p.NombreLector,
                    p.Ejemplar,
                    p.FechaPrestamo.ToShortDateString(),
                    p.FechaDevolucion.ToShortDateString(),
                    estadoMostrado);
            }
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

            var lector = frmRegistroLector.Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector != null)
            {
                MessageBox.Show($"Lector encontrado: {lector.NombreCompleto} ({lector.Tipo}).",
                    "Buscar lector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                "No existe un lector con ese ID. ¿Desea registrarlo ahora?",
                "Lector no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                using (var frmLector = new frmRegistroLector { IdLectorSugerido = idLector })
                {
                    frmLector.ShowDialog();
                }
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
            var prestamo = Prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo == null) return;

            if (prestamo.Estado == "Devuelto")
            {
                MessageBox.Show("Este préstamo ya fue devuelto.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime hoy = DateTime.Today;
            int diasAtraso = (hoy - prestamo.FechaDevolucion).Days;

            prestamo.Estado = "Devuelto";

            if (diasAtraso > 0)
            {
                decimal monto = diasAtraso * TarifaPorDiaAtraso;

                frmGestionMultas.Multas.Add(new Multa
                {
                    Id = frmGestionMultas.SiguienteIdMulta(),
                    IdPrestamo = prestamo.Id,
                    Lector = prestamo.NombreLector,
                    Monto = monto,
                    Estado = "Pendiente",
                    FechaGeneracion = hoy
                });

                MessageBox.Show(
                    $"El préstamo tenía {diasAtraso} día(s) de atraso.\nSe generó una multa de C${monto:0.00}.",
                    "Multa generada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Devolución registrada dentro del plazo.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarPrestamosEnGrid(FiltrarPrestamos());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPrestamosEnGrid(FiltrarPrestamos());
        }

        private void btnRegistroPrestamo_Click(object sender, EventArgs e)
        {
            string idLector = txtIdLector.Text.Trim();
            string ejemplar = cmbEjemplar.Text.Trim();

            if (string.IsNullOrWhiteSpace(idLector))
            {
                MessageBox.Show("Ingrese el ID del lector.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ejemplar))
            {
                MessageBox.Show("Ingrese el ejemplar a prestar.", "Gestión de Préstamos",
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
            {
                // El usuario cerró la ventana de registro sin completar el registro del lector.
                return;
            }

            DateTime fechaPrestamo = dtpFechaPrestamo.Value.Date;
            DateTime fechaDevolucion = fechaPrestamo.AddDays(diasCredito);

            var prestamo = new Prestamo
            {
                Id = _siguienteIdPrestamo++,
                IdLector = lector.IdLector,
                NombreLector = lector.NombreCompleto,
                Ejemplar = ejemplar,
                FechaPrestamo = fechaPrestamo,
                DiasCredito = diasCredito,
                FechaDevolucion = fechaDevolucion,
                Estado = "Activo"
            };
            Prestamos.Add(prestamo);

            dtpFechaDevolucion.Value = fechaDevolucion;
            CargarPrestamosEnGrid(FiltrarPrestamos());

            MessageBox.Show(
                $"Préstamo registrado para {lector.NombreCompleto}." +
                $"\nFecha de devolución: {fechaDevolucion:dd/MM/yyyy}.",
                "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpFechaDevolucion_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
