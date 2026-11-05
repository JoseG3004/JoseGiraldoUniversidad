using System;
using System.Collections.Generic;

namespace Modelos
{
    public class Granja
    {
        public int ID { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Cultivo { get; set; } = string.Empty;

        public string Ubicacion { get; set; } = string.Empty;

        public int Ciclos { get; set; }

        public List<string> Procesos { get; set; } = new List<string>();

        public string CanalVenta { get; set; } = string.Empty;

        public List<string> TipoCultivo { get; set; } = new List<string>();

        public string Clima { get; set; } = string.Empty;
        public Contacto Contacto { get; set; } = new Contacto();
        public double TamanoPlantacion { get; set; }
    }
}