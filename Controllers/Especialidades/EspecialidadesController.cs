using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadesController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> GetEspecialidades()
        {
            try
            {
                return Ok(_especialidadRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer todas las especialidades: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEspecialidad(int id)
        {
            var especialidad = _especialidadRepository.GetOne(id);
            
            if (especialidad == null)
            {
                return BadRequest($"Especialidad con id {id} no encontrada");
            }
            try
            {
                return Ok(especialidad);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer la especialidad con id {id}: {ex.Message}");
            }
        }
    }
}