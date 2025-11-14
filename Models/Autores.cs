using System.ComponentModel.DataAnnotations;

namespace SistemaAcademico.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe agregar un nombre")]
        [StringLength(50, ErrorMessage = "no puede superar los 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe agregar la nacionalidad el autor")]
        public string Country { get; set; }

               
    
    }

}
