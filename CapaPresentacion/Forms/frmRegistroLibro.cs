using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroLibro : Form
    {
        private LibroNegocio libroNegocio = new LibroNegocio();

        // 0 = se registra un libro nuevo; distinto de 0 = ID del libro que se edita.
        private int idLibroEdicion = 0;

        public frmRegistroLibro()
        {
            InitializeComponent();
        }

        private void frmRegistroLibro_Load(object sender, EventArgs e)
        {
            CargarAutores();
            CargarCategorias();
            CargarLibros();
        }

        private void CargarAutores()
        {
            try
            {
                List<Autor> autores = libroNegocio.ConsultarAutores();
                cmbAutor.DataSource = null;
                cmbAutor.DisplayMember = "NombreCompleto";
                cmbAutor.ValueMember = "IDAutor";
                cmbAutor.DataSource = autores;
                cmbAutor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los autores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new object[]
            {
                "Matemáticas",
                "Programación",
                "Ingeniería",
                "Ciencias",
                "Literatura",
                "Historia",
                "Otros"
            });
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarLibros()
        {
            try
            {
                List<Libro> libros = libroNegocio.ConsultarTodos();

                dgvLibros.Rows.Clear();
                foreach (Libro libro in libros)
                {
                    int indice = dgvLibros.Rows.Add(
                        libro.ISBN,
                        libro.Titulo,
                        string.IsNullOrWhiteSpace(libro.AutorNombre) ? "Sin autor" : libro.AutorNombre,
                        libro.Categoria,
                        libro.Anio == 0 ? string.Empty : libro.Anio.ToString(),
                        libro.Edicion,
                        libro.Editorial);

                    // Cada fila guarda su libro para no depender del orden ni del criterio de ordenación.
                    dgvLibros.Rows[indice].Tag = libro;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los libros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Libro ObtenerLibroSeleccionado()
        {
            if (dgvLibros.CurrentRow == null)
                return null;

            return dgvLibros.CurrentRow.Tag as Libro;
        }

        private void SeleccionarAutor(Libro libro)
        {
            cmbAutor.SelectedIndex = -1;

            for (int i = 0; i < cmbAutor.Items.Count; i++)
            {
                Autor autor = cmbAutor.Items[i] as Autor;
                if (autor == null)
                    continue;

                bool mismoId = libro.IDAutor > 0 && autor.IDAutor == libro.IDAutor;
                bool mismoNombre = libro.IDAutor <= 0
                                   && !string.IsNullOrWhiteSpace(libro.AutorNombre)
                                   && autor.NombreCompleto == libro.AutorNombre;

                if (mismoId || mismoNombre)
                {
                    cmbAutor.SelectedIndex = i;
                    return;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idLibroEdicion = 0;
            LimpiarCampos();
            dgvLibros.ClearSelection();
            txtISBN.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Libro libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                MessageBox.Show("Seleccione un libro de la lista para editarlo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            idLibroEdicion = libro.IDLibro;

            txtISBN.Text = libro.ISBN;
            txtTitulo.Text = libro.Titulo;
            txtEditorial.Text = libro.Editorial;
            txtEdicion.Text = libro.Edicion;
            txtAnio.Text = libro.Anio == 0 ? string.Empty : libro.Anio.ToString();

            if (string.IsNullOrWhiteSpace(libro.Categoria))
            {
                cmbCategoria.SelectedIndex = -1;
            }
            else
            {
                if (!cmbCategoria.Items.Contains(libro.Categoria))
                    cmbCategoria.Items.Add(libro.Categoria);
                cmbCategoria.SelectedItem = libro.Categoria;
            }

            SeleccionarAutor(libro);

            MessageBox.Show("Modifique los datos y presione Guardar para aplicar los cambios.",
                "Editar libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTitulo.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Libro libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                MessageBox.Show("Seleccione un libro de la lista para eliminarlo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el libro \"" + libro.Titulo + "\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                libroNegocio.Eliminar(libro.IDLibro);
                MessageBox.Show("Libro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    MessageBox.Show("El título no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitulo.Focus();
                    return;
                }

                if (cmbAutor.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un autor válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAutor.Focus();
                    return;
                }

                bool esEdicion = idLibroEdicion > 0;

                Libro libro = new Libro
                {
                    IDLibro = idLibroEdicion,
                    ISBN = txtISBN.Text.Trim(),
                    Titulo = txtTitulo.Text.Trim(),
                    IDAutor = Convert.ToInt32(cmbAutor.SelectedValue),
                    Autor = cmbAutor.SelectedItem as Autor,
                    Editorial = txtEditorial.Text.Trim(),
                    Edicion = txtEdicion.Text.Trim(),
                    Categoria = cmbCategoria.Text.Trim()
                };

                int anio = 0;
                int.TryParse(txtAnio.Text.Trim(), out anio);
                libro.Anio = anio;

                if (libro.Autor != null)
                    libro.AutorNombre = libro.Autor.NombreCompleto;

                if (esEdicion)
                    libroNegocio.Actualizar(libro);
                else
                    libroNegocio.Insertar(libro);

                MessageBox.Show(esEdicion ? "Libro actualizado exitosamente." : "Libro registrado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            idLibroEdicion = 0;

            txtISBN.Clear();
            txtTitulo.Clear();
            txtEditorial.Clear();
            txtEdicion.Clear();
            txtAnio.Clear();
            cmbCategoria.SelectedIndex = -1;
            if (cmbAutor.Items.Count > 0)
                cmbAutor.SelectedIndex = -1;

            txtTitulo.Focus();
        }

        private void btnNuevoAutor_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarAutor_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarAutor_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarAutor_Click(object sender, EventArgs e)
        {

        }
    }
}
