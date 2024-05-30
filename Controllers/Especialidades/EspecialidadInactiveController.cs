using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    // [Route("api/[Controller]")]
    [Route("api/Especialidades/Inactive")]
    
    public class EspecialidadInactiveController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadInactiveController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPut("{id}")]
        public IActionResult InactiveEspecialidad(int id)
        {
            var especialidad = _especialidadRepository.GetOne(id);
            
            if (especialidad == null)
            {
                return BadRequest($"Especialidad con id {id} no encontrada");
            }

            try
            {   
                if (especialidad.Estado == "Inactivo")
                {
                    _especialidadRepository.Inactive(id);
                    return Ok($"La especialidad con id {id} ya está Inactiva");

                } else {
                    _especialidadRepository.Inactive(id);
                    return Ok($"La especialidad con id {id} pasó a estar Inactiva");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado de la especialidad: {ex.Message}");
            }
        }
    }
}