using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RecetasSLN.dominio
{
    internal class Receta
    {
        public int IdReceta { get; set; }
        public string Nombre { get; set; }
        public string TipoReceta { get; set; }
        public string Cheff { get; set; }
        List<DetalleReceta> ListDetalles { get; set; }

        public Receta()
        {
            ListDetalles = new List<DetalleReceta>();
        }
        public void AgregarDetalle(DetalleReceta detalle)
        {
            ListDetalles.Add(detalle);
        }
    }
}
