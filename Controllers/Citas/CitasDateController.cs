using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Date")]
    
    public class CitasDateController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitasDateController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet("{date}")]
        public ActionResult<IEnumerable<Cita>> GetAppointmentsDate(DateOnly date)
        {
            var citasPaciente = _citaRepository.Date(date);
            
            if (citasPaciente == null)
            {
                return BadRequest($"Citas en la fecha {date} no encontradas");
            }
            try
            {
                return Ok(citasPaciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer las citas con la fecha {date}: {ex.Message}");
            }
        }
    }
}