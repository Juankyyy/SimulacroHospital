using Microsoft.EntityFrameworkCore;
using SimulacroHospital.Data;
using SimulacroHospital.Models;

namespace SimulacroHospital.Services
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly SimulacroHospitalContext _context;

        public PacienteRepository(SimulacroHospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente GetOne(int id)
        {
            return _context.Pacientes.Find(id);
        }

        public void Create(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Inactive(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            paciente.Estado = "Inactivo";
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Active(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            paciente.Estado = "Activo";
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }
    }
}