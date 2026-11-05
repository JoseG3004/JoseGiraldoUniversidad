
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesKD
{
    public class Nodo
    {
        public string Nombre;
        public string Categoria;
        public double[] Punto;
        public int Eje;
        public Nodo? Derecho;
        public Nodo? Izquierdo;
        public Nodo? Padre;

        public Nodo(double[] punto, string nombre, string categoria = "General")
        {
            this.Punto = punto;
            this.Nombre = nombre;
            this.Categoria = categoria;
            this.Derecho = null;
            this.Izquierdo = null;
            this.Padre = null;
        }

        public bool EsHoja => Derecho == null && Izquierdo == null;
    }
}