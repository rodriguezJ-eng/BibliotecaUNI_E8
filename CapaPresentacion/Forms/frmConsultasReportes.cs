using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmConsultasReportes : Form
    {
        private readonly LibroNegocio libroNegocio = new LibroNegocio();

        private List<Libro> _listaFiltrada = new List<Libro>();

        public frmConsultasReportes()
        {
            InitializeComponent();

            // El grid ya trae sus columnas fijas (ISBN, Titulo, Categoria, Año, Editorial)
            // así que se enlazan por nombre de propiedad en lugar de dejar que
            // el grid genere columnas nuevas por su cuenta.
            dgvLibros.AutoGenerateColumns = false;
            dgvLibros.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = nameof(Libro.ISBN);
            dgvLibros.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = nameof(Libro.Titulo);
            dgvLibros.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = nameof(Libro.Categoria);
            dgvLibros.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = nameof(Libro.Anio);
            dgvLibros.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = nameof(Libro.Editorial);
        }

        private void frmConsultasReportes_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            ActualizarGrid(libroNegocio.ConsultarTodos());
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();

            // Lista extendida de categorías y géneros literarios
            string[] categorias = new string[]
            {
                "Todas",
                "Ingeniería",
                "Sistemas y Computación",
                "Ciencias Básicas (Matemáticas, Física, Química)",
                "Administración y Economía",
                "Derecho y Ciencias Políticas",
                "Medicina y Ciencias de la Salud",
                "Humanidades y Ciencias Sociales",
                "Arquitectura y Diseño",
                "Ficción / Literatura General",
                "Novela Histórica",
                "Ciencia Ficción",
                "Fantasía",
                "Terror y Suspense",
                "Filosofía y Psicología",
                "Historia y Biografías",
                "Arte y Fotografía",
                "Desarrollo Personal y Autoayuda",
                "Cultura y Sociedad"
            };

            cmbCategoria.Items.AddRange(categorias);
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.SelectedIndex = 0;
        }

        private void ActualizarGrid(List<Libro> lista)
        {
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = lista;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text.Trim();
            string titulo = txtTitulo.Text.Trim();
            string categoriaSeleccionada = cmbCategoria.SelectedItem != null ? cmbCategoria.SelectedItem.ToString() : "Todas";
            string anioTexto = txtAnio.Text.Trim();

            IEnumerable<Libro> consulta = libroNegocio.ConsultarTodos();

            if (!string.IsNullOrEmpty(isbn))
            {
                consulta = consulta.Where(x => x.ISBN != null && x.ISBN.ToLower().Contains(isbn.ToLower()));
            }
            if (!string.IsNullOrEmpty(titulo))
            {
                consulta = consulta.Where(x => x.Titulo != null && x.Titulo.ToLower().Contains(titulo.ToLower()));
            }
            if (categoriaSeleccionada != "Todas")
            {
                consulta = consulta.Where(x => x.Categoria == categoriaSeleccionada);
            }
            if (!string.IsNullOrEmpty(anioTexto))
            {
                if (int.TryParse(anioTexto, out int anio))
                {
                    consulta = consulta.Where(x => x.Anio == anio);
                }
                else
                {
                    MessageBox.Show("El año debe ser un número entero válido.", "Dato inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnio.Focus();
                    return;
                }
            }

            _listaFiltrada = consulta.ToList();

            if (_listaFiltrada.Count == 0)
            {
                MessageBox.Show("No se encontraron libros con los criterios seleccionados.", "Consulta de Libros",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ActualizarGrid(_listaFiltrada);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<Libro> listaAExportar = (dgvLibros.DataSource as List<Libro>) ?? libroNegocio.ConsultarTodos();

            if (listaAExportar.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar Reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo CSV (*.csv)|*.csv";
                sfd.FileName = "ReporteLibros.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // Encabezados
                        sb.AppendLine("ISBN,Título,Categoría,Año,Editorial");

                        // Filas desde la lista seleccionada
                        foreach (var libro in listaAExportar)
                        {
                            sb.AppendLine($"\"{libro.ISBN}\",\"{libro.Titulo}\",\"{libro.Categoria}\",{libro.Anio},\"{libro.Editorial}\"");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Reporte exportado exitosamente.", "Exportar Reporte",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Exportar Reporte",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
