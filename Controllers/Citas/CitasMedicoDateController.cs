using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Date")]
    
    public class CitasMedicoDateController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitasMedicoDateController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet("{date}/{id}")]
        public ActionResult<IEnumerable<Cita>> GetMedicosDate(int id, DateOnly date)
        {
            var citasPaciente = _citaRepository.MedicoDate(id, date);
            
            if (citasPaciente == null)
            {
                return BadRequest($"Citas del medico con id {id} en la fecha {date} no encontradas");
            }
            try
            {
                return Ok(citasPaciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer las citas del medico con id {id} con la fecha {date}: {ex.Message}");
            }
        }
    }
}