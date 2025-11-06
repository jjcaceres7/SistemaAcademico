using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Libros
{
    public class IndexModel : PageModel
    {
        public List<Libro> Libro { get; set; }

        private readonly ServicioLibro servicio;
        public IndexModel()
        {
            IAccesoDatos<Libro> acceso = new AccesoDatosJson<Libro>("Libros");
            IRepositorio<Libro> repo = new RepositorioCrudJson<Libro>(acceso);
            servicio = new ServicioLibro(repo);
        }
        public void OnGet()
        {
            Libro = servicio.ObtenerDatos();
        }
    }
}
