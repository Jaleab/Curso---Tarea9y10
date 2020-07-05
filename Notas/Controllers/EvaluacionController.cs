using Notas.Models;
using Notas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notas.Controllers
{
    public class EvaluacionController : Controller
    {
        EvaluacionService evaluacionService = new EvaluacionService();
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(EvaluacionModel evaluacion)
        {
            //cursoService.AgregarCurso(evaluacion);
            //TempData["mensaje"] = "El curso " + curso.nombre+ " ha sido agregado al curso.";
            return RedirectToAction("VerEstudiantes", "Estudiante");
        }

        public ActionResult VerEvaluacion(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        public ActionResult EditarInvestigacion(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult CalificarInvestigacion(EvaluacionModel evaluacion, string carne)
        {
            evaluacionService.ModificarInvestigacion(evaluacion, carne);
            TempData["mensaje"] = "La investigacion ha sido calificada.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne = carne});
        }

        public ActionResult EditarParticipacion(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult CalificarParticipacion(EvaluacionModel evaluacion, string carne)
        {
            evaluacionService.ModificarInvestigacion(evaluacion, carne);
            TempData["mensaje"] = "La participacion en foros ha sido calificada.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne = carne });
        }

        [HttpPost]
        public ActionResult CalificarAlgo(string[] dynamicField, string carne)
        {
            ViewBag.Data = string.Join(",", dynamicField ?? new string[] { });
            TempData["mensaje"] = "La investigacion ha sido calificada.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne = carne });
        }
    }
}