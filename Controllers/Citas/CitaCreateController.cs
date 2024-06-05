using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;
using SimulacroHospital.AddControllers;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Create")]
    
    public class CitaCreateController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaCreateController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPost]
        public IActionResult CreateCita(Cita cita)
        {
            if (cita == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _citaRepository.Create(cita);

                return Ok(cita);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cita: {ex.Message}");
            }
        }
    }
}