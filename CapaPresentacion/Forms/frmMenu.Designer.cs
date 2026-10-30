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
            this.btnLibros = new System.Windows.Forms.Button();
            this.btnEjemplares = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.btnMultas = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLibros
            // 
            this.btnLibros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLibros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLibros.Image = ((System.Drawing.Image)(resources.GetObject("btnLibros.Image")));
            this.btnLibros.Location = new System.Drawing.Point(2, -2);
            this.btnLibros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Size = new System.Drawing.Size(118, 86);
            this.btnLibros.TabIndex = 0;
            this.btnLibros.Text = "Registro Libros";
            this.btnLibros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLibros.UseVisualStyleBackColor = false;
            this.btnLibros.Click += new System.EventHandler(this.btnLibros_Click);
            // 
            // btnEjemplares
            // 
            this.btnEjemplares.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEjemplares.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEjemplares.Image = ((System.Drawing.Image)(resources.GetObject("btnEjemplares.Image")));
            this.btnEjemplares.Location = new System.Drawing.Point(116, -2);
            this.btnEjemplares.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEjemplares.Name = "btnEjemplares";
            this.btnEjemplares.Size = new System.Drawing.Size(118, 86);
            this.btnEjemplares.TabIndex = 1;
            this.btnEjemplares.Text = "Registro Ejemplares";
            this.btnEjemplares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjemplares.UseVisualStyleBackColor = false;
            this.btnEjemplares.Click += new System.EventHandler(this.btnEjemplares_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.Location = new System.Drawing.Point(229, -2);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(118, 86);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Registro Lectores";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click_1);
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrestamos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrestamos.Image = ((System.Drawing.Image)(resources.GetObject("btnPrestamos.Image")));
            this.btnPrestamos.Location = new System.Drawing.Point(342, -2);
            this.btnPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Size = new System.Drawing.Size(118, 86);
            this.btnPrestamos.TabIndex = 3;
            this.btnPrestamos.Text = "Registro Préstamos";
            this.btnPrestamos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrestamos.UseVisualStyleBackColor = false;
            this.btnPrestamos.Click += new System.EventHandler(this.btnPrestamos_Click);
            // 
            // btnMultas
            // 
            this.btnMultas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMultas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMultas.Image = ((System.Drawing.Image)(resources.GetObject("btnMultas.Image")));
            this.btnMultas.Location = new System.Drawing.Point(454, -2);
            this.btnMultas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMultas.Name = "btnMultas";
            this.btnMultas.Size = new System.Drawing.Size(118, 86);
            this.btnMultas.TabIndex = 4;
            this.btnMultas.Text = "Multas";
            this.btnMultas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMultas.UseVisualStyleBackColor = false;
            this.btnMultas.Click += new System.EventHandler(this.btnMultas_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.Location = new System.Drawing.Point(569, -2);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(118, 86);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAyuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAyuda.Image")));
            this.btnAyuda.Location = new System.Drawing.Point(683, -2);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(118, 86);
            this.btnAyuda.TabIndex = 6;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 280);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnMultas);
            this.Controls.Add(this.btnPrestamos);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnEjemplares);
            this.Controls.Add(this.btnLibros);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMenu";
            this.Text = "Sistema de Gestión Biblioteca Universitaria";
            this.ResumeLayout(false);

        }
    }
}