using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmMenu
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

        private Button btnLibros;
        private Button btnEjemplares;
        private Button btnUsuarios;
        private Button btnPrestamos;
        private Button btnMultas;
        private Button btnReportes;
        private Button btnAyuda;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            btnLibros = new Button();
            btnEjemplares = new Button();
            btnUsuarios = new Button();
            btnPrestamos = new Button();
            btnMultas = new Button();
            btnReportes = new Button();
            btnAyuda = new Button();
            SuspendLayout();
            // 
            // btnLibros
            // 
            btnLibros.BackColor = Color.WhiteSmoke;
            btnLibros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLibros.Image = (Image)resources.GetObject("btnLibros.Image");
            btnLibros.Location = new Point(2, -2);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(118, 108);
            btnLibros.TabIndex = 0;
            btnLibros.Text = "Registro Libros";
            btnLibros.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLibros.UseVisualStyleBackColor = false;
            btnLibros.Click += btnLibros_Click;
            // 
            // btnEjemplares
            // 
            btnEjemplares.BackColor = Color.WhiteSmoke;
            btnEjemplares.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEjemplares.Image = (Image)resources.GetObject("btnEjemplares.Image");
            btnEjemplares.Location = new Point(116, -2);
            btnEjemplares.Name = "btnEjemplares";
            btnEjemplares.Size = new Size(118, 108);
            btnEjemplares.TabIndex = 1;
            btnEjemplares.Text = "Registro Ejemplares";
            btnEjemplares.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEjemplares.UseVisualStyleBackColor = false;
            btnEjemplares.Click += btnEjemplares_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.WhiteSmoke;
            btnUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUsuarios.Image = (Image)resources.GetObject("btnUsuarios.Image");
            btnUsuarios.Location = new Point(229, -2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(118, 108);
            btnUsuarios.TabIndex = 2;
            btnUsuarios.Text = "Registro Usuarios";
            btnUsuarios.TextImageRelation = TextImageRelation.ImageAboveText;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnPrestamos
            // 
            btnPrestamos.BackColor = Color.WhiteSmoke;
            btnPrestamos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrestamos.Image = (Image)resources.GetObject("btnPrestamos.Image");
            btnPrestamos.Location = new Point(342, -2);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(118, 108);
            btnPrestamos.TabIndex = 3;
            btnPrestamos.Text = "Registro Préstamos";
            btnPrestamos.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPrestamos.UseVisualStyleBackColor = false;
            btnPrestamos.Click += btnPrestamos_Click;
            // 
            // btnMultas
            // 
            btnMultas.BackColor = Color.WhiteSmoke;
            btnMultas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMultas.Image = (Image)resources.GetObject("btnMultas.Image");
            btnMultas.Location = new Point(454, -2);
            btnMultas.Name = "btnMultas";
            btnMultas.Size = new Size(118, 108);
            btnMultas.TabIndex = 4;
            btnMultas.Text = "Multas";
            btnMultas.TextImageRelation = TextImageRelation.ImageAboveText;
            btnMultas.UseVisualStyleBackColor = false;
            btnMultas.Click += btnMultas_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.WhiteSmoke;
            btnReportes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReportes.Image = (Image)resources.GetObject("btnReportes.Image");
            btnReportes.Location = new Point(569, -2);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(118, 108);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.BackColor = Color.WhiteSmoke;
            btnAyuda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAyuda.Image = (Image)resources.GetObject("btnAyuda.Image");
            btnAyuda.Location = new Point(683, -2);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(118, 108);
            btnAyuda.TabIndex = 6;
            btnAyuda.Text = "Ayuda";
            btnAyuda.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAyuda.UseVisualStyleBackColor = false;
            btnAyuda.Click += btnAyuda_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(214, 235, 255);
            ClientSize = new Size(800, 350);
            Controls.Add(btnAyuda);
            Controls.Add(btnReportes);
            Controls.Add(btnMultas);
            Controls.Add(btnPrestamos);
            Controls.Add(btnUsuarios);
            Controls.Add(btnEjemplares);
            Controls.Add(btnLibros);
            Name = "frmMenu";
            Text = "Sistema de Gestión Biblioteca Universitaria";
            Load += frmMenu_Load;
            ResumeLayout(false);
        }
    }
}