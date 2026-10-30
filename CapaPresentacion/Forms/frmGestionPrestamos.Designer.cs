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
            this.grbRegistroPrestamos = new System.Windows.Forms.GroupBox();
            this.cmbEjemplar = new System.Windows.Forms.ComboBox();
            this.txtDiasCredito = new System.Windows.Forms.TextBox();
            this.txtIdLector = new System.Windows.Forms.TextBox();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarLector = new System.Windows.Forms.Button();
            this.dtpFechaPrestamo = new System.Windows.Forms.DateTimePicker();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lblEjemplar = new System.Windows.Forms.Label();
            this.lblFechaPrestamo = new System.Windows.Forms.Label();
            this.lblDiasCredito = new System.Windows.Forms.Label();
            this.lblFechaDevolucion = new System.Windows.Forms.Label();
            this.btnRegistroPrestamo = new System.Windows.Forms.Button();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.grbPrestamo = new System.Windows.Forms.GroupBox();
            this.lblPrestamos = new System.Windows.Forms.Label();
            this.cmbPrestamos = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.IDPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbRegistroPrestamos.SuspendLayout();
            this.grbPrestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // grbRegistroPrestamos
            // 
            this.grbRegistroPrestamos.Controls.Add(this.cmbEjemplar);
            this.grbRegistroPrestamos.Controls.Add(this.txtDiasCredito);
            this.grbRegistroPrestamos.Controls.Add(this.txtIdLector);
            this.grbRegistroPrestamos.Controls.Add(this.dtpFechaDevolucion);
            this.grbRegistroPrestamos.Controls.Add(this.btnBuscarLector);
            this.grbRegistroPrestamos.Controls.Add(this.dtpFechaPrestamo);
            this.grbRegistroPrestamos.Controls.Add(this.lblUsuarios);
            this.grbRegistroPrestamos.Controls.Add(this.lblEjemplar);
            this.grbRegistroPrestamos.Controls.Add(this.lblFechaPrestamo);
            this.grbRegistroPrestamos.Controls.Add(this.lblDiasCredito);
            this.grbRegistroPrestamos.Controls.Add(this.lblFechaDevolucion);
            this.grbRegistroPrestamos.Controls.Add(this.btnRegistroPrestamo);
            this.grbRegistroPrestamos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grbRegistroPrestamos.Location = new System.Drawing.Point(23, 16);
            this.grbRegistroPrestamos.Name = "grbRegistroPrestamos";
            this.grbRegistroPrestamos.Size = new System.Drawing.Size(869, 234);
            this.grbRegistroPrestamos.TabIndex = 0;
            this.grbRegistroPrestamos.TabStop = false;
            this.grbRegistroPrestamos.Text = "Registrar Prestamos";
            // 
            // cmbEjemplar
            // 
            this.cmbEjemplar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEjemplar.FormattingEnabled = true;
            this.cmbEjemplar.Location = new System.Drawing.Point(127, 96);
            this.cmbEjemplar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEjemplar.Name = "cmbEjemplar";
            this.cmbEjemplar.Size = new System.Drawing.Size(238, 31);
            this.cmbEjemplar.TabIndex = 2;
            this.cmbEjemplar.SelectedIndexChanged += new System.EventHandler(this.cmbEjemplar_SelectedIndexChanged);
            // 
            // txtDiasCredito
            // 
            this.txtDiasCredito.Location = new System.Drawing.Point(611, 75);
            this.txtDiasCredito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiasCredito.Name = "txtDiasCredito";
            this.txtDiasCredito.Size = new System.Drawing.Size(221, 30);
            this.txtDiasCredito.TabIndex = 16;
            // 
            // txtIdLector
            // 
            this.txtIdLector.Location = new System.Drawing.Point(111, 31);
            this.txtIdLector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdLector.Name = "txtIdLector";
            this.txtIdLector.Size = new System.Drawing.Size(254, 30);
            this.txtIdLector.TabIndex = 14;
            // 
            // dtpFechaDevolucion
            // 
            this.dtpFechaDevolucion.Enabled = false;
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(601, 134);
            this.dtpFechaDevolucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new System.Drawing.Size(250, 30);
            this.dtpFechaDevolucion.TabIndex = 13;
            this.dtpFechaDevolucion.ValueChanged += new System.EventHandler(this.dtpFechaDevolucion_ValueChanged);
            // 
            // btnBuscarLector
            // 
            this.btnBuscarLector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuscarLector.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarLector.Image")));
            this.btnBuscarLector.Location = new System.Drawing.Point(377, 26);
            this.btnBuscarLector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarLector.Name = "btnBuscarLector";
            this.btnBuscarLector.Size = new System.Drawing.Size(48, 33);
            this.btnBuscarLector.TabIndex = 12;
            this.btnBuscarLector.UseVisualStyleBackColor = false;
            this.btnBuscarLector.Click += new System.EventHandler(this.btnBuscarLector_Click);
            // 
            // dtpFechaPrestamo
            // 
            this.dtpFechaPrestamo.Location = new System.Drawing.Point(582, 31);
            this.dtpFechaPrestamo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            this.dtpFechaPrestamo.Size = new System.Drawing.Size(250, 30);
            this.dtpFechaPrestamo.TabIndex = 4;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(34, 37);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(71, 23);
            this.lblUsuarios.TabIndex = 0;
            this.lblUsuarios.Text = "Lector: ";
            // 
            // lblEjemplar
            // 
            this.lblEjemplar.AutoSize = true;
            this.lblEjemplar.Location = new System.Drawing.Point(34, 96);
            this.lblEjemplar.Name = "lblEjemplar";
            this.lblEjemplar.Size = new System.Drawing.Size(87, 23);
            this.lblEjemplar.TabIndex = 2;
            this.lblEjemplar.Text = "Ejemplar:";
            // 
            // lblFechaPrestamo
            // 
            this.lblFechaPrestamo.AutoSize = true;
            this.lblFechaPrestamo.Location = new System.Drawing.Point(491, 22);
            this.lblFechaPrestamo.Name = "lblFechaPrestamo";
            this.lblFechaPrestamo.Size = new System.Drawing.Size(90, 46);
            this.lblFechaPrestamo.TabIndex = 4;
            this.lblFechaPrestamo.Text = "Fecha\r\nPrestamo:";
            // 
            // lblDiasCredito
            // 
            this.lblDiasCredito.AutoSize = true;
            this.lblDiasCredito.Location = new System.Drawing.Point(491, 81);
            this.lblDiasCredito.Name = "lblDiasCredito";
            this.lblDiasCredito.Size = new System.Drawing.Size(114, 23);
            this.lblDiasCredito.TabIndex = 6;
            this.lblDiasCredito.Text = "Dias Credito:";
            // 
            // lblFechaDevolucion
            // 
            this.lblFechaDevolucion.AutoSize = true;
            this.lblFechaDevolucion.Location = new System.Drawing.Point(491, 121);
            this.lblFechaDevolucion.Name = "lblFechaDevolucion";
            this.lblFechaDevolucion.Size = new System.Drawing.Size(104, 46);
            this.lblFechaDevolucion.TabIndex = 8;
            this.lblFechaDevolucion.Text = "Fecha\r\nDevolucion:";
            // 
            // btnRegistroPrestamo
            // 
            this.btnRegistroPrestamo.Location = new System.Drawing.Point(34, 176);
            this.btnRegistroPrestamo.Name = "btnRegistroPrestamo";
            this.btnRegistroPrestamo.Size = new System.Drawing.Size(194, 36);
            this.btnRegistroPrestamo.TabIndex = 10;
            this.btnRegistroPrestamo.Text = "Registrar Prestamo";
            this.btnRegistroPrestamo.Click += new System.EventHandler(this.btnRegistroPrestamo_Click);
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Location = new System.Drawing.Point(539, 48);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(217, 36);
            this.btnDevolucion.TabIndex = 11;
            this.btnDevolucion.Text = "Marcar como devuelto";
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // grbPrestamo
            // 
            this.grbPrestamo.Controls.Add(this.lblPrestamos);
            this.grbPrestamo.Controls.Add(this.cmbPrestamos);
            this.grbPrestamo.Controls.Add(this.btnBuscar);
            this.grbPrestamo.Controls.Add(this.dgvPrestamos);
            this.grbPrestamo.Controls.Add(this.btnDevolucion);
            this.grbPrestamo.Location = new System.Drawing.Point(23, 262);
            this.grbPrestamo.Name = "grbPrestamo";
            this.grbPrestamo.Size = new System.Drawing.Size(869, 352);
            this.grbPrestamo.TabIndex = 1;
            this.grbPrestamo.TabStop = false;
            // 
            // lblPrestamos
            // 
            this.lblPrestamos.AutoSize = true;
            this.lblPrestamos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrestamos.Location = new System.Drawing.Point(23, 32);
            this.lblPrestamos.Name = "lblPrestamos";
            this.lblPrestamos.Size = new System.Drawing.Size(142, 23);
            this.lblPrestamos.TabIndex = 0;
            this.lblPrestamos.Text = "Buscar Préstamo";
            // 
            // cmbPrestamos
            // 
            this.cmbPrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrestamos.Location = new System.Drawing.Point(23, 58);
            this.cmbPrestamos.Name = "cmbPrestamos";
            this.cmbPrestamos.Size = new System.Drawing.Size(342, 24);
            this.cmbPrestamos.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(377, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(103, 26);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.ColumnHeadersHeight = 29;
            this.dgvPrestamos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPrestamo,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvPrestamos.Location = new System.Drawing.Point(23, 96);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.RowHeadersWidth = 51;
            this.dgvPrestamos.Size = new System.Drawing.Size(823, 234);
            this.dgvPrestamos.TabIndex = 3;
            // 
            // IDPrestamo
            // 
            this.IDPrestamo.HeaderText = "ID Prestamo";
            this.IDPrestamo.MinimumWidth = 6;
            this.IDPrestamo.Name = "IDPrestamo";
            this.IDPrestamo.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Lector";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Libros";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "F. Prestamo";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "F. Devolucion";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // frmGestionPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(914, 640);
            this.Controls.Add(this.grbRegistroPrestamos);
            this.Controls.Add(this.grbPrestamo);
            this.Name = "frmGestionPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Prestamos";
            this.grbRegistroPrestamos.ResumeLayout(false);
            this.grbRegistroPrestamos.PerformLayout();
            this.grbPrestamo.ResumeLayout(false);
            this.grbPrestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.ResumeLayout(false);

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
