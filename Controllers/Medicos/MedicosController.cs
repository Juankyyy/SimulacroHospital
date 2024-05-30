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
    }
}