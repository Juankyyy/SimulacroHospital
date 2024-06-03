using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public interface ICitaRepository
    {
        public IEnumerable<Cita> GetAll();
        public Cita GetOne(int id);
        public void Create(Cita cita);
        public void Update(Cita cita);
        public void Inactive(int id);
        public void Active(int id);
        public IEnumerable<Cita> Appointments(int id);
        public IEnumerable<Cita> Date(DateOnly date);
        public IEnumerable<Cita> MedicoDate(int id, DateOnly date);
    }
}