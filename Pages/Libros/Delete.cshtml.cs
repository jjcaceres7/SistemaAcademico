using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Libros
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Libro Libro { get; set; }

        private readonly ServicioLibro servicio;
        public DeleteModel()
        {
            IAccesoDatos<Libro> acceso = new AccesoDatosJson<Libro>("Libros");
            IRepositorio<Libro> repo = new RepositorioCrudJson<Libro>(acceso);
            servicio = new ServicioLibro(repo);
        }
        public IActionResult OnGet(int id)
        {
            var libro = servicio.BuscarPorId(id);
            if (libro == null)
            {
                return RedirectToPage("Index");
            }

            Libro = libro;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
