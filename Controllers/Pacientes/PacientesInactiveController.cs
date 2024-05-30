using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Pacientes/Inactive")]
    
    public class PacienteInactiveController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteInactiveController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPut("{id}")]
        public IActionResult InactivePaciente(int id)
        {
            var paciente = _pacienteRepository.GetOne(id);
            
            if (paciente == null)
            {
                return BadRequest($"Paciente con id {id} no encontrada");
            }

            try
            {   
                if (paciente.Estado == "Inactivo")
                {
                    _pacienteRepository.Inactive(id);
                    return Ok($"El paciente con id {id} ya está Inactivo");

                } else {
                    _pacienteRepository.Inactive(id);
                    return Ok($"El paciente con id {id} pasó a estar Inactivo");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del paciente: {ex.Message}");
            }
        }
    }
}