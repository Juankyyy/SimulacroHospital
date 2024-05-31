using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimulacroHospital.Models
{
    public class Tratamiento
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CitaId { get; set; }
        public Cita? Cita { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? Estado { get; set; }
    }
}