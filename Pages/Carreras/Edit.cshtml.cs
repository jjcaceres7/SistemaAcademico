using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Carreras
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalities { get; set; } = Helpers.OpcionesModalidad.List;

        private readonly ServicioCarrera Servicio;
        public EditModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatosJson<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            Servicio = new ServicioCarrera(repo);
        }
        public void OnGet(int id)
        {
            Modalities = OpcionesModalidad.List;

            Carrera carrera = Servicio.BuscarPorId(id);
            if (carrera != null)
            {
                Carrera = carrera;
            }
        }
        public IActionResult OnPost()
        {
            Modalities = OpcionesModalidad.List;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Servicio.Editar(Carrera);

            return RedirectToPage("Index");
        }
    }
}
