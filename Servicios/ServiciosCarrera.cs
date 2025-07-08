using System.IO;
using System.Text.Json;             
using SistemaAcademico.Models;
using SistemaAcademico.Data;
using System.Collections.Generic;

namespace SistemaAcademico.Servicios
{
    public class ServiciosCarrera
    {
        private static string path = "Data/Carreras.json";
        public static string LeerTextoDeJson()
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return "[]";
        }
        public static List<Carrera> ObtenerCarrerasLista()
        {
            string json = LeerTextoDeJson();
            var ListCarreras = JsonSerializer.Deserialize<List<Carrera>>(json);
            return ListCarreras ?? new List<Carrera>();
        }

        public static void Agregarcarrera(Carrera nuevaCarrera)
        {
            var carreras = ObtenerCarrerasLista(); 
            nuevaCarrera.Id = DatosCompartidos.ObtenerNuevoIdCarreras();
            carreras.Add(nuevaCarrera);
            GuardarCarreras(carreras);
        }

        public static void GuardarCarreras(List<Carrera> carreras)
        {
            string json = JsonSerializer.Serialize(carreras);
            File.WriteAllText(path, json);
        }

        public static Carrera? ObtenerCarreraPorId(int id)
        {
            var carreras = ObtenerCarrerasLista();
            return carreras.Find(c => c.Id == id);
        }

        public static void EliminarCarrera(int id)
        {
            var carreras = ObtenerCarrerasLista();
            var carreraAEliminar = BuscarCarreraPorId(carreras, id);
            if (carreraAEliminar != null)
            {
                carreras.Remove(carreraAEliminar);
                GuardarCarreras(carreras);
            }
        }


        public static void EditarCarrera(Carrera carreraEditada)
        {
            var carreras = ObtenerCarrerasLista();
            var Carrera = BuscarCarreraPorId(carreras, carreraEditada.Id);

            if (Carrera != null)
                {
                    Carrera.Name = carreraEditada.Name;
                    Carrera.Modality = carreraEditada.Modality;
                    Carrera.Years = carreraEditada.Years;
                    Carrera.Title = carreraEditada.Title;
                }

            GuardarCarreras(carreras);
        }

        private static Carrera? BuscarCarreraPorId(List<Carrera> lista, int id)
        {
            foreach (var carrera in lista)
            {
                if (carrera.Id == id)
                {
                    return carrera;
                }
            }
            return null;
        }
    }
}
