using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicosController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medico>> GetMedicos()
        {
            try
            {
                return Ok(_medicoRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer todas los medicos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMedico(int id)
        {
            var medico = _medicoRepository.GetOne(id);
            
            if (medico == null)
            {
                return BadRequest($"Medico con id {id} no encontrado");
            }
            try
            {
                return Ok(medico);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer el medico con id {id}: {ex.Message}");
            }
        }
    }
}