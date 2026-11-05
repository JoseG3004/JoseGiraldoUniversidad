using BaseDatos;
using Modelos;
using Servicios.Interfaces;
using static Modelos.DTOs.GranjaDTO;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Servicios
{
    public class ServicioGranja : IGranja
    {
        private GranjaResponseDTO MapearADTO(Granja granja)
        {
            return new GranjaResponseDTO
            {
                ID = granja.ID,
                Nombre = granja.Nombre,
                Cultivo = granja.Cultivo,
                Ubicacion = granja.Ubicacion,
                Ciclos = granja.Ciclos,
                Procesos = granja.Procesos,
                CanalVenta = granja.CanalVenta,
                TipoCultivo = granja.TipoCultivo,
                Clima = granja.Clima,
                Contacto = new ContactoDTO
                {
                    Nombre = granja.Contacto?.Nombre ?? "",
                    Telefono = granja.Contacto?.Telefono ?? ""
                },
                TamanoPlantacion = granja.TamanoPlantacion
            };
        }

        private bool ValidarDTO(GranjaCreateDTO dto)
        {
            if (dto == null) return false;

            // Validar Tamaño de Plantación (debe ser mayor a 0)
            if (dto.TamanoPlantacion <= 0) return false;

            // Validar datos de Contacto
            if (dto.Contacto == null || string.IsNullOrWhiteSpace(dto.Contacto.Nombre) || string.IsNullOrWhiteSpace(dto.Contacto.Telefono))
            {
                return false;
            }

            // Validaciones previas
            var procesosValidos = new List<string> { "floracion", "fructificacion", "maduracion" };
            if (dto.Procesos == null || !dto.Procesos.Any() ||
                dto.Procesos.Any(p => !procesosValidos.Contains(ServicioTexto.NormalizarTexto(p))))
            {
                return false;
            }

            string canal = ServicioTexto.NormalizarTexto(dto.CanalVenta);
            if (canal != "nacional" && canal != "internacional") return false;

            var tiposValidos = new List<string> { "raices", "tuberculo", "cereal", "leguminosa", "cultivo permanente", "cultivo industrial" };
            if (dto.TipoCultivo == null || !dto.TipoCultivo.Any() ||
                dto.TipoCultivo.Any(t => !tiposValidos.Contains(ServicioTexto.NormalizarTexto(t))))
            {
                return false;
            }

            string clima = ServicioTexto.NormalizarTexto(dto.Clima);
            if (clima != "frio" && clima != "caliente" && clima != "templado") return false;

            return true;
        }

        public List<GranjaResponseDTO> getAll()
        {
            return Datos.BaseGranjas.Select(g => MapearADTO(g)).ToList();
        }

        public GranjaResponseDTO? GetById(int id)
        {
            var granja = Datos.BaseGranjas.FirstOrDefault(g => g.ID == id);
            return granja == null ? null : MapearADTO(granja);
        }

        public GranjaResponseDTO? Create(GranjaCreateDTO dto)
        {
            if (!ValidarDTO(dto)) return null;

            int nuevoID = Datos.BaseGranjas.Any() ? Datos.BaseGranjas.Max(g => g.ID) + 1 : 1;

            Granja nuevaGranja = new Granja()
            {
                ID = nuevoID,
                Nombre = dto.Nombre?.Trim() ?? "",
                Cultivo = dto.Cultivo?.Trim() ?? "",
                Ubicacion = dto.Ubicacion?.Trim() ?? "",
                Ciclos = dto.Ciclos,
                Procesos = dto.Procesos.Select(p => p.Trim()).ToList(),
                CanalVenta = dto.CanalVenta?.Trim() ?? "",
                TipoCultivo = dto.TipoCultivo.Select(t => t.Trim()).ToList(),
                Clima = dto.Clima?.Trim() ?? "",
                Contacto = new Contacto
                {
                    Nombre = dto.Contacto.Nombre.Trim(),
                    Telefono = dto.Contacto.Telefono.Trim()
                },
                TamanoPlantacion = dto.TamanoPlantacion
            };

            Datos.BaseGranjas.Add(nuevaGranja);
            return MapearADTO(nuevaGranja);
        }

        public bool Update(int id, GranjaCreateDTO dto)
        {
            var granja = Datos.BaseGranjas.FirstOrDefault(g => g.ID == id);
            if (granja == null || !ValidarDTO(dto)) return false;

            granja.Nombre = dto.Nombre?.Trim() ?? "";
            granja.Cultivo = dto.Cultivo?.Trim() ?? "";
            granja.Ubicacion = dto.Ubicacion?.Trim() ?? "";
            granja.Ciclos = dto.Ciclos;
            granja.Procesos = dto.Procesos.Select(p => p.Trim()).ToList();
            granja.CanalVenta = dto.CanalVenta?.Trim() ?? "";
            granja.TipoCultivo = dto.TipoCultivo.Select(t => t.Trim()).ToList();
            granja.Clima = dto.Clima?.Trim() ?? "";
            granja.Contacto = new Contacto
            {
                Nombre = dto.Contacto.Nombre.Trim(),
                Telefono = dto.Contacto.Telefono.Trim()
            };
            granja.TamanoPlantacion = dto.TamanoPlantacion;

            return true;
        }

        public bool Delete(int id)
        {
            var granja = Datos.BaseGranjas.FirstOrDefault(g => g.ID == id);
            if (granja == null) return false;
            return Datos.BaseGranjas.Remove(granja);
        }
    }
}