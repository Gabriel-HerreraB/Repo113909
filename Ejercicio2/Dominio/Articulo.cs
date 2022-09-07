using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Dominio
{
    internal class Articulo
    {
        private int cod_art;
        private string nombre;
        private double pre_unitario;

        public int Cod_art { get { return cod_art; } set { value = cod_art; } }
        public string Nombre { get { return nombre; } set { value = nombre; } }
        public double Pre_unitario { get { return pre_unitario; } set { value = pre_unitario; } }

        public Articulo(int cod, string nom, double pre)
        {
            this.cod_art = cod; 
            this.nombre = nom;
            this.pre_unitario = pre;
        }
    }
}
