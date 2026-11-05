using System;
using System.Collections.Generic;
using System.Text;

namespace PuntoDeAtencion
{
    public class Caja
    {
        public string Nombre { get; private set; }
        public bool Ocupada { get; private set; }
        public Persona ClienteActual { get; private set; }
        public int TiempoRestante { get; private set; }

        public Caja(string nombre)
        {
            Nombre = nombre;
            Ocupada = false;
            ClienteActual = null;
            TiempoRestante = 0;
        }

        public void Atender(Persona persona, int tiempoAtencion)
        {
            ClienteActual = persona;
            TiempoRestante = tiempoAtencion;
            Ocupada = true;
        }

        public void ProcesarSegundo()
        {
            if (Ocupada)
            {
                TiempoRestante--;
                if (TiempoRestante <= 0)
                {
                    Ocupada = false;
                    ClienteActual = null;
                    TiempoRestante = 0;
                }
            }
        }
    }
}