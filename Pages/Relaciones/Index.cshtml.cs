using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaAcademico.Pages.Relaciones
{
    public class IndexModel : PageModel
    {
        public List<Libro> Libro { get; set; }
        public Dictionary<int, Autor> AutorMap { get; set; }
        private readonly ServicioLibro servicio;
        
        public string DatosJson { get; set; }
        public string DatosAutores { get; set; }

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
            DatosAutores = JsonSerializer.Serialize(AutorMap);
            DatosJson = JsonSerializer.Serialize(Libro);
        }




    }
}
