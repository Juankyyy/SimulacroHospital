using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Tratamientos/Update")]
    
    public class TratamientoUpdateController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        public TratamientoUpdateController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTratamiento(Tratamiento tratamiento)
        {
            if (tratamiento == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _tratamientoRepository.Update(tratamiento);
                return Ok(tratamiento);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el tratamiento: {ex.Message}");
            }
        }
    }
}