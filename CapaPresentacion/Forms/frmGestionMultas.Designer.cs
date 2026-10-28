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
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvMultas = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtIdMultaSeleccionada = new TextBox();
            label2 = new Label();
            btnMarcarPagada = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMultas).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(178, 41);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(470, 27);
            txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(686, 37);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(114, 35);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvMultas
            // 
            dgvMultas.AllowUserToAddRows = false;
            dgvMultas.ColumnHeadersHeight = 29;
            dgvMultas.Columns.AddRange(new DataGridViewColumn[] { Column1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvMultas.Location = new Point(34, 100);
            dgvMultas.Margin = new Padding(3, 4, 3, 4);
            dgvMultas.Name = "dgvMultas";
            dgvMultas.RowHeadersWidth = 51;
            dgvMultas.Size = new Size(773, 347);
            dgvMultas.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column1.HeaderText = "ID Multa";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 95;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID Prestamo";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Lector";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Monto (C$)";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Estado";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Fecha Generación";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 489);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 6;
            label1.Text = "ID Multa:";
            // 
            // txtIdMultaSeleccionada
            // 
            txtIdMultaSeleccionada.Location = new Point(121, 489);
            txtIdMultaSeleccionada.Multiline = true;
            txtIdMultaSeleccionada.Name = "txtIdMultaSeleccionada";
            txtIdMultaSeleccionada.ReadOnly = true;
            txtIdMultaSeleccionada.Size = new Size(163, 34);
            txtIdMultaSeleccionada.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 44);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 8;
            label2.Text = "Lector / Id Multa:";
            // 
            // btnMarcarPagada
            // 
            btnMarcarPagada.Location = new Point(335, 489);
            btnMarcarPagada.Name = "btnMarcarPagada";
            btnMarcarPagada.Size = new Size(221, 42);
            btnMarcarPagada.TabIndex = 9;
            btnMarcarPagada.Text = "Marcar como Pagada";
            btnMarcarPagada.UseVisualStyleBackColor = true;
            btnMarcarPagada.Click += btnMarcarPagada_Click_1;
            // 
            // frmGestionMultas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(834, 573);
            Controls.Add(btnMarcarPagada);
            Controls.Add(label2);
            Controls.Add(txtIdMultaSeleccionada);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvMultas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmGestionMultas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Multas";
            ((System.ComponentModel.ISupportInitialize)dgvMultas).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
