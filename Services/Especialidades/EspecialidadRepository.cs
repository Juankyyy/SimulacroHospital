using SimulacroHospital.Data;
using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly SimulacroHospitalContext _context;

        public EspecialidadRepository(SimulacroHospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        public Especialidad GetOne(int id)
        {
            return _context.Especialidades.Find(id);
        }

        public void Create(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
        }

        public void Update(Especialidad especialidad)
        {
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }

        public void Inactive(int id)
        {
            var especialidad = _context.Especialidades.Find(id);

            especialidad.Estado = "Inactivo";
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }

        public void Active(int id)
        {
            var especialidad = _context.Especialidades.Find(id);

            especialidad.Estado = "Activo";
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }
    }
}