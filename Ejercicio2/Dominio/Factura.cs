using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Dominio
{
    internal class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int FormaPago { get; set; }
        public string Cliente { get; set; }
        public int Descuento { get; set; }
        public double Total { get; set; }
        public List<Detalle> lstDetalles { get; set; }


        public Factura()
        { lstDetalles = new List<Detalle>(); }

        public void AgregarDetalle(Detalle detalle)
        { lstDetalles.Add(detalle); }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (Detalle item in lstDetalles)
                total += item.CalcularSubTotal(); 
                Total = total;
            return total;   
        }
    }
}
