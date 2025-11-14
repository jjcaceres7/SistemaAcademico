using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;

namespace SistemaAcademico.Pages.Libros
{
    public class IndexModel : PageModel
    {
        public List<Libro> Libro { get; set; }
        // public List<string> Autores { get; set; }
        public Dictionary<int, Autor> AutorMap { get; set; }

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
            var opciones = new OpcionesAutores();
            AutorMap = opciones.AutorMap;

            //var opciones = new Helpers.OpcionesAutores();
            //Autores = opciones.Autor.Select(a => a.Name).ToList();

        }
    }
}
