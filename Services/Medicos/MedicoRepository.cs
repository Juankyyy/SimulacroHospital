using SimulacroHospital.Data;
using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly SimulacroHospitalContext _context;

        public MedicoRepository(SimulacroHospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> GetAll()
        {
            return _context.Medicos.ToList();
        }
    }
}