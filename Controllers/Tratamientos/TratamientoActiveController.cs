using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Tratamientos/Active")]
    
    public class TratamientoActiveController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        public TratamientoActiveController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPut("{id}")]
        public IActionResult ActiveTratamiento(int id)
        {
            var tratamiento = _tratamientoRepository.GetOne(id);
            
            if (tratamiento == null)
            {
                return BadRequest($"Tratamiento con id {id} no encontrado");
            }

            try
            {   
                if (tratamiento.Estado == "Activo")
                {
                    _tratamientoRepository.Active(id);
                    return Ok($"El tratamiento con id {id} ya está Activo");

                } else {
                    _tratamientoRepository.Active(id);
                    return Ok($"El tratamiento con id {id} pasó a estar Activo");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del tratamiento: {ex.Message}");
            }
        }
    }
}