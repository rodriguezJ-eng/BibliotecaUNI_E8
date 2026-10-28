using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // TODO: validar usuario y contraseña contra la base de datos (SQL Server).
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.", "Inicio de sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validación de tu usuario/contraseña
            if (txtUsuario.Text == "Admin" && txtContrasena.Text == "12345")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Inicio de sesión",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIniciarSesion.PerformClick();
            }
        }
    }
}
