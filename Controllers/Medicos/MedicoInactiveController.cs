using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Medicos/Inactive")]
    
    public class MedicoInactiveController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoInactiveController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPut("{id}")]
        public IActionResult InactiveMedico(int id)
        {
            var medico = _medicoRepository.GetOne(id);
            
            if (medico == null)
            {
                return BadRequest($"Medico con id {id} no encontrada");
            }

            try
            {   
                if (medico.Estado == "Inactivo")
                {
                    _medicoRepository.Inactive(id);
                    return Ok($"El medico con id {id} ya está Inactivo");

                } else {
                    _medicoRepository.Inactive(id);
                    return Ok($"El medico con id {id} pasó a estar Inactivo");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del medico: {ex.Message}");
            }
        }
    }
}