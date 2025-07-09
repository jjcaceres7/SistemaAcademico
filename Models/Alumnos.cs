using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Alumno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "debe agregar nombre/s")]
        [StringLength(50, ErrorMessage = "no puede superar los 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "debe agregar apellido/s")]
        [StringLength(50, ErrorMessage = "no puede superar los 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "debe agregar el DNI")]
        [StringLength(10, ErrorMessage = "no puede superar los 10 caracteres")]
        public string Dni { get; set; }


        [Required(ErrorMessage = "debe agregar un email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "agregue fecha de nacimiento")]
        public DateOnly DateOfBirth { get; set; }

    }
}