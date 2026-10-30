using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmGestionMultas
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

        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvMultas;

        private void InitializeComponent()
        {
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvMultas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdMultaSeleccionada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMarcarPagada = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(178, 33);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(470, 22);
            this.txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(686, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(114, 28);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // dgvMultas
            // 
            this.dgvMultas.AllowUserToAddRows = false;
            this.dgvMultas.ColumnHeadersHeight = 29;
            this.dgvMultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvMultas.Location = new System.Drawing.Point(34, 80);
            this.dgvMultas.Name = "dgvMultas";
            this.dgvMultas.RowHeadersWidth = 51;
            this.dgvMultas.Size = new System.Drawing.Size(773, 278);
            this.dgvMultas.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "ID Multa";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 84;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID Prestamo";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Lector";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Monto (C$)";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Fecha Generación";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID Multa:";
            // 
            // txtIdMultaSeleccionada
            // 
            this.txtIdMultaSeleccionada.Location = new System.Drawing.Point(121, 391);
            this.txtIdMultaSeleccionada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdMultaSeleccionada.Multiline = true;
            this.txtIdMultaSeleccionada.Name = "txtIdMultaSeleccionada";
            this.txtIdMultaSeleccionada.ReadOnly = true;
            this.txtIdMultaSeleccionada.Size = new System.Drawing.Size(163, 28);
            this.txtIdMultaSeleccionada.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lector / Id Multa:";
            // 
            // btnMarcarPagada
            // 
            this.btnMarcarPagada.Location = new System.Drawing.Point(335, 391);
            this.btnMarcarPagada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMarcarPagada.Name = "btnMarcarPagada";
            this.btnMarcarPagada.Size = new System.Drawing.Size(221, 34);
            this.btnMarcarPagada.TabIndex = 9;
            this.btnMarcarPagada.Text = "Marcar como Pagada";
            this.btnMarcarPagada.UseVisualStyleBackColor = true;
            this.btnMarcarPagada.Click += new System.EventHandler(this.btnMarcarPagada_Click);
            // 
            // frmGestionMultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(834, 458);
            this.Controls.Add(this.btnMarcarPagada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdMultaSeleccionada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvMultas);
            this.Name = "frmGestionMultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Multas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Label label1;
        private TextBox txtIdMultaSeleccionada;
        private Label label2;
        private Button btnMarcarPagada;
    }
}
