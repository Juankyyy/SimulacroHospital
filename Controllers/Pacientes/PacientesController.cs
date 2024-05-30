using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> GetPacientes()
        {
            try
            {
                return Ok(_pacienteRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer todas los pacientes: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPaciente(int id)
        {
            var paciente = _pacienteRepository.GetOne(id);
            
            if (paciente == null)
            {
                return BadRequest($"Paciente con id {id} no encontrado");
            }
            try
            {
                return Ok(paciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer el paciente con id {id}: {ex.Message}");
            }
        }
    }
}