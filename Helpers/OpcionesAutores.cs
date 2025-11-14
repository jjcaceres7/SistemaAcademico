using SistemaAcademico.AccesoDatos;
using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using SistemaAcademico.Servicios;


namespace SistemaAcademico.Helpers
{
    public class OpcionesAutores
    {
        public List<Autor> Autor { get; set; }

        private readonly ServicioAutor _servicioAutor;
        public Dictionary<int, Autor> AutorMap { get; set; }

        public OpcionesAutores()
        {
            // inicializa correctamente el servicio
            IAccesoDatos<Autor> accesoAutor = new AccesoDatosJson<Autor>("Autores");
            IRepositorio<Autor> repoAutor = new RepositorioCrudJson<Autor>(accesoAutor);
            _servicioAutor = new ServicioAutor(repoAutor);

            Autor = _servicioAutor.ObtenerDatos();
            AutorMap = Autor.ToDictionary(a => a.Id, a => a);
        }
    }
}

// @Model.AutorMap.GetValueOrDefault(int.TryParse(libro.Autor, out var id) ? id : -1)?.Name