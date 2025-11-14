using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;


namespace SistemaAcademico.Pages.Autores
{
    public class CreateModel : PageModel
    {


        [BindProperty]
        public Autor Autor { get; set; }

        private readonly ServicioAutor servicio;
        public CreateModel()
        {
            IAccesoDatos<Autor> acceso = new AccesoDatosJson<Autor>("Autores");
            IRepositorio<Autor> repo = new RepositorioCrudJson<Autor>(acceso);
            servicio = new ServicioAutor(repo);
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

            servicio.Agregar(Autor);

            return RedirectToPage("Index");
        }
    }
}
