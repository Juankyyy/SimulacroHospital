using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class CitasController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitasController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cita>> GetCitas()
        {
            try
            {
                return Ok(_citaRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer todas las citas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCita(int id)
        {
            var cita = _citaRepository.GetOne(id);
            
            if (cita == null)
            {
                return BadRequest($"Cita con id {id} no encontrada");
            }
            try
            {
                return Ok(cita);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer la cita con id {id}: {ex.Message}");
            }
        }
    }
}