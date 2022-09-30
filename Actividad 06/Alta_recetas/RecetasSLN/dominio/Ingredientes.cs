using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Ingredientes
    {
        public Ingredientes(int cod, string nom, string cant)
        {
            IdIngrediente = cod;
            Nombre = nom;
            Unidad = cant;
        }

        public int IdIngrediente { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
    }
}
