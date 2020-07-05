using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notas.Controllers;
using Notas.Models;

namespace Notas.Tests.Controllers
{
    [TestClass]
    public class EvaluacionControllerTest
    {
        [TestMethod]
        public void VerEvaluacionNotNull()
        {
            EvaluacionController controller = new EvaluacionController();

            ViewResult resultado = controller.VerEvaluacion("NADA") as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void EditarInvestigacionNotNull()
        {
            EvaluacionController controller = new EvaluacionController();

            ViewResult resultado = controller.EditarInvestigacion("NADA") as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CalificarInvestigacionRedirected()
        {
            EvaluacionController controller = new EvaluacionController();

            EvaluacionModel evaluacion = new EvaluacionModel();
            var resultado = (RedirectToRouteResult)controller.CalificarInvestigacion(evaluacion, "NADA");

            Assert.IsTrue(resultado.RouteValues["action"].Equals("VerEvaluacion"));
            Assert.IsTrue(resultado.RouteValues["controller"].Equals("Evaluacion"));
            Assert.AreEqual("NADA", resultado.RouteValues["carne"]);
        }

        [TestMethod]
        public void EditarParticipacionNotNull()
        {
            EvaluacionController controller = new EvaluacionController();

            ViewResult resultado = controller.EditarParticipacion("B70018") as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CalificarParticipacionRedirected()
        {
            EvaluacionController controller = new EvaluacionController();

            EvaluacionModel evaluacion = new EvaluacionModel();
            var resultado = (RedirectToRouteResult)controller.CalificarParticipacion(evaluacion, "NADA");

            Assert.IsTrue(resultado.RouteValues["action"].Equals("VerEvaluacion"));
            Assert.IsTrue(resultado.RouteValues["controller"].Equals("Evaluacion"));
            Assert.AreEqual("NADA", resultado.RouteValues["carne"]);
        }

        [TestMethod]
        public void EditarExamenesNotNull()
        {
            EvaluacionController controller = new EvaluacionController();

            ViewResult resultado = controller.EditarExamenes("B70018") as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CalificarExamenesRedirected()
        {
            string[] notasVacias = {};
            EvaluacionController controller = new EvaluacionController();

            EvaluacionModel evaluacion = new EvaluacionModel();
            var resultado = (RedirectToRouteResult)controller.CalificarExamenes(notasVacias, "NADA");

            Assert.IsTrue(resultado.RouteValues["action"].Equals("VerEvaluacion"));
            Assert.IsTrue(resultado.RouteValues["controller"].Equals("Evaluacion"));
            Assert.AreEqual("NADA", resultado.RouteValues["carne"]);
        }
        [TestMethod]
        public void EditarLaboratoriosNotNull()
        {
            EvaluacionController controller = new EvaluacionController();

            ViewResult resultado = controller.EditarLaboratorios("NADA") as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CalificarLaboratoriosRedirected()
        {
            string[] notasVacias = { };
            EvaluacionController controller = new EvaluacionController();

            EvaluacionModel evaluacion = new EvaluacionModel();
            var resultado = (RedirectToRouteResult)controller.CalificarLaboratorios(notasVacias, "NADA");

            Assert.IsTrue(resultado.RouteValues["action"].Equals("VerEvaluacion"));
            Assert.IsTrue(resultado.RouteValues["controller"].Equals("Evaluacion"));
            Assert.AreEqual("NADA", resultado.RouteValues["carne"]);
        }

        [TestMethod]
        public void EditarCCQTNotNull()
        {
            EvaluacionController controller = new EvaluacionController();

            ViewResult resultado = controller.EditarCCQT("NADA") as ViewResult;

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void CalificarCCQTRedirected()
        {
            string[] notasVacias = { };
            EvaluacionController controller = new EvaluacionController();

            EvaluacionModel evaluacion = new EvaluacionModel();
            var resultado = (RedirectToRouteResult)controller.CalificarCCQT(notasVacias, "NADA");

            Assert.IsTrue(resultado.RouteValues["action"].Equals("VerEvaluacion"));
            Assert.IsTrue(resultado.RouteValues["controller"].Equals("Evaluacion"));
            Assert.AreEqual("NADA", resultado.RouteValues["carne"]);
        }
    }
}
