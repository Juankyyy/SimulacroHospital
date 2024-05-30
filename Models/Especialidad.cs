using System.ComponentModel.DataAnnotations;

namespace SimulacroHospital.Models
{
    public class Especialidad
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public  string? Nombre { get; set; }

        [Required]
        public string? Descripcion { get; set;}

        [Required]
        public string? Estado { get; set; }
    }
}