using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Update")]
    
    public class CitaUpdateController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaUpdateController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCita(Cita cita)
        {
            if (cita == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _citaRepository.Update(cita);
                return Ok(cita);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la cita: {ex.Message}");
            }
        }
    }
}