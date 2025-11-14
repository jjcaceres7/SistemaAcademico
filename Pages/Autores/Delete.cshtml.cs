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
        private readonly ServicioLibro servicioLibro;

        public string ErrorMessage { get; set; }
        public DeleteModel()
        {
            IAccesoDatos<Autor> acceso = new AccesoDatosJson<Autor>("Autores");
            IRepositorio<Autor> repo = new RepositorioCrudJson<Autor>(acceso);
            servicio = new ServicioAutor(repo);

            IAccesoDatos<Libro> accesoLibro = new AccesoDatosJson<Libro>("Libros");
            IRepositorio<Libro> repoLibro = new RepositorioCrudJson<Libro>(accesoLibro);
            servicioLibro = new ServicioLibro(repoLibro);


        }
        public IActionResult OnGet(int id)
        {
            var autor = servicio.BuscarPorId(id);
            if (autor == null)
            {
                return RedirectToPage("Index");
            }
            Autor = autor;


            var libros = servicioLibro.BuscarPorIdAutor(id);
            if (libros.Count > 0)
            {
                TempData["ErrorMessage"] =
                    "No se puede eliminar el autor porque está asociado a varios libros.";
                return RedirectToPage("Index");
            }

            return Page();
        }
        public IActionResult OnPost(int id)
        {
            servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }
    }
}
