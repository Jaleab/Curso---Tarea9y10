using Notas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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




    }
}