using System.Collections.Generic;

namespace Modelos.DTOs
{
    public class GranjaDTO
    {
        public class ContactoDTO
        {
            public string Nombre { get; set; } = string.Empty;
            public string Telefono { get; set; } = string.Empty;
        }

        public class GranjaCreateDTO
        {
            public string Nombre { get; set; } = string.Empty;
            public string Cultivo { get; set; } = string.Empty;
            public string Ubicacion { get; set; } = string.Empty;
            public int Ciclos { get; set; }
            public List<string> Procesos { get; set; } = new List<string>();
            public string CanalVenta { get; set; } = string.Empty;
            public List<string> TipoCultivo { get; set; } = new List<string>();
            public string Clima { get; set; } = string.Empty;
            public ContactoDTO Contacto { get; set; } = new ContactoDTO();
            public double TamanoPlantacion { get; set; }
        }

        public class GranjaResponseDTO
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
            public ContactoDTO Contacto { get; set; } = new ContactoDTO();
            public double TamanoPlantacion { get; set; }
        }
    }
}