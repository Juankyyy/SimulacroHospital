using Microsoft.EntityFrameworkCore;
using SimulacroHospital.Data;
using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public class TratamientoRepository : ITratamientoRepository
    {
        private readonly SimulacroHospitalContext _context;

        public TratamientoRepository(SimulacroHospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Tratamiento> GetAll()
        {
            var tratamiento = _context.Tratamientos.Include(t => t.Cita).ToList();
            
            return tratamiento;
        }

        public Tratamiento GetOne(int id)
        {
            var tratamiento = _context.Tratamientos.Include(t => t.Cita).FirstOrDefault(m => m.Id == id);
            
            return tratamiento;
        }

        public void Create(Tratamiento tratamiento)
        {
            _context.Tratamientos.Add(tratamiento);
            _context.SaveChanges();
        }

        public void Update(Tratamiento tratamiento)
        {
            _context.Tratamientos.Update(tratamiento);
            _context.SaveChanges();
        }

        public void Inactive(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);

            tratamiento.Estado = "Inactivo";
            _context.Tratamientos.Update(tratamiento);
            _context.SaveChanges();
        }

        public void Active(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);

            tratamiento.Estado = "Activo";
            _context.Tratamientos.Update(tratamiento);
            _context.SaveChanges();
        }
    }
}