using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Inactive")]
    
    public class CitaInactiveController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaInactiveController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut("{id}")]
        public IActionResult InactiveCita(int id)
        {
            var cita = _citaRepository.GetOne(id);
            
            if (cita == null)
            {
                return BadRequest($"Cita con id {id} no encontrada");
            }

            try
            {   
                if (cita.Estado == "Inactivo")
                {
                    _citaRepository.Inactive(id);
                    return Ok($"La cita con id {id} ya está Inactiva");

                } else {
                    _citaRepository.Inactive(id);
                    return Ok($"La cita con id {id} pasó a estar Inactiva");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado de la cita: {ex.Message}");
            }
        }
    }
}