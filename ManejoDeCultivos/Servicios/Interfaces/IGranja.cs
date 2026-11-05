using Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using static Modelos.DTOs.GranjaDTO;

namespace Servicios.Interfaces
{
    public interface IGranja
    {
        public List<GranjaResponseDTO> getAll();
        GranjaResponseDTO? GetById(int id);
        GranjaResponseDTO? Create(GranjaCreateDTO dto);
        bool Update(int id, GranjaCreateDTO dto);
        bool Delete(int id);
    }
}
