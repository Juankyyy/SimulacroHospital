using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Citas/Active")]
    
    public class CitaActiveController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaActiveController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut("{id}")]
        public IActionResult ActiveCita(int id)
        {
            var cita = _citaRepository.GetOne(id);
            
            if (cita == null)
            {
                return BadRequest($"Cita con id {id} no encontrada");
            }

            try
            {   
                if (cita.Estado == "Activo")
                {
                    _citaRepository.Active(id);
                    return Ok($"La cita con id {id} ya está Activa");

                } else {
                    _citaRepository.Active(id);
                    return Ok($"La cita con id {id} pasó a estar Activa");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado de la cita: {ex.Message}");
            }
        }
    }
}