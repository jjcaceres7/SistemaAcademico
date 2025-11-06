using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace SistemaAcademico.Servicios
{
    public class ServicioLibro
    {
        private readonly IRepositorio<Libro> _repo;
        public ServicioLibro(IRepositorio<Libro> repo)
        {
            _repo = repo;
        }
        public List<Libro> ObtenerDatos()
        {
            return _repo.ObtenerDatos();
        }
        public Libro? BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }
        public void Agregar(Libro Libro)
        {
            _repo.Agregar(Libro);
        }
        public void Editar(Libro Libro)
        {
            _repo.Editar(Libro);
        }
        public void EliminarPorId(int id)
        {
            _repo.EliminarPorId(id);
        }


    }
}
