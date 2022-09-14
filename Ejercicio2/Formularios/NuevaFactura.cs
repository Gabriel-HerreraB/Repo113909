using Ejercicio2.Datos;
using Ejercicio2.Dominio;
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
    public partial class Facturacion : Form
    {
        HelperDAO helper = HelperDAO.ObtenerInstancia();
        private Factura facturaN;
        public Facturacion()
        {
            InitializeComponent();
            facturaN = new Factura(); //se crea una nueva factura
            CargarArticulos();
            CargarFormaPago();
        }

        private void CargarFormaPago()
        {
            DataTable table = helper.ConsultarSQL("SP_CARGAR_FORMA_PAGO");
            cboFormaPago.DataSource = table;
            cboFormaPago.DisplayMember = "nombre";
            cboFormaPago.ValueMember = "cod_FormaPago";
        }
        private void CargarArticulos()
        {
            DataTable table = helper.ConsultarSQL("SP_CARGAR_ARTICULO");
            cboArticulo.DataSource = table;
            cboArticulo.DisplayMember = "nombre";
            cboArticulo.ValueMember = "cod_articulo";
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            ProximaFactura();
            dtpFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            cboArticulo.SelectedIndex = -1;
            //this.ActiveControl = cboArticulo;
        }

        private void ProximaFactura()
        {
            int next = helper.ProximaFactura();
            if (next > 0)
                lblNroFactura.Text = "Factura Nro.°" +  next.ToString();
            else
                MessageBox.Show("Error carga factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
                this.Close();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboArticulo.Text == "")
            { MessageBox.Show("Debe seleccionar un articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; }
            if (txtCantidad.Text == "")
            {MessageBox.Show("Debe ingresar una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; }
            //foreach (DataGridViewRow row in dgvDetalle.Rows)
            //{
            //    if(row.Cells["Articulo"].Value.ToString().Equals(cboArticulo.Text))
            //    {
            //        MessageBox.Show("PRODUCTO: " + cboArticulo.Text + "ya se encuentra como detalle!", "Control",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //}
            DataRowView item = (DataRowView)cboArticulo.SelectedItem; //desde el dataRow traes los datos de un articulo
            int cod = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom  = Convert.ToString(item.Row.ItemArray[1]);
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            Articulo a = new Articulo(cod, nom, pre); //Creas un articulo
            int cantidad = Convert.ToInt32(txtCantidad.Text);//guardas en una variable la cantidad del articulo
            Detalle detalle = new Detalle(a, cantidad);//al detalle le agregas el articulo con la cantidad
            facturaN.AgregarDetalle(detalle);
            dgvDetalle.Rows.Add(new object[] {item.Row[0], item.Row[1], item.Row[2],txtCantidad.Text });
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = facturaN.CalcularTotal();
            txtTotal.Text = total.ToString();

            if (txtDescuento.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDescuento.Text)) / 100;
                txtFinal.Text = (total - dto).ToString();
            }

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos detalle!",
                "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GuardarFactura();
        }

        private void GuardarFactura()
        {
            facturaN.Cliente = txtCliente.Text;
            facturaN.Descuento = Convert.ToInt32(txtDescuento.Text);
            facturaN.Fecha = dtpFecha.Value;
            facturaN.FormaPago = cboFormaPago.SelectedIndex + 1;
            if (helper.ConfirmarFactura(facturaN))
            {
                MessageBox.Show("Factura registrada", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la Factura", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
