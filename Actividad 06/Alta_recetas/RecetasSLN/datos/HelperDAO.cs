using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
