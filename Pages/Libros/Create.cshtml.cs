using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;


namespace SistemaAcademico.Pages.Libros
{
    public class CreateModel : PageModel
    {


        [BindProperty]
        public Libro Libro { get; set; }

        private readonly ServicioLibro servicio;
        public CreateModel()
        {
            IAccesoDatos<Libro> acceso = new AccesoDatosJson<Libro>("Libros");
            IRepositorio<Libro> repo = new RepositorioCrudJson<Libro>(acceso);
            servicio = new ServicioLibro(repo);
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            servicio.Agregar(Libro);

            return RedirectToPage("Index");
        }
    }
}
