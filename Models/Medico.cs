using System.ComponentModel.DataAnnotations;

namespace SimulacroHospital.Models
{
    public class Medico
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? NombreCompleto { get; set; }

        [Required]
        public int EspecialidadId { get; set; }

        public Especialidad? Especialidad { get; set; }

        [Required]
        public string? Correo { get; set; }

        [Required]
        public string? Telefono { get; set; }

        [Required]
        public string? Estado { get; set; }
    }
}