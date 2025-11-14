using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Autores
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Autor Autor { get; set; }
        public List<Autor> Autores { get; set; }

        private readonly ServicioAutor servicio;
        public EditModel()
        {
            IAccesoDatos<Autor> acceso = new AccesoDatosJson<Autor>("Autores");
            IRepositorio<Autor> repo = new RepositorioCrudJson<Autor>(acceso);
            servicio = new ServicioAutor(repo);
        }
        public void OnGet(int id)
        {
            Autor? autor = servicio.BuscarPorId(id);
            if (autor != null)
            {
                Autor = autor;
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

            servicio.Editar(Autor);

            return RedirectToPage("Index");
        }
    }
}
