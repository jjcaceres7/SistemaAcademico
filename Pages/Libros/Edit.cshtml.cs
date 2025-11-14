using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Libros
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Libro Libro { get; set; }
        public List<Autor> Autores { get; set; }

        private readonly ServicioLibro servicio;
        public EditModel()
        {
            IAccesoDatos<Libro> acceso = new AccesoDatosJson<Libro>("Libros");
            IRepositorio<Libro> repo = new RepositorioCrudJson<Libro>(acceso);
            servicio = new ServicioLibro(repo);
        }
        public void OnGet(int id)
        {
            Libro? libro = servicio.BuscarPorId(id);
            if (libro != null)
            {
                Libro = libro;
            }
            var opciones = new Helpers.OpcionesAutores();
            Autores = opciones.Autor;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            servicio.Editar(Libro);

            return RedirectToPage("Index");
        }
    }
}
