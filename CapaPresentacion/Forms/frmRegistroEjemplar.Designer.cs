using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmRegistroEjemplar
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

        private GroupBox grpDatosEjemplar;
        private Label lbllLibro;
        private ComboBox cmbLibro;
        private Label lblCodigo;
        private Label lblEstado;
        private ComboBox cmbEstado;

        private Button btnNuevo, btnGuardar, btnEditar, btnEliminar;

        private GroupBox grpFiltros;
        private Label lblFiltroEstado;
        private ComboBox cmbFiltroEstado;
        private Button btnFiltrar;
        private Button btnVerTodos;
        private Button btnEstadisticas;
        private TextBox txtEstadisticas;
        private Label lblBuscarCodigo;
        private TextBox txtBuscarCodigo;
        private Button btnBuscar;
        private Label lblOrdenar;
        private ComboBox cmbOrdenar;

        private GroupBox grpEjemplaresDelLibro;
        private DataGridView dgvEjemplares;

        private void InitializeComponent()
        {
            this.grpDatosEjemplar = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbllLibro = new System.Windows.Forms.Label();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.lblBuscarCodigo = new System.Windows.Forms.Label();
            this.txtBuscarCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblOrdenar = new System.Windows.Forms.Label();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.txtEstadisticas = new System.Windows.Forms.TextBox();
            this.grpEjemplaresDelLibro = new System.Windows.Forms.GroupBox();
            this.dgvEjemplares = new System.Windows.Forms.DataGridView();
            this.colIDEjemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimirTodos = new System.Windows.Forms.Button();
            this.btnImprimirEjemplar = new System.Windows.Forms.Button();
            this.grpDatosEjemplar.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.grpEjemplaresDelLibro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjemplares)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatosEjemplar
            // 
            this.grpDatosEjemplar.Controls.Add(this.txtCodigo);
            this.grpDatosEjemplar.Controls.Add(this.lbllLibro);
            this.grpDatosEjemplar.Controls.Add(this.cmbLibro);
            this.grpDatosEjemplar.Controls.Add(this.lblCodigo);
            this.grpDatosEjemplar.Controls.Add(this.lblEstado);
            this.grpDatosEjemplar.Controls.Add(this.cmbEstado);
            this.grpDatosEjemplar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDatosEjemplar.Location = new System.Drawing.Point(23, 16);
            this.grpDatosEjemplar.Name = "grpDatosEjemplar";
            this.grpDatosEjemplar.Size = new System.Drawing.Size(800, 160);
            this.grpDatosEjemplar.TabIndex = 0;
            this.grpDatosEjemplar.TabStop = false;
            this.grpDatosEjemplar.Text = "Datos del ejemplar";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(131, 94);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(264, 30);
            this.txtCodigo.TabIndex = 6;
            // 
            // lbllLibro
            // 
            this.lbllLibro.AutoSize = true;
            this.lbllLibro.Location = new System.Drawing.Point(34, 38);
            this.lbllLibro.Name = "lbllLibro";
            this.lbllLibro.Size = new System.Drawing.Size(57, 23);
            this.lbllLibro.TabIndex = 0;
            this.lbllLibro.Text = "Libro:";
            // 
            // cmbLibro
            // 
            this.cmbLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibro.Location = new System.Drawing.Point(126, 34);
            this.cmbLibro.Name = "cmbLibro";
            this.cmbLibro.Size = new System.Drawing.Size(639, 31);
            this.cmbLibro.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(34, 96);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(73, 23);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Codigo:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(457, 96);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(68, 23);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] {
            "Disponible",
            "Prestado",
            "En reparación",
            "Baja"});
            this.cmbEstado.Location = new System.Drawing.Point(537, 93);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(228, 31);
            this.cmbEstado.TabIndex = 5;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(34, 192);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(109, 34);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(154, 192);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 34);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(274, 192);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(109, 34);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(394, 192);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 34);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblFiltroEstado);
            this.grpFiltros.Controls.Add(this.cmbFiltroEstado);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.btnVerTodos);
            this.grpFiltros.Controls.Add(this.btnEstadisticas);
            this.grpFiltros.Controls.Add(this.lblBuscarCodigo);
            this.grpFiltros.Controls.Add(this.txtBuscarCodigo);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Controls.Add(this.lblOrdenar);
            this.grpFiltros.Controls.Add(this.cmbOrdenar);
            this.grpFiltros.Controls.Add(this.txtEstadisticas);
            this.grpFiltros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpFiltros.Location = new System.Drawing.Point(23, 240);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(800, 164);
            this.grpFiltros.TabIndex = 6;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Buscar, filtrar y ordenar";
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Location = new System.Drawing.Point(0, 34);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(155, 23);
            this.lblFiltroEstado.TabIndex = 0;
            this.lblFiltroEstado.Text = "Filtrar por estado:";
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Disponible",
            "Prestado",
            "En reparación",
            "Baja"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(160, 32);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(190, 31);
            this.cmbFiltroEstado.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(365, 30);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(110, 30);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.Location = new System.Drawing.Point(485, 30);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(110, 30);
            this.btnVerTodos.TabIndex = 3;
            this.btnVerTodos.Text = "Ver todos";
            this.btnVerTodos.Click += new System.EventHandler(this.btnVerTodos_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(605, 30);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(175, 30);
            this.btnEstadisticas.TabIndex = 4;
            this.btnEstadisticas.Text = "Ver estadísticas";
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // lblBuscarCodigo
            // 
            this.lblBuscarCodigo.AutoSize = true;
            this.lblBuscarCodigo.Location = new System.Drawing.Point(0, 77);
            this.lblBuscarCodigo.Name = "lblBuscarCodigo";
            this.lblBuscarCodigo.Size = new System.Drawing.Size(160, 23);
            this.lblBuscarCodigo.TabIndex = 5;
            this.lblBuscarCodigo.Text = "Buscar por código:";
            // 
            // txtBuscarCodigo
            // 
            this.txtBuscarCodigo.Location = new System.Drawing.Point(160, 74);
            this.txtBuscarCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarCodigo.Name = "txtBuscarCodigo";
            this.txtBuscarCodigo.Size = new System.Drawing.Size(190, 30);
            this.txtBuscarCodigo.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(365, 72);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblOrdenar
            // 
            this.lblOrdenar.AutoSize = true;
            this.lblOrdenar.Location = new System.Drawing.Point(481, 77);
            this.lblOrdenar.Name = "lblOrdenar";
            this.lblOrdenar.Size = new System.Drawing.Size(115, 23);
            this.lblOrdenar.TabIndex = 8;
            this.lblOrdenar.Text = "Ordenar por:";
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.Items.AddRange(new object[] {
            "Código (A-Z)",
            "Código (Z-A)",
            "Estado (A-Z)",
            "Estado (Z-A)"});
            this.cmbOrdenar.Location = new System.Drawing.Point(605, 74);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(175, 31);
            this.cmbOrdenar.TabIndex = 9;
            this.cmbOrdenar.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenar_SelectedIndexChanged);
            // 
            // txtEstadisticas
            // 
            this.txtEstadisticas.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtEstadisticas.Location = new System.Drawing.Point(20, 114);
            this.txtEstadisticas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEstadisticas.Multiline = true;
            this.txtEstadisticas.Name = "txtEstadisticas";
            this.txtEstadisticas.ReadOnly = true;
            this.txtEstadisticas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEstadisticas.Size = new System.Drawing.Size(760, 39);
            this.txtEstadisticas.TabIndex = 10;
            // 
            // grpEjemplaresDelLibro
            // 
            this.grpEjemplaresDelLibro.Controls.Add(this.dgvEjemplares);
            this.grpEjemplaresDelLibro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpEjemplaresDelLibro.Location = new System.Drawing.Point(23, 412);
            this.grpEjemplaresDelLibro.Name = "grpEjemplaresDelLibro";
            this.grpEjemplaresDelLibro.Size = new System.Drawing.Size(800, 240);
            this.grpEjemplaresDelLibro.TabIndex = 5;
            this.grpEjemplaresDelLibro.TabStop = false;
            this.grpEjemplaresDelLibro.Text = "Listado de ejemplares";
            // 
            // dgvEjemplares
            // 
            this.dgvEjemplares.AllowUserToAddRows = false;
            this.dgvEjemplares.AllowUserToDeleteRows = false;
            this.dgvEjemplares.ColumnHeadersHeight = 29;
            this.dgvEjemplares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDEjemplar,
            this.colIDLibro,
            this.colCodigo,
            this.colEstado,
            this.colLibro});
            this.dgvEjemplares.Location = new System.Drawing.Point(23, 32);
            this.dgvEjemplares.MultiSelect = false;
            this.dgvEjemplares.Name = "dgvEjemplares";
            this.dgvEjemplares.ReadOnly = true;
            this.dgvEjemplares.RowHeadersWidth = 51;
            this.dgvEjemplares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEjemplares.Size = new System.Drawing.Size(754, 186);
            this.dgvEjemplares.TabIndex = 0;
            this.dgvEjemplares.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEjemplares_CellClick);
            // 
            // colIDEjemplar
            // 
            this.colIDEjemplar.HeaderText = "IDEjemplar";
            this.colIDEjemplar.MinimumWidth = 6;
            this.colIDEjemplar.Name = "colIDEjemplar";
            this.colIDEjemplar.ReadOnly = true;
            this.colIDEjemplar.Visible = false;
            this.colIDEjemplar.Width = 125;
            // 
            // colIDLibro
            // 
            this.colIDLibro.HeaderText = "IDLibro";
            this.colIDLibro.MinimumWidth = 6;
            this.colIDLibro.Name = "colIDLibro";
            this.colIDLibro.ReadOnly = true;
            this.colIDLibro.Visible = false;
            this.colIDLibro.Width = 125;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.MinimumWidth = 6;
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 150;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 150;
            // 
            // colLibro
            // 
            this.colLibro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLibro.HeaderText = "Libro";
            this.colLibro.MinimumWidth = 6;
            this.colLibro.Name = "colLibro";
            this.colLibro.ReadOnly = true;
            // 
            // btnImprimirTodos
            // 
            this.btnImprimirTodos.Location = new System.Drawing.Point(522, 192);
            this.btnImprimirTodos.Name = "btnImprimirTodos";
            this.btnImprimirTodos.Size = new System.Drawing.Size(109, 34);
            this.btnImprimirTodos.TabIndex = 7;
            this.btnImprimirTodos.Text = "Imprimir todos";
            this.btnImprimirTodos.Click += new System.EventHandler(this.btnImprimirTodos_Click);
            // 
            // btnImprimirEjemplar
            // 
            this.btnImprimirEjemplar.Location = new System.Drawing.Point(647, 192);
            this.btnImprimirEjemplar.Name = "btnImprimirEjemplar";
            this.btnImprimirEjemplar.Size = new System.Drawing.Size(141, 34);
            this.btnImprimirEjemplar.TabIndex = 8;
            this.btnImprimirEjemplar.Text = "Imprimir ejemplar";
            this.btnImprimirEjemplar.Click += new System.EventHandler(this.btnImprimirEjemplar_Click);
            // 
            // frmRegistroEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(846, 672);
            this.Controls.Add(this.btnImprimirEjemplar);
            this.Controls.Add(this.btnImprimirTodos);
            this.Controls.Add(this.grpDatosEjemplar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.grpEjemplaresDelLibro);
            this.Name = "frmRegistroEjemplar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Ejemplar";
            this.grpDatosEjemplar.ResumeLayout(false);
            this.grpDatosEjemplar.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.grpEjemplaresDelLibro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjemplares)).EndInit();
            this.ResumeLayout(false);

        }
        private DataGridViewTextBoxColumn colIDEjemplar;
        private DataGridViewTextBoxColumn colIDLibro;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colLibro;
        private TextBox txtCodigo;
        private Button btnImprimirTodos;
        private Button btnImprimirEjemplar;
    }
}
