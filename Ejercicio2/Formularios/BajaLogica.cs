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
using Ejercicio2.Dominio;

namespace Ejercicio2.Formularios
{
    public partial class frmBajaLogica : Form
    {
        HelperDAO helper = HelperDAO.ObtenerInstancia();
        Factura facturaN;
        public frmBajaLogica()
        { 
            InitializeComponent();
            facturaN = new Factura();
        }

        private void frmBajaLogica_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        public void CargarFacturas()
        {
            
            DataTable table = helper.ConsultarSQL("SP_CARGAR_FACTURAS");
            cboFacturas.DataSource = table;
            //cboFacturas.DisplayMember = "nombre";
            cboFacturas.ValueMember = "nro_factura";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)cboFacturas.SelectedItem;
            int factura = Convert.ToInt32(item.Row.ItemArray[0]);
            DataTable tabla = helper.ConsultarBaja("SP_CARGAR_BAJA", factura);
            dgvFactura.Rows.Clear();
            foreach (DataRow row in tabla.Rows)
            {
                txtCliente.Text = (string)row["cliente"];
                dtpFecha.Text = row["fecha"].ToString();
                int cod = (int)row["cod_articulo"];
                string nom = (string)row["nombre"];
                double pre = Convert.ToDouble(row["pre_unitario"]);
                Articulo a = new Articulo(cod, nom, pre); //Creas un articulo
                int cantidad = (int)row["cantidad"];
                Detalle detalle = new Detalle(a, cantidad);
                facturaN.AgregarDetalle(detalle);
                dgvFactura.Rows.Add(new object[] { cod, nom, cantidad, pre });
            }
        }

        private void dgvFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFactura.CurrentCell.ColumnIndex == 4)
            {
                DialogResult msg = MessageBox.Show("Desea dar de baja?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    int item = Convert.ToInt32(cboFacturas.SelectedItem);
                    helper.BajaLogica(item);
                    dgvFactura.Rows.Remove(dgvFactura.CurrentRow);
                }
                else return;
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Desea dar de baja?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView item = (DataRowView)cboFacturas.SelectedItem;
                int factura = Convert.ToInt32(item.Row.ItemArray[0]);
                int numero = helper.BajaLogica(factura);
                if (numero > 0)
                    MessageBox.Show("Factura dada de baja", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
