using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "debe agregar un titulo")]
        [StringLength(50, ErrorMessage = "no puede superar los 50 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "debe agregar un autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "debe agregar un año")]
        public int Year { get; set; }

        [Required(ErrorMessage = "debe agregar al menos un genero")]
        public string Genders { get; set; }

        
    
    }

}
