using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Medicos/Create")]
    
    public class MedicoCreateController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoCreateController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }
    
        [HttpPost]
        public IActionResult CreateMedico(Medico medico)
        {
            if (medico == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _medicoRepository.Create(medico);
                return Ok(medico);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el medico: {ex.Message}");
            }
        }
    }
}
