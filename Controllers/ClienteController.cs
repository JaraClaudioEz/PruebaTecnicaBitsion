using PruebaTecnicaBitsion.AccesoDatos;
using PruebaTecnicaBitsion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnicaBitsion.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            GestorBD gestor = new GestorBD();
            List<Cliente> clientes = gestor.ListadoClientes();
            return View(clientes);
        }

        public ActionResult AltaCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AltaCliente(Cliente cliente)
        {
            GestorBD gestor = new GestorBD();

            if (!String.IsNullOrWhiteSpace(cliente.Enfermedades))
            {
                gestor.CrearCliente(cliente); 
                return View("Index", gestor.ListadoClientes());
            }
            else
            {
                cliente.Enfermedades = "Ninguna"; //Hardcodeo temporal
                gestor.CrearCliente(cliente);
                return View("Index", gestor.ListadoClientes());
            }
            
        }

        public ActionResult EditarCliente(int idCliente)
        {
            GestorBD gestor = new GestorBD();
            var cliente = gestor.BuscarCliente(idCliente);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult EditarCliente(Cliente cliente)
        {
            GestorBD gestor = new GestorBD();

            if (!String.IsNullOrWhiteSpace(cliente.Enfermedades))
            {
                gestor.EditarCliente(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                cliente.Enfermedades = "Ninguna"; //Hardcodeo temporal
                gestor.EditarCliente(cliente);
                return RedirectToAction("Index"); //No especifico controller por que me muevo en el mismo. 
            }
        }
    }
}