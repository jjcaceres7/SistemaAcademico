using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalities { get; set; } = Helpers.OpcionesModalidad.List;
        public List<string> Titles { get; set; } = Helpers.OpcionesTitles.List;
        public void OnGet()
        {
            Modalities = OpcionesModalidad.List;
            Titles = OpcionesTitles.List;
        }
        

        public IActionResult OnPost()
        {
            Modalities = OpcionesModalidad.List;
            Titles = OpcionesTitles.List;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Carrera.Id = DatosCompartidos.ObtenerNuevoIdCarreras();
            DatosCompartidos.Carreras.Add(Carrera);
            return RedirectToPage("Index");
        }
    }
}
