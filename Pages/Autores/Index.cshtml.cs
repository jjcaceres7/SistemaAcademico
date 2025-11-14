using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Autores
{
    public class IndexModel : PageModel
    {
        public List<Autor> Autor { get; set; }

        private readonly ServicioAutor servicio;
        public IndexModel()
        {
            IAccesoDatos<Autor> acceso = new AccesoDatosJson<Autor>("Autores");
            IRepositorio<Autor> repo = new RepositorioCrudJson<Autor>(acceso);
            servicio = new ServicioAutor(repo);

        
        }
        public void OnGet()
        {
            Autor = servicio.ObtenerDatos();

            //var opciones = new Helpers.OpcionesAutores();
            //Autores = opciones.Autor.Select(a => a.Name).ToList();

        }
    }
}
