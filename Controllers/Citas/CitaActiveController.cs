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
    }
}