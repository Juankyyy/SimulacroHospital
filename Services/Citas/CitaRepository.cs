using Microsoft.EntityFrameworkCore;
using SimulacroHospital.Data;
using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public class CitaRepository : ICitaRepository
    {
        private readonly SimulacroHospitalContext _context;

        public CitaRepository(SimulacroHospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Cita> GetAll()
        {
            var citas = _context.Citas.Include(m => m.Medico).Include(m => m.Paciente).ToList();
            
            return citas;
        }

        public Cita GetOne(int id)
        {
            var cita = _context.Citas.Include(m => m.Medico).Include(m => m.Paciente).FirstOrDefault(m => m.Id == id);
            
            return cita;
        }

        public void Create(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public void Update(Cita cita)
        {
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }

        public void Inactive(int id)
        {
            var cita = _context.Citas.Find(id);

            cita.Estado = "Inactivo";
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }

        public void Active(int id)
        {
            var cita = _context.Citas.Find(id);

            cita.Estado = "Activo";
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }
    }
}