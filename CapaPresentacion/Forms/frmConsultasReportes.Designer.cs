using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmConsultasReportes
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

        private TabControl tabConsultas;
        private TabPage tabLibros, tabUsuarios, tabPrestamos;

        // tabLibros
        private GroupBox grbFiltrosLibros;
        private Label lblISBN, lblTitulo, lblCategoria, lblAnio;
        private TextBox txtISBN, txtTitulo, txtAnio;
        private ComboBox cmbCategoria;
        private Button btnBuscar, btnExportar;
        private DataGridView dgvLibros;

        private void InitializeComponent()
        {
            tabConsultas = new TabControl();
            tabLibros = new TabPage();
            grbFiltrosLibros = new GroupBox();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            btnBuscar = new Button();
            btnExportar = new Button();
            dgvLibros = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            tabUsuarios = new TabPage();
            tabPrestamos = new TabPage();
            tabConsultas.SuspendLayout();
            tabLibros.SuspendLayout();
            grbFiltrosLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // tabConsultas
            // 
            tabConsultas.Controls.Add(tabLibros);
            tabConsultas.Controls.Add(tabUsuarios);
            tabConsultas.Controls.Add(tabPrestamos);
            tabConsultas.Location = new Point(23, 27);
            tabConsultas.Margin = new Padding(3, 4, 3, 4);
            tabConsultas.Name = "tabConsultas";
            tabConsultas.SelectedIndex = 0;
            tabConsultas.Size = new Size(800, 627);
            tabConsultas.TabIndex = 0;
            // 
            // tabLibros
            // 
            tabLibros.Controls.Add(grbFiltrosLibros);
            tabLibros.Controls.Add(dgvLibros);
            tabLibros.Location = new Point(4, 29);
            tabLibros.Margin = new Padding(3, 4, 3, 4);
            tabLibros.Name = "tabLibros";
            tabLibros.Size = new Size(792, 594);
            tabLibros.TabIndex = 0;
            tabLibros.Text = "Libros";
            tabLibros.UseVisualStyleBackColor = true;
            // 
            // grbFiltrosLibros
            // 
            grbFiltrosLibros.Controls.Add(lblISBN);
            grbFiltrosLibros.Controls.Add(txtISBN);
            grbFiltrosLibros.Controls.Add(lblTitulo);
            grbFiltrosLibros.Controls.Add(txtTitulo);
            grbFiltrosLibros.Controls.Add(lblCategoria);
            grbFiltrosLibros.Controls.Add(cmbCategoria);
            grbFiltrosLibros.Controls.Add(lblAnio);
            grbFiltrosLibros.Controls.Add(txtAnio);
            grbFiltrosLibros.Controls.Add(btnBuscar);
            grbFiltrosLibros.Controls.Add(btnExportar);
            grbFiltrosLibros.Location = new Point(23, 20);
            grbFiltrosLibros.Margin = new Padding(3, 4, 3, 4);
            grbFiltrosLibros.Name = "grbFiltrosLibros";
            grbFiltrosLibros.Padding = new Padding(3, 4, 3, 4);
            grbFiltrosLibros.Size = new Size(754, 227);
            grbFiltrosLibros.TabIndex = 0;
            grbFiltrosLibros.TabStop = false;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(34, 40);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(41, 20);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(137, 36);
            txtISBN.Margin = new Padding(3, 4, 3, 4);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(228, 27);
            txtISBN.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(457, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(47, 20);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Titulo";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(520, 37);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(228, 27);
            txtTitulo.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(34, 100);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 20);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(137, 96);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(228, 28);
            cmbCategoria.TabIndex = 5;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(457, 100);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(36, 20);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(520, 97);
            txtAnio.Margin = new Padding(3, 4, 3, 4);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(228, 27);
            txtAnio.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(137, 160);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(126, 43);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(297, 160);
            btnExportar.Margin = new Padding(3, 4, 3, 4);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(126, 43);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar";
            btnExportar.Click += btnExportar_Click;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.ColumnHeadersHeight = 29;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvLibros.Location = new Point(23, 260);
            dgvLibros.Margin = new Padding(3, 4, 3, 4);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(754, 333);
            dgvLibros.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ISBN";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Titulo";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Categoria";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Año";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Editorial";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // tabUsuarios
            // 
            tabUsuarios.Location = new Point(4, 29);
            tabUsuarios.Margin = new Padding(3, 4, 3, 4);
            tabUsuarios.Name = "tabUsuarios";
            tabUsuarios.Size = new Size(792, 594);
            tabUsuarios.TabIndex = 1;
            tabUsuarios.Text = "Usuarios";
            tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // tabPrestamos
            // 
            tabPrestamos.Location = new Point(4, 29);
            tabPrestamos.Margin = new Padding(3, 4, 3, 4);
            tabPrestamos.Name = "tabPrestamos";
            tabPrestamos.Size = new Size(792, 594);
            tabPrestamos.TabIndex = 2;
            tabPrestamos.Text = "Prestamos";
            tabPrestamos.UseVisualStyleBackColor = true;
            // 
            // frmConsultasReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(846, 680);
            Controls.Add(tabConsultas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmConsultasReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultas y Reportes";
            tabConsultas.ResumeLayout(false);
            tabLibros.ResumeLayout(false);
            grbFiltrosLibros.ResumeLayout(false);
            grbFiltrosLibros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
