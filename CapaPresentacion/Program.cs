using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BibliotecaUniversitaria.Forms;

namespace BibliotecaUniversitaria
{
    internal static class Program
    {
        // .NET Framework 4.7.2 no tiene Application.SetHighDpiMode (existe desde .NET Core 3.0).
        // SetProcessDPIAware() de Windows hace lo mismo que HighDpiMode.SystemAware.
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            SetProcessDPIAware(); // debe llamarse antes de crear cualquier ventana
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Se muestra primero el login. Si el usuario inicia sesión correctamente
            // (DialogResult.OK), se abre el Menú principal.
            // "using var" es de C# 8: en C# 7.3 se escribe con llaves.
            using (var frmLogin = new frmInicioSesion())
            {
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMenu());
                }
            }
        }
    }
}
