using Microsoft.AspNetCore.Mvc;
using SimulacroHospital.Models;
using SimulacroHospital.Services;

namespace SimulacroHospital.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class CitasController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitasController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cita>> GetCitas()
        {
            try
            {
                return Ok(_citaRepository.GetAll());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer todas las citas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCita(int id)
        {
            var cita = _citaRepository.GetOne(id);
            
            if (cita == null)
            {
                return BadRequest($"Cita con id {id} no encontrada");
            }
            try
            {
                return Ok(cita);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer la cita con id {id}: {ex.Message}");
            }
        }

        // Adicionales
        [HttpGet, Route("Appointments/{id}")]
        public ActionResult<IEnumerable<Cita>> GetAppointments(int id)
        {
            var citasPaciente = _citaRepository.Appointments(id);
            
            if (citasPaciente == null)
            {
                return BadRequest($"Citas del paciente con id {id} no encontrada");
            }
            try
            {
                return Ok(citasPaciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer las cita del paciente con id {id}: {ex.Message}");
            }
        }

        [HttpGet, Route("Date/{date}")]
        public ActionResult<IEnumerable<Cita>> GetAppointmentsDate(DateOnly date)
        {
            var citasPaciente = _citaRepository.Date(date);
            
            if (citasPaciente == null)
            {
                return BadRequest($"Citas en la fecha {date} no encontradas");
            }
            try
            {
                return Ok(citasPaciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer las citas con la fecha {date}: {ex.Message}");
            }
        }

        [HttpGet, Route("DateMedico/{date}/{id}")]
        public ActionResult<IEnumerable<Cita>> GetMedicosDate(int id, DateOnly date)
        {
            var citasPaciente = _citaRepository.MedicoDate(id, date);
            
            if (citasPaciente == null)
            {
                return BadRequest($"Citas del medico con id {id} en la fecha {date} no encontradas");
            }
            try
            {
                return Ok(citasPaciente);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al traer las citas del medico con id {id} con la fecha {date}: {ex.Message}");
            }
        }
    }
}