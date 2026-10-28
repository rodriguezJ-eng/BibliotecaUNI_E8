using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmRegistroLibro
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

        private void InitializeComponent()
        {
            lblLibrosRegistrados = new Label();
            tabLibro = new TabControl();
            tabDatosGenerales = new TabPage();
            groupBox2 = new GroupBox();
            txtEdicion = new TextBox();
            label4 = new Label();
            cmbCategoria = new ComboBox();
            cmbAutor = new ComboBox();
            txtEditorial = new TextBox();
            lblEditorial = new Label();
            txtAnio = new TextBox();
            label1 = new Label();
            lblAnio = new Label();
            lblISBN = new Label();
            lblCategoria = new Label();
            txtTitulo = new TextBox();
            txtISBN = new TextBox();
            lblTitulo = new Label();
            dgvLibros = new DataGridView();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            tabAutores = new TabPage();
            btnGuardarAutor = new Button();
            btnEditarAutor = new Button();
            btnEliminarAutor = new Button();
            label3 = new Label();
            btnNuevoAutor = new Button();
            dgvRegistroAutores = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            lblIdAutor = new Label();
            txtApellidoAutor = new TextBox();
            lblNombreAutor = new Label();
            txtIdAutor = new TextBox();
            txtNombreAutor = new TextBox();
            label2 = new Label();
            lblRolAutor = new Label();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            tabLibro.SuspendLayout();
            tabDatosGenerales.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            tabAutores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroAutores).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblLibrosRegistrados
            // 
            lblLibrosRegistrados.AutoSize = true;
            lblLibrosRegistrados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLibrosRegistrados.Location = new Point(9, 353);
            lblLibrosRegistrados.Name = "lblLibrosRegistrados";
            lblLibrosRegistrados.Size = new Size(154, 23);
            lblLibrosRegistrados.TabIndex = 5;
            lblLibrosRegistrados.Text = "Libros registrados";
            // 
            // tabLibro
            // 
            tabLibro.Controls.Add(tabDatosGenerales);
            tabLibro.Controls.Add(tabAutores);
            tabLibro.Location = new Point(12, 22);
            tabLibro.Margin = new Padding(3, 4, 3, 4);
            tabLibro.Name = "tabLibro";
            tabLibro.SelectedIndex = 0;
            tabLibro.Size = new Size(845, 687);
            tabLibro.TabIndex = 0;
            // 
            // tabDatosGenerales
            // 
            tabDatosGenerales.Controls.Add(groupBox2);
            tabDatosGenerales.Controls.Add(lblLibrosRegistrados);
            tabDatosGenerales.Controls.Add(dgvLibros);
            tabDatosGenerales.Controls.Add(btnEliminar);
            tabDatosGenerales.Controls.Add(btnEditar);
            tabDatosGenerales.Controls.Add(btnGuardar);
            tabDatosGenerales.Controls.Add(btnNuevo);
            tabDatosGenerales.Location = new Point(4, 29);
            tabDatosGenerales.Margin = new Padding(3, 4, 3, 4);
            tabDatosGenerales.Name = "tabDatosGenerales";
            tabDatosGenerales.Size = new Size(837, 654);
            tabDatosGenerales.TabIndex = 0;
            tabDatosGenerales.Text = "Datos generales";
            tabDatosGenerales.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtEdicion);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cmbCategoria);
            groupBox2.Controls.Add(cmbAutor);
            groupBox2.Controls.Add(txtEditorial);
            groupBox2.Controls.Add(lblEditorial);
            groupBox2.Controls.Add(txtAnio);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(lblAnio);
            groupBox2.Controls.Add(lblISBN);
            groupBox2.Controls.Add(lblCategoria);
            groupBox2.Controls.Add(txtTitulo);
            groupBox2.Controls.Add(txtISBN);
            groupBox2.Controls.Add(lblTitulo);
            groupBox2.Location = new Point(19, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(793, 254);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Libro";
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(486, 150);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(125, 27);
            txtEdicion.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(403, 150);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 12;
            label4.Text = "Edición: ";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(132, 102);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(228, 28);
            cmbCategoria.TabIndex = 5;
            // 
            // cmbAutor
            // 
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutor.Location = new Point(132, 214);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(228, 28);
            cmbAutor.TabIndex = 11;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(132, 161);
            txtEditorial.Margin = new Padding(3, 4, 3, 4);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(228, 27);
            txtEditorial.TabIndex = 9;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(29, 161);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(65, 20);
            lblEditorial.TabIndex = 8;
            lblEditorial.Text = "Editorial";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(486, 102);
            txtAnio.Margin = new Padding(3, 4, 3, 4);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(114, 27);
            txtAnio.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 222);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 10;
            label1.Text = "Autor: ";
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(406, 106);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(36, 20);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(29, 55);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(41, 20);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "ISBN";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(29, 106);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 20);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoria";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(486, 51);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(262, 27);
            txtTitulo.TabIndex = 3;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(132, 51);
            txtISBN.Margin = new Padding(3, 4, 3, 4);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(228, 27);
            txtISBN.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(406, 55);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(47, 20);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Titulo";
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.ColumnHeadersHeight = 29;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Column1, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, Column5, dataGridViewTextBoxColumn5 });
            dgvLibros.Location = new Point(3, 392);
            dgvLibros.Margin = new Padding(3, 4, 3, 4);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(834, 247);
            dgvLibros.TabIndex = 6;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(134, 281);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 43);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(249, 281);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(109, 43);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(364, 281);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 43);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(19, 281);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(109, 43);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // tabAutores
            // 
            tabAutores.Controls.Add(btnGuardarAutor);
            tabAutores.Controls.Add(btnEditarAutor);
            tabAutores.Controls.Add(btnEliminarAutor);
            tabAutores.Controls.Add(label3);
            tabAutores.Controls.Add(btnNuevoAutor);
            tabAutores.Controls.Add(dgvRegistroAutores);
            tabAutores.Controls.Add(groupBox1);
            tabAutores.Controls.Add(lblRolAutor);
            tabAutores.Location = new Point(4, 29);
            tabAutores.Margin = new Padding(3, 4, 3, 4);
            tabAutores.Name = "tabAutores";
            tabAutores.Size = new Size(837, 654);
            tabAutores.TabIndex = 1;
            tabAutores.Text = "Autores";
            tabAutores.UseVisualStyleBackColor = true;
            // 
            // btnGuardarAutor
            // 
            btnGuardarAutor.Location = new Point(366, 255);
            btnGuardarAutor.Name = "btnGuardarAutor";
            btnGuardarAutor.Size = new Size(111, 39);
            btnGuardarAutor.TabIndex = 13;
            btnGuardarAutor.Text = "Guardar";
            btnGuardarAutor.UseVisualStyleBackColor = true;
            btnGuardarAutor.Click += btnGuardarAutor_Click;
            // 
            // btnEditarAutor
            // 
            btnEditarAutor.Location = new Point(249, 255);
            btnEditarAutor.Name = "btnEditarAutor";
            btnEditarAutor.Size = new Size(111, 39);
            btnEditarAutor.TabIndex = 12;
            btnEditarAutor.Text = "Editar";
            btnEditarAutor.UseVisualStyleBackColor = true;
            btnEditarAutor.Click += btnEditarAutor_Click;
            // 
            // btnEliminarAutor
            // 
            btnEliminarAutor.Location = new Point(132, 255);
            btnEliminarAutor.Name = "btnEliminarAutor";
            btnEliminarAutor.Size = new Size(111, 39);
            btnEliminarAutor.TabIndex = 11;
            btnEliminarAutor.Text = "Eliminar";
            btnEliminarAutor.UseVisualStyleBackColor = true;
            btnEliminarAutor.Click += btnEliminarAutor_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 319);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 10;
            label3.Text = "Autores Registrados";
            // 
            // btnNuevoAutor
            // 
            btnNuevoAutor.Location = new Point(15, 255);
            btnNuevoAutor.Name = "btnNuevoAutor";
            btnNuevoAutor.Size = new Size(111, 39);
            btnNuevoAutor.TabIndex = 9;
            btnNuevoAutor.Text = "Nuevo";
            btnNuevoAutor.UseVisualStyleBackColor = true;
            btnNuevoAutor.Click += btnNuevoAutor_Click_1;
            // 
            // dgvRegistroAutores
            // 
            dgvRegistroAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistroAutores.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column4 });
            dgvRegistroAutores.Location = new Point(15, 358);
            dgvRegistroAutores.Name = "dgvRegistroAutores";
            dgvRegistroAutores.RowHeadersWidth = 51;
            dgvRegistroAutores.Size = new Size(808, 275);
            dgvRegistroAutores.TabIndex = 8;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "ID Autor";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Nombre Autor";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Apellido Autor";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblIdAutor);
            groupBox1.Controls.Add(txtApellidoAutor);
            groupBox1.Controls.Add(lblNombreAutor);
            groupBox1.Controls.Add(txtIdAutor);
            groupBox1.Controls.Add(txtNombreAutor);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(798, 209);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Autor";
            // 
            // lblIdAutor
            // 
            lblIdAutor.AutoSize = true;
            lblIdAutor.Location = new Point(19, 42);
            lblIdAutor.Name = "lblIdAutor";
            lblIdAutor.Size = new Size(91, 20);
            lblIdAutor.TabIndex = 0;
            lblIdAutor.Text = "Id del Autor:";
            // 
            // txtApellidoAutor
            // 
            txtApellidoAutor.Location = new Point(161, 139);
            txtApellidoAutor.Margin = new Padding(3, 4, 3, 4);
            txtApellidoAutor.Name = "txtApellidoAutor";
            txtApellidoAutor.Size = new Size(253, 27);
            txtApellidoAutor.TabIndex = 6;
            // 
            // lblNombreAutor
            // 
            lblNombreAutor.AutoSize = true;
            lblNombreAutor.Location = new Point(19, 93);
            lblNombreAutor.Name = "lblNombreAutor";
            lblNombreAutor.Size = new Size(133, 20);
            lblNombreAutor.TabIndex = 2;
            lblNombreAutor.Text = "Nombre del Autor:";
            // 
            // txtIdAutor
            // 
            txtIdAutor.Location = new Point(129, 42);
            txtIdAutor.Margin = new Padding(3, 4, 3, 4);
            txtIdAutor.Name = "txtIdAutor";
            txtIdAutor.Size = new Size(285, 27);
            txtIdAutor.TabIndex = 1;
            // 
            // txtNombreAutor
            // 
            txtNombreAutor.Location = new Point(161, 93);
            txtNombreAutor.Margin = new Padding(3, 4, 3, 4);
            txtNombreAutor.Name = "txtNombreAutor";
            txtNombreAutor.Size = new Size(253, 27);
            txtNombreAutor.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 139);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 5;
            label2.Text = "Apellido del autor:";
            // 
            // lblRolAutor
            // 
            lblRolAutor.AutoSize = true;
            lblRolAutor.Location = new Point(34, 147);
            lblRolAutor.Name = "lblRolAutor";
            lblRolAutor.Size = new Size(0, 20);
            lblRolAutor.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn1.HeaderText = "ISBN";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Titulo";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Autor";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
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
            // Column5
            // 
            Column5.HeaderText = "Edición";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Editorial";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // frmRegistroLibro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(869, 731);
            Controls.Add(tabLibro);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRegistroLibro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro Libro";
            tabLibro.ResumeLayout(false);
            tabDatosGenerales.ResumeLayout(false);
            tabDatosGenerales.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            tabAutores.ResumeLayout(false);
            tabAutores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroAutores).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
        private Label lblLibrosRegistrados;
        private TabControl tabLibro;
        private TabPage tabDatosGenerales;
        private ComboBox cmbAutor;
        private DataGridView dgvLibros;
        private Label label1;
        private Label lblISBN;
        private Button btnEliminar;
        private TextBox txtISBN;
        private Button btnEditar;
        private Label lblTitulo;
        private Button btnGuardar;
        private TextBox txtTitulo;
        private Button btnNuevo;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblAnio;
        private TextBox txtAnio;
        private Label lblEditorial;
        private TextBox txtEditorial;
        private TabPage tabAutores;
        private GroupBox groupBox1;
        private Label lblIdAutor;
        private TextBox txtApellidoAutor;
        private Label lblNombreAutor;
        private TextBox txtIdAutor;
        private TextBox txtNombreAutor;
        private Label label2;
        private Label lblRolAutor;
        private Button btnNuevoAutor;
        private DataGridView dgvRegistroAutores;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label label3;
        private Button btnGuardarAutor;
        private Button btnEditarAutor;
        private Button btnEliminarAutor;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox txtEdicion;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
