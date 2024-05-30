using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    // [Route("api/[Controller]")]
    [Route("api/Especialidades/Update")]
    
    public class EspecialidadUpdateController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadUpdateController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEspecialidad(Especialidad especialidad)
        {
            if (especialidad == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _especialidadRepository.Update(especialidad);
                return Ok(especialidad);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la especialidad: {ex.Message}");
            }
        }
    }
}