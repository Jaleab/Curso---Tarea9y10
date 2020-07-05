using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notas.Controllers;
using Notas.Models;

namespace Notas.Tests.Controllers
{
    [TestClass]
    public class EstudianteControllerTest
    {
        [TestMethod]
        public void VerEstudiantesIsNotNull()
        {
            EstudianteController controller = new EstudianteController();

            ViewResult resultado = controller.VerEstudiantes() as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CrearEstudianteIsNotNull()
        {
            EstudianteController controller = new EstudianteController();

            ViewResult resultado = controller.CrearEstudiante() as ViewResult;

            Assert.IsNotNull(resultado);
        }
    }
}
