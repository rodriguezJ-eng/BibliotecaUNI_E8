using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            using (var frm = new frmRegistroLector())
            {
                frm.ShowDialog();
            }
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRegistroLibro())
            {
                frm.ShowDialog();
            }
        }

        private void btnEjemplares_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRegistroEjemplar())
            {
                frm.ShowDialog();
            }
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            using (var frm = new frmGestionPrestamos())
            {
                frm.ShowDialog();
            }
        }

        private void btnMultas_Click(object sender, EventArgs e)
        {
            using (var frm = new frmGestionMultas())
            {
                frm.ShowDialog();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConsultasReportes())
            {
                frm.ShowDialog();
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Gestión de Biblioteca Universitaria.\n\n" +
                "Use los botones de arriba para administrar libros, ejemplares, usuarios,\n" +
                "préstamos, multas y reportes.",
                "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
