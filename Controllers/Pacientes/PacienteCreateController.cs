using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Pacientes/Create")]
    
    public class PacientesCreateController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesCreateController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPost]
        public IActionResult CreatePaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _pacienteRepository.Create(paciente);
                return Ok(paciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el paciente: {ex.Message}");
            }
        }
    }
}