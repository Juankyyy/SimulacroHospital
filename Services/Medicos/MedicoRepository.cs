using Microsoft.EntityFrameworkCore;
using SimulacroHospital.Data;
using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly SimulacroHospitalContext _context;

        public MedicoRepository(SimulacroHospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> GetAll()
        {
            var medicos = _context.Medicos.Include(m => m.Especialidad).ToList();
            
            return medicos;
        }

        public Medico GetOne(int id)
        {
            var medico = _context.Medicos.Include(m => m.Especialidad).FirstOrDefault(m => m.Id == id);
            
            return medico;
        }

        public void Create(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public void Update(Medico medico)
        {
            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }

        public void Inactive(int id)
        {
            var medico = _context.Medicos.Find(id);

            medico.Estado = "Inactivo";
            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }

        public void Active(int id)
        {
            var medico = _context.Medicos.Find(id);

            medico.Estado = "Activo";
            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }
    }
}