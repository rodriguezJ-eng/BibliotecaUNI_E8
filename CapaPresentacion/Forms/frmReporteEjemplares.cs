using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Microsoft.Reporting.WinForms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmReporteEjemplares : Form
    {
        private readonly List<Ejemplar> ejemplares;

        public frmReporteEjemplares(List<Ejemplar> ejemplares)
        {
            InitializeComponent();
            this.ejemplares = ejemplares;
            Load += frmReporteEjemplares_Load;
        }

        private void frmReporteEjemplares_Load(object sender, EventArgs e)
        {
            try
            {
                string rutaReporte = Path.Combine(Application.StartupPath,
                    "Reportes", "rptEjemplares.rdlc");

                if (!File.Exists(rutaReporte))
                {
                    MessageBox.Show("No se encontró el reporte en: " + rutaReporte);
                    return;
                }

                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = rutaReporte;
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource origen =
                    new ReportDataSource("dsEjemplares", ejemplares);
                reportViewer1.LocalReport.DataSources.Add(origen);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No fue posible cargar el reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}