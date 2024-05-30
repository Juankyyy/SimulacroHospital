using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Pacientes/Active")]
    
    public class PacienteActiveController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteActiveController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPut("{id}")]
        public IActionResult ActivePaciente(int id)
        {
            var paciente = _pacienteRepository.GetOne(id);
            
            if (paciente == null)
            {
                return BadRequest($"Paciente con id {id} no encontrada");
            }

            try
            {   
                if (paciente.Estado == "Activo")
                {
                    _pacienteRepository.Active(id);
                    return Ok($"El paciente con id {id} ya está Activo");

                } else {
                    _pacienteRepository.Active(id);
                    return Ok($"El paciente con id {id} pasó a estar Activo");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del paciente: {ex.Message}");
            }
        }
    }
}