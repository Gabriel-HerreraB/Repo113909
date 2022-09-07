using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ejercicio2.Dominio;

namespace Ejercicio2.Datos
{
    internal class ConexionBD
    {
        private SqlConnection cnn;
        private SqlCommand cmd;
        private DataTable table;

        public ConexionBD()
        {
            //cnn = new SqlConnection();
            //cnn.ConnectionString = Properties.Resources.ConexionBD;
            cnn = new SqlConnection(@"Data Source=I5_9400F\SQLEXPRESS02;Initial Catalog=BajaLogica;Integrated Security=True");
        }
        public DataTable ConsultarSQL(string consulta)
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

        internal DataTable CargarDataSet(string sp, DateTime desde, DateTime hasta)
        {
            {
                cnn.Open();
                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                DataTable tabla = new DataTable();
                tabla.Load(cmd.ExecuteReader());
                cnn.Close();
                return tabla;
            }
        }

        public int ProximaFactura()
        {
            cnn.Open();
            cmd = new SqlCommand("SP_PROXIMA_FACTURA", cnn);
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("next", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            cnn.Close();
            int next = Convert.ToInt32(param.Value);
            return next;
        }

        internal DataTable ConsultarBaja(string sp, int nro_factura)
        {
            cnn.Open();
            cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro_factura", nro_factura);
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool ConfirmarFactura(Factura oFactura)
        {
            bool ok = true;

            SqlCommand cmd = new SqlCommand();
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd = new SqlCommand("SP_INSERTAR_FACTURA", cnn, t);
                cmd.Connection = cnn;
                //cmd.CommandText = "SP_INSERTAR_FACTURA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("@forma_pago", oFactura.FormaPago);
                cmd.Parameters.AddWithValue("@total", oFactura.CalcularTotal());
                SqlParameter salida = new SqlParameter();
                salida.ParameterName = "@factura_nro";
                salida.DbType = DbType.Int32;
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);
                cmd.ExecuteNonQuery();
                int nroFactura = Convert.ToInt32(salida.Value);
                //int detalleNro = 1;
                foreach (Detalle item in oFactura.lstDetalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.Connection = cnn;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@factura_nro", nroFactura);
                    //cmdDetalle.Parameters.AddWithValue("@cod_detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@id_articulo", oFactura.lstDetalles[0].Articulo.Cod_art);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", oFactura.lstDetalles[0].Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    //detalleNro++;
                }
                t.Commit();
                cnn.Close();
            }
            catch (SqlException)
            {
                ok = false;
                t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return ok;
        }

        public int BajaLogica(int v1)
        {
            cnn.Open();
            cmd = new SqlCommand("SP_EJECUTAR_BAJA", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro", v1);
            int numero = cmd.ExecuteNonQuery();
            cnn.Close(); 
            return numero;
        }
    }
}
