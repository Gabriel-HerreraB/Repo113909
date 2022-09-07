using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Dominio
{
    internal class Detalle
    {
        private Articulo articulo;
        private int cantidad;

        public Articulo Articulo { get { return articulo; } set { value = articulo; } }
        public int Cantidad { get { return cantidad; } set { value = cantidad; } }

        public Detalle(Articulo art, int cant)
        {
            this.articulo = art;
            this.cantidad = cant;   
        }

        public int CalcularSubTotal()
        { return (int)(Articulo.Pre_unitario * cantidad); }
    }
}


