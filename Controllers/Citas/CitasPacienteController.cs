using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Appointments")]
    
    public class CitasPacienteController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitasPacienteController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Cita>> GetAppointments(int id)
        {
            var citasPaciente = _citaRepository.Appointments(id);
            
            if (citasPaciente == null)
            {
                return BadRequest($"Citas del paciente con id {id} no encontrada");
            }
            try
            {
                return Ok(citasPaciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer las cita del paciente con id {id}: {ex.Message}");
            }
        }
    }
}