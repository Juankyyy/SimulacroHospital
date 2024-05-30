using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Pacientes/Update")]
    
    public class PacientesUpdateController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesUpdateController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _pacienteRepository.Update(paciente);
                return Ok(paciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el paciente: {ex.Message}");
            }
        }
    }
}