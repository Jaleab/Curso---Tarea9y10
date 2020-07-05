using Notas.Models;
using Notas.Services;
using System.Web.Mvc;

namespace Notas.Controllers
{
    public class EstudianteController : Controller
    {
        EstudianteService estudianteService = new EstudianteService();
        public ActionResult VerEstudiantes()
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"];
            }
            return View(estudianteService.GetEstudiantes());
        }

        public ActionResult CrearEstudiante()
        {       
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(EstudianteModel estudiante)
        {           
            estudianteService.AgregarEstudiante(estudiante);

            EvaluacionService evaluacionService = new EvaluacionService();
            evaluacionService.AgregarEvaluacion(estudiante.carne);

            TempData["mensaje"] = "El estudiante " + estudiante.nombreCompleto + " ha sido agregado al curso.";
            return RedirectToAction("VerEstudiantes");
        }
    }
}