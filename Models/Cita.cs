using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimulacroHospital.Models
{
    public class Cita
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MedicoId { get; set; }

        public Medico? Medico { get; set; }

        [Required]
        public int PacienteId { get; set; }

        public Paciente? Paciente { get; set; }

        [Required]
        public DateOnly Fecha { get; set; }

        [Required]
        public string? Estado { get; set; }
    }
}