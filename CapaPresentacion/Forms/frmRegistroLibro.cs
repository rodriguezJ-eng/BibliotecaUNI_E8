using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroLibro : Form
    {
        private readonly LibroNegocio libroNegocio = new LibroNegocio();
        private readonly AutorNegocio autorNegocio = new AutorNegocio();

        // 0 = se registra un libro nuevo; distinto de 0 = ID del libro que se edita.
        private int idLibroEdicion = 0;

        // 0 = se registra un autor nuevo; distinto de 0 = ID del autor que se edita.
        private int idAutorEdicion = 0;

        // Evita que la selección del grid de autores sobrescriba los campos
        // mientras se está recargando la lista.
        private bool cargandoAutores = false;

        public frmRegistroLibro()
        {
            InitializeComponent();
            dgvRegistroAutores.SelectionChanged += dgvRegistroAutores_SelectionChanged;
        }

        private void frmRegistroLibro_Load(object sender, EventArgs e)
        {
            CargarAutores();
            CargarAutoresGrilla();
            CargarCategorias();
            CargarLibros();
        }

        // ---------------------------------------------------------------
        // Autores
        // ---------------------------------------------------------------

        private void CargarAutores()
        {
            try
            {
                List<Autor> autores = autorNegocio.ConsultarTodos();

                cmbAutor.DataSource = null;
                cmbAutor.DisplayMember = "NombreCompleto";
                cmbAutor.ValueMember = "IDAutor";
                cmbAutor.DataSource = autores;
                cmbAutor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los autores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAutoresGrilla()
        {
            cargandoAutores = true;

            try
            {
                List<Autor> autores = autorNegocio.ConsultarTodos();

                dgvRegistroAutores.Rows.Clear();
                foreach (Autor autor in autores)
                {
                    int indice = dgvRegistroAutores.Rows.Add(
                        autor.IDAutor,
                        autor.Nombre,
                        autor.Apellido,
                        autor.Nacionalidad);

                    dgvRegistroAutores.Rows[indice].Tag = autor;
                }

                dgvRegistroAutores.ClearSelection();
                dgvRegistroAutores.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de autores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoAutores = false;
            }
        }

        private void dgvRegistroAutores_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoAutores)
                return;

            Autor autor = ObtenerAutorSeleccionado();
            if (autor == null)
                return;

            MostrarAutor(autor);
        }

        private void MostrarAutor(Autor autor)
        {
            idAutorEdicion = autor.IDAutor;
            txtIdAutor.Text = autor.IDAutor.ToString();
            txtNombreAutor.Text = autor.Nombre;
            txtApellidoAutor.Text = autor.Apellido;
            txtNacionalidadAutor.Text = autor.Nacionalidad;
        }

        private Autor ObtenerAutorSeleccionado()
        {
            if (dgvRegistroAutores.CurrentRow == null)
                return null;

            return dgvRegistroAutores.CurrentRow.Tag as Autor;
        }

        private void LimpiarCamposAutor()
        {
            idAutorEdicion = 0;
            txtIdAutor.Clear();
            txtNombreAutor.Clear();
            txtApellidoAutor.Clear();
            txtNacionalidadAutor.Clear();
            dgvRegistroAutores.ClearSelection();
            txtNombreAutor.Focus();
        }

        private void btnNuevoAutor_Click(object sender, EventArgs e)
        {
            LimpiarCamposAutor();
        }

        private void btnEditarAutor_Click(object sender, EventArgs e)
        {
            Autor autor = ObtenerAutorSeleccionado();
            if (autor == null)
            {
                MessageBox.Show("Seleccione un autor de la lista para editarlo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MostrarAutor(autor);
            MessageBox.Show("Modifique los datos y presione Guardar para aplicar los cambios.",
                "Editar autor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombreAutor.Focus();
        }

        private void btnEliminarAutor_Click(object sender, EventArgs e)
        {
            Autor autor = ObtenerAutorSeleccionado();
            if (autor == null)
            {
                MessageBox.Show("Seleccione un autor de la lista para eliminarlo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el autor \"" + autor.NombreCompleto + "\"?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                autorNegocio.Eliminar(autor.IDAutor);
                CargarAutores();
                CargarAutoresGrilla();
                LimpiarCamposAutor();

                MessageBox.Show("Autor eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            try
            {
                bool esEdicion = idAutorEdicion > 0;

                Autor autor = new Autor
                {
                    IDAutor = idAutorEdicion,
                    Id = idAutorEdicion.ToString(),
                    Nombre = txtNombreAutor.Text.Trim(),
                    Apellido = txtApellidoAutor.Text.Trim(),
                    Nacionalidad = txtNacionalidadAutor.Text.Trim()
                };

                if (esEdicion)
                    autorNegocio.Actualizar(autor);
                else
                    autorNegocio.Insertar(autor);

                CargarAutores();
                CargarAutoresGrilla();
                LimpiarCamposAutor();

                MessageBox.Show(esEdicion ? "Autor actualizado exitosamente." : "Autor registrado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        // Libros
        // ---------------------------------------------------------------

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();

            List<string> categorias = new List<string>();

            try
            {
                categorias.AddRange(libroNegocio.ConsultarCategorias());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string[] predeterminadas =
            {
                "Matemáticas",
                "Programación",
                "Ingeniería",
                "Ciencias",
                "Literatura",
                "Historia",
                "Otros"
            };

            foreach (string categoria in predeterminadas)
            {
                if (!categorias.Any(c => string.Equals(c, categoria, StringComparison.OrdinalIgnoreCase)))
                    categorias.Add(categoria);
            }

            categorias.Sort(StringComparer.OrdinalIgnoreCase);
            cmbCategoria.Items.AddRange(categorias.ToArray());
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
                MessageBox.Show("Error al cargar los libros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione un libro de la lista para editarlo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Seleccione un libro de la lista para eliminarlo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Libro eliminado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("El título no puede estar vacío.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitulo.Focus();
                    return;
                }

                if (cmbAutor.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un autor válido.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
