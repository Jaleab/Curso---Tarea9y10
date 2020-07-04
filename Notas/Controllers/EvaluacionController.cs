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
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(EvaluacionModel evaluacion)
        {
            EvaluacionService evaluacionService = new EvaluacionService();
            //cursoService.AgregarCurso(evaluacion);
            //TempData["mensaje"] = "El curso " + curso.nombre+ " ha sido agregado al curso.";
            return RedirectToAction("VerEstudiantes", "Estudiante");
        }

        public ActionResult VerEvaluacion(string carne)
        {
            EvaluacionService evaluacionService= new EvaluacionService();
            return View(evaluacionService.GetEvaluacionEstudiante(carne));
        }

        [HttpPost]
        public ActionResult AgregarNota(string[] dynamicField)
        {
            ViewBag.Data = string.Join(",", dynamicField ?? new string[] { });
            return View();
        }
    }
}