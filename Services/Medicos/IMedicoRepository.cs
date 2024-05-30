using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public interface IMedicoRepository
    {
        public IEnumerable<Medico> GetAll();
    }
}