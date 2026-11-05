using System;
using System.Collections.Generic;
using System.Text;

namespace PuntoDeAtencion
{
    public class Tiempo
    {
        public int tiempo;

        public Tiempo()
        {
            this.tiempo = 0;
        }
        public int MostrarTiempo()
        {
            return this.tiempo;
        }

        public int GuardarTiempo()
        {
            int tmp = tiempo;
            return tmp;
        }
        public void SiguienteAccion()
        {
            Thread.Sleep(1000);
            tiempo++;
        }
    }
}
