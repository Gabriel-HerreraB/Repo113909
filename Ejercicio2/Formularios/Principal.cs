using Ejercicio2.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Ejercicio2
{
    public partial class FrmEjercicio2 : Form
    {
        public FrmEjercicio2()
        {
            InitializeComponent();
        }

        private void tsmSalirApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Desea salir de la aplicación ?",
               "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void tsmNuevaFactura_Click(object sender, EventArgs e)
        {
            Facturacion nuevaFactura = new Facturacion();
            nuevaFactura.ShowDialog();
        }

        private void tsmBajaLogica_Click(object sender, EventArgs e)
        {
            frmBajaLogica bajaLogica = new frmBajaLogica();
            bajaLogica.ShowDialog();
        }

        private void tspdReportes_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.ShowDialog();
        }
    }
}
