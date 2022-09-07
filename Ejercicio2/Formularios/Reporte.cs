using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio2.Datos;

namespace Ejercicio2.Formularios
{
    public partial class Reporte : Form
    {
        ConexionBD helper;
        public Reporte()
        {
            InitializeComponent();
            helper = new ConexionBD();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.rvReporte.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            DateTime desde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime hasta = Convert.ToDateTime(txtFechaHasta.Text);
            tabla = helper.CargarDataSet("SP_DataSet", desde, hasta);
            this.rvReporte.LocalReport.DataSources.Clear();
            //Se pone el nombre de la tabla creada en el archivo Report1.rdlc
            //Propiedades -> DataSetName
            this.rvReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", tabla));
            this.rvReporte.RefreshReport();
        }
    }
}
