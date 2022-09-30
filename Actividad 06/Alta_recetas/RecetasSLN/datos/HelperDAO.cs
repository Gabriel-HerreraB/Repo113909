using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.dominio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RecetasSLN.datos
{

    internal class HelperDAO
    {
            private static HelperDAO instancia;
            private SqlConnection cnn;
            private SqlCommand cmd;
            private DataTable table;
    
        private HelperDAO()
        {
            cnn = new SqlConnection(@"Data Source=I5_9400F\SQLEXPRESS02;Initial Catalog=recetas_db;Integrated Security=True");
        }
    
        public static HelperDAO ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDAO();
            }
            return instancia;

        }

        internal DataTable ConsultarSQL(string consulta)
        {
            cnn.Open();
            cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.StoredProcedure;
            table = new DataTable();
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;
        }

        internal int ProximaReceta()
        {
            cnn.Open();
            cmd = new SqlCommand("SP_CANTIDAD_RECETAS", cnn);
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@CantidadRecetas", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            cnn.Close();
            int next = Convert.ToInt32(param.Value);
            return next;
        }
        internal bool ConfirmarReceta(Receta recetaN)
        {
            bool ok = true;

            SqlCommand cmd = new SqlCommand();
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd = new SqlCommand("SP_INSERTAR_RECETA", cnn, t);
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo_receta", recetaN.TipoReceta);
                cmd.Parameters.AddWithValue("@nombre", recetaN.Nombre);
                cmd.Parameters.AddWithValue("@cheff", recetaN.Cheff);
                SqlParameter salida = new SqlParameter();
                salida.ParameterName = "@UltimoId";
                salida.DbType = DbType.Int32;
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);
                cmd.ExecuteNonQuery();
                int nroReceta = Convert.ToInt32(salida.Value);
                foreach (DetalleReceta item in recetaN.ListDetalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetalle.Connection = cnn;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_receta", nroReceta);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", item.Ingrediente.IdIngrediente);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                System.Windows.Forms.MessageBox.Show("Error", ex.Message);
                ok = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return ok;
        }

    }
}
