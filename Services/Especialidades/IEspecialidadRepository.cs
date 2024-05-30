using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public interface IEspecialidadRepository
    {
        public IEnumerable<Especialidad> GetAll();
        public Especialidad GetOne(int id);
        public void Create(Especialidad especialidad);
        public void Update(Especialidad especialidad);
        public void Inactive(int id);
        public void Active(int id);
    }
}