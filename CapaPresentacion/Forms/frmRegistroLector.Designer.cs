using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmRegistroLector
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private GroupBox grbDatosUsuario;
        private Label lblCedula, lblNombres, lblApellidos, lblTelefono;
        private Label lblCorreo, lblCarrera, lblTipo;
        private TextBox txtIdLector, txtNombres, txtApellidos, txtTelefono;
        private TextBox txtCorreo, txtCarrera, txtTipo;

        private Button btnNuevo, btnGuardar, btnEditar, btnEliminar, btnCerrar;

        private GroupBox grbUsuariosRegistrados;
        private DataGridView dgvUsuarios;

        private void InitializeComponent()
        {
            grbDatosUsuario = new GroupBox();
            lblCedula = new Label();
            txtIdLector = new TextBox();
            lblNombres = new Label();
            txtNombres = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblCarrera = new Label();
            txtCarrera = new TextBox();
            lblTipo = new Label();
            txtTipo = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            grbUsuariosRegistrados = new GroupBox();
            dgvUsuarios = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            grbDatosUsuario.SuspendLayout();
            grbUsuariosRegistrados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // grbDatosUsuario
            // 
            grbDatosUsuario.Controls.Add(lblCedula);
            grbDatosUsuario.Controls.Add(txtIdLector);
            grbDatosUsuario.Controls.Add(lblNombres);
            grbDatosUsuario.Controls.Add(txtNombres);
            grbDatosUsuario.Controls.Add(lblApellidos);
            grbDatosUsuario.Controls.Add(txtApellidos);
            grbDatosUsuario.Controls.Add(lblTelefono);
            grbDatosUsuario.Controls.Add(txtTelefono);
            grbDatosUsuario.Controls.Add(lblCorreo);
            grbDatosUsuario.Controls.Add(txtCorreo);
            grbDatosUsuario.Controls.Add(lblCarrera);
            grbDatosUsuario.Controls.Add(txtCarrera);
            grbDatosUsuario.Controls.Add(lblTipo);
            grbDatosUsuario.Controls.Add(txtTipo);
            grbDatosUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grbDatosUsuario.Location = new Point(23, 13);
            grbDatosUsuario.Margin = new Padding(3, 4, 3, 4);
            grbDatosUsuario.Name = "grbDatosUsuario";
            grbDatosUsuario.Padding = new Padding(3, 4, 3, 4);
            grbDatosUsuario.Size = new Size(1006, 280);
            grbDatosUsuario.TabIndex = 0;
            grbDatosUsuario.TabStop = false;
            grbDatosUsuario.Text = "Datos del Lector";
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(6, 52);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(119, 23);
            lblCedula.TabIndex = 0;
            lblCedula.Text = "Identificación";
            // 
            // txtIdLector
            // 
            txtIdLector.Location = new Point(149, 49);
            txtIdLector.Margin = new Padding(3, 4, 3, 4);
            txtIdLector.Name = "txtIdLector";
            txtIdLector.Size = new Size(319, 30);
            txtIdLector.TabIndex = 1;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(34, 107);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(83, 23);
            lblNombres.TabIndex = 2;
            lblNombres.Text = "Nombres";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(149, 103);
            txtNombres.Margin = new Padding(3, 4, 3, 4);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(319, 30);
            txtNombres.TabIndex = 3;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(34, 160);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(85, 23);
            lblApellidos.TabIndex = 4;
            lblApellidos.Text = "Apellidos";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(149, 156);
            txtApellidos.Margin = new Padding(3, 4, 3, 4);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(319, 30);
            txtApellidos.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(34, 213);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(78, 23);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(149, 209);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(319, 30);
            txtTelefono.TabIndex = 7;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(526, 53);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(64, 23);
            lblCorreo.TabIndex = 8;
            lblCorreo.Text = "Correo";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(640, 49);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(319, 30);
            txtCorreo.TabIndex = 9;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Location = new Point(526, 107);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(69, 23);
            lblCarrera.TabIndex = 10;
            lblCarrera.Text = "Carrera";
            // 
            // txtCarrera
            // 
            txtCarrera.Location = new Point(640, 103);
            txtCarrera.Margin = new Padding(3, 4, 3, 4);
            txtCarrera.Name = "txtCarrera";
            txtCarrera.Size = new Size(319, 30);
            txtCarrera.TabIndex = 11;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(526, 160);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(46, 23);
            lblTipo.TabIndex = 12;
            lblTipo.Text = "Tipo";
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(640, 156);
            txtTipo.Margin = new Padding(3, 4, 3, 4);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(319, 30);
            txtTipo.TabIndex = 13;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(23, 320);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(109, 43);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(143, 320);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 43);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(263, 320);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(109, 43);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(383, 320);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 43);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(503, 320);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(109, 43);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // grbUsuariosRegistrados
            // 
            grbUsuariosRegistrados.Controls.Add(dgvUsuarios);
            grbUsuariosRegistrados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grbUsuariosRegistrados.Location = new Point(23, 380);
            grbUsuariosRegistrados.Margin = new Padding(3, 4, 3, 4);
            grbUsuariosRegistrados.Name = "grbUsuariosRegistrados";
            grbUsuariosRegistrados.Padding = new Padding(3, 4, 3, 4);
            grbUsuariosRegistrados.Size = new Size(1006, 347);
            grbUsuariosRegistrados.TabIndex = 6;
            grbUsuariosRegistrados.TabStop = false;
            grbUsuariosRegistrados.Text = "Usuarios registrados";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ColumnHeadersHeight = 29;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            dgvUsuarios.Location = new Point(23, 40);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(960, 280);
            dgvUsuarios.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Cédula";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nombres";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Apellidos";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Telefono";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Correo";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Carrera";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Tipo";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // frmRegistroLector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(1051, 760);
            Controls.Add(grbDatosUsuario);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCerrar);
            Controls.Add(grbUsuariosRegistrados);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRegistroLector";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Lectores";
            grbDatosUsuario.ResumeLayout(false);
            grbDatosUsuario.PerformLayout();
            grbUsuariosRegistrados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}
