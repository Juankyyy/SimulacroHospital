using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    // [Route("api/[Controller]")]
    [Route("api/Especialidades/Active")]
    
    public class EspecialidadActiveController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadActiveController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPut("{id}")]
        public IActionResult ActiveEspecialidad(int id)
        {
            var especialidad = _especialidadRepository.GetOne(id);
            
            if (especialidad == null)
            {
                return BadRequest($"Especialidad con id {id} no encontrada");
            }

            try
            {   
                if (especialidad.Estado == "Activo")
                {
                    _especialidadRepository.Active(id);
                    return Ok($"La especialidad con id {id} ya está Activa");

                } else {
                    _especialidadRepository.Active(id);
                    return Ok($"La especialidad con id {id} pasó a estar Activa");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado de la especialidad: {ex.Message}");
            }
        }
    }
}