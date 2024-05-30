using Microsoft.EntityFrameworkCore;
using SimulacroHospital.Models;

namespace SimulacroHospital.Data
{
    public class SimulacroHospitalContext : DbContext
    {
        public SimulacroHospitalContext(DbContextOptions<SimulacroHospitalContext> options) : base(options) {}

        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}