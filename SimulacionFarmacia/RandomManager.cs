using System;
using System.Collections.Generic;
using System.Text;

namespace PuntoDeAtencion
{
    public class RandomManager
    {
        private Random rnd = new Random();

        public Persona GenerarPersona()
        {
            int index = rnd.Next(0, 20);
            int probabilidad = rnd.Next(0, 100);

            return new Persona(index, probabilidad);
        }

        public int NextPersona() => rnd.Next(1, 2);

        public int TiempoAtencion() => rnd.Next(10, 15);
    }
}