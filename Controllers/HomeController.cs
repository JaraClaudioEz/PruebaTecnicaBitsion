using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaBitsion.AccesoDatos;

namespace PruebaTecnicaBitsion.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            GestorBD gestor = new GestorBD();
            //gestor.CrearCliente("prueba", DateTime.Now, "femenino", true, true, false, false, "");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}