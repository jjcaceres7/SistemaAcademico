﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SistemaAcademico.Models
{
    public class Carrera
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "debe agregar un nombre")]
        [StringLength(50, ErrorMessage = "no puede superar los 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "debe agregar un numero")]
        public int Years { get; set; }

        [Required(ErrorMessage = "debe seleccionar un titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "debe seleccionar una modalidad")]
        public string Modality { get; set; }
    }
}