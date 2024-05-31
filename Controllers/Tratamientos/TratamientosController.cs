using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class TratamientosController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientosRepository;

        public TratamientosController(ITratamientoRepository tratamientosRepository)
        {
            _tratamientosRepository = tratamientosRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tratamiento>> GetTratamientos()
        {
            try
            {
                return Ok(_tratamientosRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer todos los tratamientos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTratamiento(int id)
        {
            var tratamiento = _tratamientosRepository.GetOne(id);
            
            if (tratamiento == null)
            {
                return BadRequest($"Tratamiento con id {id} no encontrado");
            }
            try
            {
                return Ok(tratamiento);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer el tratamiento con id {id}: {ex.Message}");
            }
        }
    }
}