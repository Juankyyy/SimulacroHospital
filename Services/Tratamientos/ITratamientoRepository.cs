using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public interface ITratamientoRepository
    {
        public IEnumerable<Tratamiento> GetAll();
        public Tratamiento GetOne(int id);
        public void Create(Tratamiento tratamiento);
        public void Update(Tratamiento tratamiento);
        public void Inactive(int id);
        public void Active(int id);
    }
}