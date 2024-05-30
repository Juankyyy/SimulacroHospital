using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Medicos/Update")]
    
    public class MedicoUpdateController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoUpdateController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMedico(Medico medico)
        {
            if (medico == null)
            {
                return BadRequest($"Datos Nulos");
            }

            try
            {
                _medicoRepository.Update(medico);
                return Ok(medico);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el medico: {ex.Message}");
            }
        }
    }
}