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
    }
}