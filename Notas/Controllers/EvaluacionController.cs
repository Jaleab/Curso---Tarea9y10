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
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne});
        }

        public ActionResult EditarParticipacion(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult CalificarParticipacion(EvaluacionModel evaluacion, string carne)
        {
            evaluacionService.ModificarParticipacion(evaluacion, carne);
            TempData["mensaje"] = "La participacion en foros ha sido calificada.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne });
        }

        public ActionResult EditarExamenes(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult CalificarExamenes(string[] notas, string carne)
        {
            //ViewBag.Data = string.Join(",", notas ?? new string[] { });
            evaluacionService.ModificarExamenes(notas, carne);
            TempData["mensaje"] = "Los examenes han sido calificados.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne });
        }

        public ActionResult EditarLaboratorios(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult CalificarLaboratorios(string[] notas, string carne)
        {
            //ViewBag.Data = string.Join(",", notas ?? new string[] { });
            evaluacionService.ModificarLaboratorios(notas, carne);
            TempData["mensaje"] = "Los laboratorios han sido calificados.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne });
        }

        public ActionResult EditarCCQT(string carne)
        {
            ViewBag.carne = carne;
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult CalificarCCQT(string[] notas, string carne)
        {
            bool valido = true;
            int i = 0;
            while (valido == true && i < notas.Length) {
                if (notas[i] == "") {
                    valido = false;
                }
                i += 1;
            }
            if(valido == true)
            {
                evaluacionService.ModificarCCQT(notas, carne);
            }
            TempData["mensaje"] = "Los laboratorios han sido calificados.";
            return RedirectToAction("VerEvaluacion", "Evaluacion", new { carne });
        }
    }
}