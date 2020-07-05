using Notas.Models;
using Notas.Services;
using System.Web.Mvc;

namespace Notas.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerEstudiantes()
        {
            EstudianteService estudianteService = new EstudianteService();
            return View(estudianteService.GetEstudiantes());
        }

        public ActionResult CrearEstudiante()
        {
            EstudianteService estudianteService = new EstudianteService();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(EstudianteModel estudiante)
        {
            EstudianteService estudianteService = new EstudianteService();
            estudianteService.AgregarEstudiante(estudiante);

            EvaluacionService evaluacionService = new EvaluacionService();
            evaluacionService.AgregarEvaluacion(estudiante.carne);

            TempData["mensaje"] = "El estudiante " + estudiante.nombreCompleto + " ha sido agregado al curso.";
            return RedirectToAction("VerEstudiantes");
        }
    }
}