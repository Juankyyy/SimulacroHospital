using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public interface IPacienteRepository
    {
        public IEnumerable<Paciente> GetAll();
        public Paciente GetOne(int id);
        public void Create(Paciente paciente);
        public void Update(Paciente paciente);
        public void Inactive(int id);
        public void Active(int id);
    }
}