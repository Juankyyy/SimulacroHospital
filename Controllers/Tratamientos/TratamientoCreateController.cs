using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Tratamientos/Create")]
    
    public class TratamientoCreateController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        public TratamientoCreateController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPost]
        public IActionResult CreateTratamiento(Tratamiento tratamiento)
        {
            if (tratamiento == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _tratamientoRepository.Create(tratamiento);
                return Ok(tratamiento);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el tratamiento: {ex.Message}");
            }
        }
    }
}