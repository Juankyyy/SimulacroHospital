using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    // [Route("api/[Controller]")]
    [Route("api/Especialidades/Create")]
    
    public class EspecialidadCreateController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadCreateController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPost]
        public IActionResult CreateEspecialidad(Especialidad especialidad)
        {
            if (especialidad == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _especialidadRepository.Create(especialidad);
                return Ok(especialidad);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la especialidad: {ex.Message}");
            }
        }
    }
}