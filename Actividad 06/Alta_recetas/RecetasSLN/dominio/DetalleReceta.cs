using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class DetalleReceta
    {
        public DetalleReceta(Ingredientes ing, int cantidad)
        {
            Cantidad = cantidad;
            Ingrediente = ing;
        }

        public Ingredientes Ingrediente { get; set; }
        public int Cantidad { get; set; }
    }
}
