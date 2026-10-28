using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmGestionPrestamos
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

        private GroupBox grbRegistroPrestamos;
        private Label lblUsuarios, lblEjemplar, lblFechaPrestamo, lblDiasCredito, lblFechaDevolucion;
        private Button btnRegistroPrestamo, btnDevolucion;

        private GroupBox grbPrestamo;
        private Label lblPrestamos;
        private ComboBox cmbPrestamos;
        private Button btnBuscar;
        private DataGridView dgvPrestamos;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionPrestamos));
            grbRegistroPrestamos = new GroupBox();
            cmbEjemplar = new ComboBox();
            txtDiasCredito = new TextBox();
            txtIdLector = new TextBox();
            dtpFechaDevolucion = new DateTimePicker();
            btnBuscarLector = new Button();
            dtpFechaPrestamo = new DateTimePicker();
            lblUsuarios = new Label();
            lblEjemplar = new Label();
            lblFechaPrestamo = new Label();
            lblDiasCredito = new Label();
            lblFechaDevolucion = new Label();
            btnRegistroPrestamo = new Button();
            btnDevolucion = new Button();
            grbPrestamo = new GroupBox();
            lblPrestamos = new Label();
            cmbPrestamos = new ComboBox();
            btnBuscar = new Button();
            dgvPrestamos = new DataGridView();
            IDPrestamo = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            grbRegistroPrestamos.SuspendLayout();
            grbPrestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // grbRegistroPrestamos
            // 
            grbRegistroPrestamos.Controls.Add(cmbEjemplar);
            grbRegistroPrestamos.Controls.Add(txtDiasCredito);
            grbRegistroPrestamos.Controls.Add(txtIdLector);
            grbRegistroPrestamos.Controls.Add(dtpFechaDevolucion);
            grbRegistroPrestamos.Controls.Add(btnBuscarLector);
            grbRegistroPrestamos.Controls.Add(dtpFechaPrestamo);
            grbRegistroPrestamos.Controls.Add(lblUsuarios);
            grbRegistroPrestamos.Controls.Add(lblEjemplar);
            grbRegistroPrestamos.Controls.Add(lblFechaPrestamo);
            grbRegistroPrestamos.Controls.Add(lblDiasCredito);
            grbRegistroPrestamos.Controls.Add(lblFechaDevolucion);
            grbRegistroPrestamos.Controls.Add(btnRegistroPrestamo);
            grbRegistroPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grbRegistroPrestamos.Location = new Point(23, 20);
            grbRegistroPrestamos.Margin = new Padding(3, 4, 3, 4);
            grbRegistroPrestamos.Name = "grbRegistroPrestamos";
            grbRegistroPrestamos.Padding = new Padding(3, 4, 3, 4);
            grbRegistroPrestamos.Size = new Size(869, 293);
            grbRegistroPrestamos.TabIndex = 0;
            grbRegistroPrestamos.TabStop = false;
            grbRegistroPrestamos.Text = "Registrar Prestamos";
            // 
            // cmbEjemplar
            // 
            cmbEjemplar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEjemplar.FormattingEnabled = true;
            cmbEjemplar.Location = new Point(127, 120);
            cmbEjemplar.Name = "cmbEjemplar";
            cmbEjemplar.Size = new Size(238, 31);
            cmbEjemplar.TabIndex = 2;
            // 
            // txtDiasCredito
            // 
            txtDiasCredito.Location = new Point(611, 94);
            txtDiasCredito.Name = "txtDiasCredito";
            txtDiasCredito.Size = new Size(221, 30);
            txtDiasCredito.TabIndex = 16;
            // 
            // txtIdLector
            // 
            txtIdLector.Location = new Point(111, 39);
            txtIdLector.Name = "txtIdLector";
            txtIdLector.Size = new Size(254, 30);
            txtIdLector.TabIndex = 14;
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Enabled = false;
            dtpFechaDevolucion.Location = new Point(601, 167);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(250, 30);
            dtpFechaDevolucion.TabIndex = 13;
            // 
            // btnBuscarLector
            // 
            btnBuscarLector.BackColor = Color.FromArgb(0, 192, 192);
            btnBuscarLector.Image = (Image)resources.GetObject("btnBuscarLector.Image");
            btnBuscarLector.Location = new Point(377, 33);
            btnBuscarLector.Name = "btnBuscarLector";
            btnBuscarLector.Size = new Size(48, 41);
            btnBuscarLector.TabIndex = 12;
            btnBuscarLector.UseVisualStyleBackColor = false;
            btnBuscarLector.Click += btnBuscarLector_Click;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(582, 39);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(250, 30);
            dtpFechaPrestamo.TabIndex = 4;
            // 
            // lblUsuarios
            // 
            lblUsuarios.AutoSize = true;
            lblUsuarios.Location = new Point(34, 46);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(71, 23);
            lblUsuarios.TabIndex = 0;
            lblUsuarios.Text = "Lector: ";
            // 
            // lblEjemplar
            // 
            lblEjemplar.AutoSize = true;
            lblEjemplar.Location = new Point(34, 120);
            lblEjemplar.Name = "lblEjemplar";
            lblEjemplar.Size = new Size(87, 23);
            lblEjemplar.TabIndex = 2;
            lblEjemplar.Text = "Ejemplar:";
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(491, 27);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(90, 46);
            lblFechaPrestamo.TabIndex = 4;
            lblFechaPrestamo.Text = "Fecha\r\nPrestamo:";
            // 
            // lblDiasCredito
            // 
            lblDiasCredito.AutoSize = true;
            lblDiasCredito.Location = new Point(491, 101);
            lblDiasCredito.Name = "lblDiasCredito";
            lblDiasCredito.Size = new Size(114, 23);
            lblDiasCredito.TabIndex = 6;
            lblDiasCredito.Text = "Dias Credito:";
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Location = new Point(491, 151);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Size = new Size(104, 46);
            lblFechaDevolucion.TabIndex = 8;
            lblFechaDevolucion.Text = "Fecha\r\nDevolucion:";
            // 
            // btnRegistroPrestamo
            // 
            btnRegistroPrestamo.Location = new Point(34, 220);
            btnRegistroPrestamo.Margin = new Padding(3, 4, 3, 4);
            btnRegistroPrestamo.Name = "btnRegistroPrestamo";
            btnRegistroPrestamo.Size = new Size(194, 45);
            btnRegistroPrestamo.TabIndex = 10;
            btnRegistroPrestamo.Text = "Registrar Prestamo";
            btnRegistroPrestamo.Click += btnRegistroPrestamo_Click;
            // 
            // btnDevolucion
            // 
            btnDevolucion.Location = new Point(539, 60);
            btnDevolucion.Margin = new Padding(3, 4, 3, 4);
            btnDevolucion.Name = "btnDevolucion";
            btnDevolucion.Size = new Size(217, 45);
            btnDevolucion.TabIndex = 11;
            btnDevolucion.Text = "Marcar como devuelto";
            btnDevolucion.Click += btnDevolucion_Click;
            // 
            // grbPrestamo
            // 
            grbPrestamo.Controls.Add(lblPrestamos);
            grbPrestamo.Controls.Add(cmbPrestamos);
            grbPrestamo.Controls.Add(btnBuscar);
            grbPrestamo.Controls.Add(dgvPrestamos);
            grbPrestamo.Controls.Add(btnDevolucion);
            grbPrestamo.Location = new Point(23, 327);
            grbPrestamo.Margin = new Padding(3, 4, 3, 4);
            grbPrestamo.Name = "grbPrestamo";
            grbPrestamo.Padding = new Padding(3, 4, 3, 4);
            grbPrestamo.Size = new Size(869, 440);
            grbPrestamo.TabIndex = 1;
            grbPrestamo.TabStop = false;
            // 
            // lblPrestamos
            // 
            lblPrestamos.AutoSize = true;
            lblPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrestamos.Location = new Point(23, 40);
            lblPrestamos.Name = "lblPrestamos";
            lblPrestamos.Size = new Size(142, 23);
            lblPrestamos.TabIndex = 0;
            lblPrestamos.Text = "Buscar Préstamo";
            // 
            // cmbPrestamos
            // 
            cmbPrestamos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrestamos.Location = new Point(23, 73);
            cmbPrestamos.Margin = new Padding(3, 4, 3, 4);
            cmbPrestamos.Name = "cmbPrestamos";
            cmbPrestamos.Size = new Size(342, 28);
            cmbPrestamos.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(377, 72);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(103, 33);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.ColumnHeadersHeight = 29;
            dgvPrestamos.Columns.AddRange(new DataGridViewColumn[] { IDPrestamo, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvPrestamos.Location = new Point(23, 120);
            dgvPrestamos.Margin = new Padding(3, 4, 3, 4);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.RowHeadersWidth = 51;
            dgvPrestamos.Size = new Size(823, 293);
            dgvPrestamos.TabIndex = 3;
            // 
            // IDPrestamo
            // 
            IDPrestamo.HeaderText = "ID Prestamo";
            IDPrestamo.MinimumWidth = 6;
            IDPrestamo.Name = "IDPrestamo";
            IDPrestamo.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Lector";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Libros";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "F. Prestamo";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "F. Devolucion";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Estado";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // frmGestionPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(914, 800);
            Controls.Add(grbRegistroPrestamos);
            Controls.Add(grbPrestamo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmGestionPrestamos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Prestamos";
            grbRegistroPrestamos.ResumeLayout(false);
            grbRegistroPrestamos.PerformLayout();
            grbPrestamo.ResumeLayout(false);
            grbPrestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn IDPrestamo;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Button btnBuscarLector;
        private DateTimePicker dtpFechaPrestamo;
        private DateTimePicker dtpFechaDevolucion;
        private TextBox txtIdLector;
        private TextBox txtDiasCredito;
        private ComboBox cmbEjemplar;
    }
}
