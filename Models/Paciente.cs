using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimulacroHospital.Models
{
    public class Paciente
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string? Nombres { get; set; }

        [Required]
        public string? Apellidos { get; set; }

        [Required]
        public DateOnly? FechaNacimiento { get; set; }

        [Required]
        public string? Correo { get; set; }
        
        [Required]
        public string? Telefono { get; set; }
        
        [Required]
        public string? Direccion { get; set; }

        [Required]
        public string? Estado { get; set; }

        [JsonIgnore]
        public List<Cita>? Citas { get; set;}
    }
}