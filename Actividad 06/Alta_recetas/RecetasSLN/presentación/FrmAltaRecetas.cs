using RecetasSLN.datos;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmAltaRecetas : Form
    {
        HelperDAO helper = HelperDAO.ObtenerInstancia();
        private Receta recetaN;
        public FrmAltaRecetas()
        {
            InitializeComponent();
            CargarIngredientes();
            CargarTipoReceta();
            ProximaReceta();
            recetaN = new Receta();

            txtNombre.Text = string.Empty;
            txtChef.Text = string.Empty;
            cboTipoR.SelectedIndex = -1;
            cboIngredientes.SelectedIndex = -1;

        }

        private void CargarTipoReceta()
        {
            DataTable dt = helper.ConsultarSQL("SP_CONSULTAR_TIPOS_RECETAS");
            cboTipoR.DataSource = dt;
            cboTipoR.DisplayMember = "tipo_receta";
            cboTipoR.ValueMember = "id_tipo_receta";
        }

        private void ProximaReceta()
        {
            int next = helper.ProximaReceta();
            if (next >= 0)
                lblNReceta.Text = "Receta Nro.°" + next.ToString();
            else
                MessageBox.Show("Error carga receta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CargarIngredientes()
        {
            DataTable dt = helper.ConsultarSQL("SP_CONSULTAR_INGREDIENTES");
            cboIngredientes.DataSource = dt;
            cboIngredientes.DisplayMember = "n_ingrediente";
            cboIngredientes.ValueMember = "id_ingrediente";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboTipoR.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un tipo de receta!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(dgvDetalles.RowCount < 3)
            {
                MessageBox.Show("Ha olvidado ingredientes?", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GuardarReceta();
        }

        private void GuardarReceta()
        {
            recetaN.TipoReceta = cboTipoR.SelectedIndex.ToString();
            recetaN.Cheff = txtChef.Text;
            recetaN.Nombre = txtNombre.Text;
            if (helper.ConfirmarReceta(recetaN) == true)
            { MessageBox.Show("Receta Cargada", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la Receta", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboIngredientes.Text == "")
            {
                MessageBox.Show("Debe seleccionar un ingrediente");
                return;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ColIngrediente"].Value.ToString().Equals(cboIngredientes.Text))
                {
                    MessageBox.Show("Ya ingreso este ingrediente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataRowView item = (DataRowView)cboIngredientes.SelectedItem;
            int cod = (int)item.Row.ItemArray[0];
            string nom = item.Row.ItemArray[1].ToString();
            string cant = item.Row.ItemArray[2].ToString();
            Ingredientes ing = new Ingredientes(cod, nom, cant);
            int cantidad = (int)nudCantidad.Value;
            DetalleReceta detalle = new DetalleReceta(ing, cantidad);
            recetaN.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { nom,cant });

            lblCantIngrediente.Text = "CANT. INGREDIENTES: " + dgvDetalles.RowCount;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Si cancela perdera todo lo cargado! Seguro de cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            this.Close();
        }
    }
}
