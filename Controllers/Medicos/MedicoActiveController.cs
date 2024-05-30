using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/Medicos/Active")]
    
    public class MedicoActiveController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoActiveController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPut("{id}")]
        public IActionResult ActiveMedico(int id)
        {
            var medico = _medicoRepository.GetOne(id);
            
            if (medico == null)
            {
                return BadRequest($"Medico con id {id} no encontrada");
            }

            try
            {   
                if (medico.Estado == "Activo")
                {
                    _medicoRepository.Active(id);
                    return Ok($"El medico con id {id} ya está Activo");

                } else {
                    _medicoRepository.Active(id);
                    return Ok($"El medico con id {id} pasó a estar Activo");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del medico: {ex.Message}");
            }
        }
    }
}