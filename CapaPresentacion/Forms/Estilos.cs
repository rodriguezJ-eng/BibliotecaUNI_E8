using System.Drawing;

namespace BibliotecaUniversitaria.Forms
{
    /// <summary>
    /// Paleta de colores única de la aplicación, para que todas las
    /// ventanas mantengan la misma identidad visual.
    /// </summary>
    internal static class Estilos
    {
        public static readonly Color FondoFormulario = Color.FromArgb(213, 234, 248);
        public static readonly Color FondoGroupBox = Color.FromArgb(213, 234, 248);

        public static readonly Color BotonAccionFondo = Color.FromArgb(31, 74, 128);
        public static readonly Color BotonAccionFondoHover = Color.FromArgb(41, 94, 158);
        public static readonly Color BotonAccionTexto = Color.White;

        public static readonly Color BotonMenuFondo = Color.White;
        public static readonly Color BotonMenuBorde = Color.FromArgb(190, 205, 220);
        public static readonly Color BotonMenuTexto = Color.FromArgb(30, 30, 30);

        public static readonly Font FuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FuenteNormal = new Font("Segoe UI", 9F);

        /// <summary>Aplica el estilo azul marino usado en los botones de acción (CRUD, Buscar, etc.).</summary>
        public static void AplicarBotonAccion(System.Windows.Forms.Button boton)
        {
            boton.BackColor = BotonAccionFondo;
            boton.ForeColor = BotonAccionTexto;
            boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor = BotonAccionFondoHover;
            boton.Font = FuenteNormal;
            boton.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        /// <summary>Aplica el estilo blanco con borde usado en los botones del Menú principal.</summary>
        public static void AplicarBotonMenu(System.Windows.Forms.Button boton)
        {
            boton.BackColor = BotonMenuFondo;
            boton.ForeColor = BotonMenuTexto;
            boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = BotonMenuBorde;
            boton.Font = FuenteNormal;
            boton.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
