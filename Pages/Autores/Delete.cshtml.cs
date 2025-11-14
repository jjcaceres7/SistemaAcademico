using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Autores
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Autor Autor { get; set; }

        private readonly ServicioAutor servicio;
        public DeleteModel()
        {
            IAccesoDatos<Autor> acceso = new AccesoDatosJson<Autor>("Autores");
            IRepositorio<Autor> repo = new RepositorioCrudJson<Autor>(acceso);
            servicio = new ServicioAutor(repo);
        }
        public IActionResult OnGet(int id)
        {
            var autor = servicio.BuscarPorId(id);
            if (autor == null)
            {
                return RedirectToPage("Index");
            }

            Autor = autor;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
