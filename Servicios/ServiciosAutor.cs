using SistemaAcademico.Models;
using SistemaAcademico.Repositorio;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace SistemaAcademico.Servicios
{
    public class ServicioAutor
    {
        private readonly IRepositorio<Autor> _repo;
        public ServicioAutor(IRepositorio<Autor> repo)
        {
            _repo = repo;
        }
        public List<Autor> ObtenerDatos()
        {
            return _repo.ObtenerDatos();
        }
        public Autor? BuscarPorId(int id)
        {
            return _repo.BuscarPorId(id);
        }
        public void Agregar(Autor Autor)
        {
            _repo.Agregar(Autor);
        }
        public void Editar(Autor Autor)
        {
            _repo.Editar(Autor);
        }
        public void EliminarPorId(int id)
        {
            _repo.EliminarPorId(id);
        }


    }
}
