using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public interface IMedicoRepository
    {
        public IEnumerable<Medico> GetAll();
        public Medico GetOne(int id);
        public void Create(Medico medico);
        public void Update(Medico medico);
        public void Inactive(int id);
        public void Active(int id);
    }
}