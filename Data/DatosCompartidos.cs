﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using SistemaAcademico.Models;

namespace SistemaAcademico.Data
{
    public class DatosCompartidos
    {
        public static List<Carrera> Carreras { get; set; } = new();
        public static List<Alumno> Alumnos { get; set; } = new();
        private static int ultimoIdCarreras = 0;
        private static int ultimoIdAlumnos = 0;
        public static int ObtenerNuevoIdCarreras()
        {
            ultimoIdCarreras++;
            return ultimoIdCarreras;
        }
        public static int ObtenerNuevoIdAlumnos()
        {
            ultimoIdAlumnos++;
            return ultimoIdAlumnos;
        }
    }
}
