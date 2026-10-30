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
            this.lblLibrosRegistrados = new System.Windows.Forms.Label();
            this.tabLibro = new System.Windows.Forms.TabControl();
            this.tabDatosGenerales = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEdicion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbAutor = new System.Windows.Forms.ComboBox();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tabAutores = new System.Windows.Forms.TabPage();
            this.btnGuardarAutor = new System.Windows.Forms.Button();
            this.btnEditarAutor = new System.Windows.Forms.Button();
            this.btnEliminarAutor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNuevoAutor = new System.Windows.Forms.Button();
            this.dgvRegistroAutores = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdAutor = new System.Windows.Forms.Label();
            this.txtApellidoAutor = new System.Windows.Forms.TextBox();
            this.lblNombreAutor = new System.Windows.Forms.Label();
            this.txtIdAutor = new System.Windows.Forms.TextBox();
            this.txtNombreAutor = new System.Windows.Forms.TextBox();
            this.lblNacionalidadAutor = new System.Windows.Forms.Label();
            this.txtNacionalidadAutor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRolAutor = new System.Windows.Forms.Label();
            this.tabLibro.SuspendLayout();
            this.tabDatosGenerales.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.tabAutores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroAutores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLibrosRegistrados
            // 
            this.lblLibrosRegistrados.AutoSize = true;
            this.lblLibrosRegistrados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLibrosRegistrados.Location = new System.Drawing.Point(9, 282);
            this.lblLibrosRegistrados.Name = "lblLibrosRegistrados";
            this.lblLibrosRegistrados.Size = new System.Drawing.Size(154, 23);
            this.lblLibrosRegistrados.TabIndex = 5;
            this.lblLibrosRegistrados.Text = "Libros registrados";
            // 
            // tabLibro
            // 
            this.tabLibro.Controls.Add(this.tabDatosGenerales);
            this.tabLibro.Controls.Add(this.tabAutores);
            this.tabLibro.Location = new System.Drawing.Point(12, 18);
            this.tabLibro.Name = "tabLibro";
            this.tabLibro.SelectedIndex = 0;
            this.tabLibro.Size = new System.Drawing.Size(845, 577);
            this.tabLibro.TabIndex = 0;
            // 
            // tabDatosGenerales
            // 
            this.tabDatosGenerales.Controls.Add(this.groupBox2);
            this.tabDatosGenerales.Controls.Add(this.lblLibrosRegistrados);
            this.tabDatosGenerales.Controls.Add(this.dgvLibros);
            this.tabDatosGenerales.Controls.Add(this.btnEliminar);
            this.tabDatosGenerales.Controls.Add(this.btnEditar);
            this.tabDatosGenerales.Controls.Add(this.btnGuardar);
            this.tabDatosGenerales.Controls.Add(this.btnNuevo);
            this.tabDatosGenerales.Location = new System.Drawing.Point(4, 25);
            this.tabDatosGenerales.Name = "tabDatosGenerales";
            this.tabDatosGenerales.Size = new System.Drawing.Size(837, 548);
            this.tabDatosGenerales.TabIndex = 0;
            this.tabDatosGenerales.Text = "Datos generales";
            this.tabDatosGenerales.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEdicion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbCategoria);
            this.groupBox2.Controls.Add(this.cmbAutor);
            this.groupBox2.Controls.Add(this.txtEditorial);
            this.groupBox2.Controls.Add(this.lblEditorial);
            this.groupBox2.Controls.Add(this.txtAnio);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblAnio);
            this.groupBox2.Controls.Add(this.lblISBN);
            this.groupBox2.Controls.Add(this.lblCategoria);
            this.groupBox2.Controls.Add(this.txtTitulo);
            this.groupBox2.Controls.Add(this.txtISBN);
            this.groupBox2.Controls.Add(this.lblTitulo);
            this.groupBox2.Location = new System.Drawing.Point(19, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(793, 203);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Libro";
            // 
            // txtEdicion
            // 
            this.txtEdicion.Location = new System.Drawing.Point(486, 120);
            this.txtEdicion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEdicion.Name = "txtEdicion";
            this.txtEdicion.Size = new System.Drawing.Size(125, 22);
            this.txtEdicion.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Edición:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Location = new System.Drawing.Point(132, 82);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(228, 24);
            this.cmbCategoria.TabIndex = 5;
            // 
            // cmbAutor
            // 
            this.cmbAutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutor.Location = new System.Drawing.Point(132, 171);
            this.cmbAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAutor.Name = "cmbAutor";
            this.cmbAutor.Size = new System.Drawing.Size(228, 24);
            this.cmbAutor.TabIndex = 11;
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(132, 129);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(228, 22);
            this.txtEditorial.TabIndex = 9;
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Location = new System.Drawing.Point(29, 129);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(56, 16);
            this.lblEditorial.TabIndex = 8;
            this.lblEditorial.Text = "Editorial";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(486, 82);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(114, 22);
            this.txtAnio.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Autor: ";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(406, 85);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(31, 16);
            this.lblAnio.TabIndex = 6;
            this.lblAnio.Text = "Año";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(29, 44);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(38, 16);
            this.lblISBN.TabIndex = 0;
            this.lblISBN.Text = "ISBN";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(29, 85);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(66, 16);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(486, 41);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(262, 22);
            this.txtTitulo.TabIndex = 3;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(132, 41);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(228, 22);
            this.txtISBN.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(406, 44);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(40, 16);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Titulo";
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.ColumnHeadersHeight = 29;
            this.dgvLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column5,
            this.dataGridViewTextBoxColumn5});
            this.dgvLibros.Location = new System.Drawing.Point(3, 314);
            this.dgvLibros.MultiSelect = false;
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            this.dgvLibros.RowHeadersWidth = 51;
            this.dgvLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibros.Size = new System.Drawing.Size(834, 231);
            this.dgvLibros.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "ISBN";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 67;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Titulo";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Autor";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Año";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Edición";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Editorial";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(134, 225);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 34);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(249, 225);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(109, 34);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(364, 225);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 34);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(19, 225);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(109, 34);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // tabAutores
            // 
            this.tabAutores.Controls.Add(this.btnGuardarAutor);
            this.tabAutores.Controls.Add(this.btnEditarAutor);
            this.tabAutores.Controls.Add(this.btnEliminarAutor);
            this.tabAutores.Controls.Add(this.label3);
            this.tabAutores.Controls.Add(this.btnNuevoAutor);
            this.tabAutores.Controls.Add(this.dgvRegistroAutores);
            this.tabAutores.Controls.Add(this.groupBox1);
            this.tabAutores.Controls.Add(this.lblRolAutor);
            this.tabAutores.Location = new System.Drawing.Point(4, 25);
            this.tabAutores.Name = "tabAutores";
            this.tabAutores.Size = new System.Drawing.Size(837, 548);
            this.tabAutores.TabIndex = 1;
            this.tabAutores.Text = "Autores";
            this.tabAutores.UseVisualStyleBackColor = true;
            // 
            // btnGuardarAutor
            // 
            this.btnGuardarAutor.Location = new System.Drawing.Point(366, 204);
            this.btnGuardarAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarAutor.Name = "btnGuardarAutor";
            this.btnGuardarAutor.Size = new System.Drawing.Size(111, 31);
            this.btnGuardarAutor.TabIndex = 13;
            this.btnGuardarAutor.Text = "Guardar";
            this.btnGuardarAutor.UseVisualStyleBackColor = true;
            this.btnGuardarAutor.Click += new System.EventHandler(this.btnGuardarAutor_Click);
            // 
            // btnEditarAutor
            // 
            this.btnEditarAutor.Location = new System.Drawing.Point(249, 204);
            this.btnEditarAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarAutor.Name = "btnEditarAutor";
            this.btnEditarAutor.Size = new System.Drawing.Size(111, 31);
            this.btnEditarAutor.TabIndex = 12;
            this.btnEditarAutor.Text = "Editar";
            this.btnEditarAutor.UseVisualStyleBackColor = true;
            this.btnEditarAutor.Click += new System.EventHandler(this.btnEditarAutor_Click);
            // 
            // btnEliminarAutor
            // 
            this.btnEliminarAutor.Location = new System.Drawing.Point(132, 204);
            this.btnEliminarAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarAutor.Name = "btnEliminarAutor";
            this.btnEliminarAutor.Size = new System.Drawing.Size(111, 31);
            this.btnEliminarAutor.TabIndex = 11;
            this.btnEliminarAutor.Text = "Eliminar";
            this.btnEliminarAutor.UseVisualStyleBackColor = true;
            this.btnEliminarAutor.Click += new System.EventHandler(this.btnEliminarAutor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Autores Registrados";
            // 
            // btnNuevoAutor
            // 
            this.btnNuevoAutor.Location = new System.Drawing.Point(15, 204);
            this.btnNuevoAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevoAutor.Name = "btnNuevoAutor";
            this.btnNuevoAutor.Size = new System.Drawing.Size(111, 31);
            this.btnNuevoAutor.TabIndex = 9;
            this.btnNuevoAutor.Text = "Nuevo";
            this.btnNuevoAutor.UseVisualStyleBackColor = true;
            this.btnNuevoAutor.Click += new System.EventHandler(this.btnNuevoAutor_Click);
            // 
            // dgvRegistroAutores
            // 
            this.dgvRegistroAutores.AllowUserToAddRows = false;
            this.dgvRegistroAutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroAutores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.dgvRegistroAutores.Location = new System.Drawing.Point(15, 286);
            this.dgvRegistroAutores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRegistroAutores.MultiSelect = false;
            this.dgvRegistroAutores.Name = "dgvRegistroAutores";
            this.dgvRegistroAutores.ReadOnly = true;
            this.dgvRegistroAutores.RowHeadersWidth = 51;
            this.dgvRegistroAutores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistroAutores.Size = new System.Drawing.Size(808, 220);
            this.dgvRegistroAutores.TabIndex = 8;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "ID Autor";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Nombre Autor";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Apellido Autor";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Nacionalidad";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIdAutor);
            this.groupBox1.Controls.Add(this.txtApellidoAutor);
            this.groupBox1.Controls.Add(this.lblNombreAutor);
            this.groupBox1.Controls.Add(this.txtIdAutor);
            this.groupBox1.Controls.Add(this.txtNombreAutor);
            this.groupBox1.Controls.Add(this.lblNacionalidadAutor);
            this.groupBox1.Controls.Add(this.txtNacionalidadAutor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(798, 167);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Autor";
            // 
            // lblIdAutor
            // 
            this.lblIdAutor.AutoSize = true;
            this.lblIdAutor.Location = new System.Drawing.Point(19, 34);
            this.lblIdAutor.Name = "lblIdAutor";
            this.lblIdAutor.Size = new System.Drawing.Size(77, 16);
            this.lblIdAutor.TabIndex = 0;
            this.lblIdAutor.Text = "Id del Autor:";
            // 
            // txtApellidoAutor
            // 
            this.txtApellidoAutor.Location = new System.Drawing.Point(161, 111);
            this.txtApellidoAutor.Name = "txtApellidoAutor";
            this.txtApellidoAutor.Size = new System.Drawing.Size(253, 22);
            this.txtApellidoAutor.TabIndex = 6;
            // 
            // lblNombreAutor
            // 
            this.lblNombreAutor.AutoSize = true;
            this.lblNombreAutor.Location = new System.Drawing.Point(19, 74);
            this.lblNombreAutor.Name = "lblNombreAutor";
            this.lblNombreAutor.Size = new System.Drawing.Size(115, 16);
            this.lblNombreAutor.TabIndex = 2;
            this.lblNombreAutor.Text = "Nombre del Autor:";
            // 
            // txtIdAutor
            // 
            this.txtIdAutor.Location = new System.Drawing.Point(129, 34);
            this.txtIdAutor.Name = "txtIdAutor";
            this.txtIdAutor.ReadOnly = true;
            this.txtIdAutor.Size = new System.Drawing.Size(285, 22);
            this.txtIdAutor.TabIndex = 1;
            // 
            // txtNombreAutor
            // 
            this.txtNombreAutor.Location = new System.Drawing.Point(161, 74);
            this.txtNombreAutor.Name = "txtNombreAutor";
            this.txtNombreAutor.Size = new System.Drawing.Size(253, 22);
            this.txtNombreAutor.TabIndex = 3;
            // 
            // lblNacionalidadAutor
            // 
            this.lblNacionalidadAutor.AutoSize = true;
            this.lblNacionalidadAutor.Location = new System.Drawing.Point(450, 74);
            this.lblNacionalidadAutor.Name = "lblNacionalidadAutor";
            this.lblNacionalidadAutor.Size = new System.Drawing.Size(94, 16);
            this.lblNacionalidadAutor.TabIndex = 14;
            this.lblNacionalidadAutor.Text = "Nacionalidad:";
            // 
            // txtNacionalidadAutor
            // 
            this.txtNacionalidadAutor.Location = new System.Drawing.Point(570, 74);
            this.txtNacionalidadAutor.Name = "txtNacionalidadAutor";
            this.txtNacionalidadAutor.Size = new System.Drawing.Size(205, 22);
            this.txtNacionalidadAutor.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apellido del autor:";
            // 
            // lblRolAutor
            // 
            this.lblRolAutor.AutoSize = true;
            this.lblRolAutor.Location = new System.Drawing.Point(34, 118);
            this.lblRolAutor.Name = "lblRolAutor";
            this.lblRolAutor.Size = new System.Drawing.Size(0, 16);
            this.lblRolAutor.TabIndex = 4;
            // 
            // frmRegistroLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(869, 607);
            this.Controls.Add(this.tabLibro);
            this.Name = "frmRegistroLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Libro";
            this.Load += new System.EventHandler(this.frmRegistroLibro_Load);
            this.tabLibro.ResumeLayout(false);
            this.tabDatosGenerales.ResumeLayout(false);
            this.tabDatosGenerales.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.tabAutores.ResumeLayout(false);
            this.tabAutores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroAutores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private Label lblNacionalidadAutor;
        private TextBox txtNacionalidadAutor;
        private Label label2;
        private Label lblRolAutor;
        private Button btnNuevoAutor;
        private DataGridView dgvRegistroAutores;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
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
