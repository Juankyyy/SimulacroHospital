using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Tratamientos/Inactive")]
    
    public class TratamientoInactiveController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        public TratamientoInactiveController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPut("{id}")]
        public IActionResult InactiveTratamiento(int id)
        {
            var tratamiento = _tratamientoRepository.GetOne(id);
            
            if (tratamiento == null)
            {
                return BadRequest($"Tratamiento con id {id} no encontrado");
            }

            try
            {   
                if (tratamiento.Estado == "Inactivo")
                {
                    _tratamientoRepository.Inactive(id);
                    return Ok($"El tratamiento con id {id} ya está Inactivo");

                } else {
                    _tratamientoRepository.Inactive(id);
                    return Ok($"El tratamiento con id {id} pasó a estar Inactivo");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado de el tratamiento: {ex.Message}");
            }
        }
    }
}