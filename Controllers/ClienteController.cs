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
            List<DTOCliente> clientes = gestor.ListadoClientes();
            return View(clientes);
        }

        public ActionResult AltaCliente()
        {
            GestorBD gestor = new GestorBD(); 
            VMCliente cliente = new VMCliente();
            cliente.Generos = gestor.ListadoGeneros(); ;
            return View(cliente);
        }
        [HttpPost]
        public ActionResult AltaCliente(VMCliente cliente)
        {
            GestorBD gestor = new GestorBD();

            if (!String.IsNullOrWhiteSpace(cliente.ClienteModel.Enfermedades))
            {
                gestor.CrearCliente(cliente.ClienteModel); 
                return View("Index", gestor.ListadoClientes());
            }
            else
            {
                cliente.ClienteModel.Enfermedades = "Ninguna"; //Hardcodeo temporal
                gestor.CrearCliente(cliente.ClienteModel);
                return View("Index", gestor.ListadoClientes());
            }
            
        }

        public ActionResult EditarCliente(int idCliente)
        {
            GestorBD gestor = new GestorBD();
            VMCliente cliente = gestor.BuscarCliente(idCliente);
            cliente.Generos = gestor.ListadoGeneros();
            return View(cliente);
        }
        [HttpPost]
        public ActionResult EditarCliente(VMCliente cliente)
        {
            GestorBD gestor = new GestorBD();

            if (!String.IsNullOrWhiteSpace(cliente.ClienteModel.Enfermedades))
            {
                gestor.EditarCliente(cliente.ClienteModel);
                return RedirectToAction("Index");
            }
            else
            {
                cliente.ClienteModel.Enfermedades = "Ninguna"; //Hardcodeo temporal
                gestor.EditarCliente(cliente.ClienteModel);
                return RedirectToAction("Index"); //No especifico controller por que me muevo en el mismo. 
            }
        }

        public ActionResult EliminarCliente(int idCliente)
        {
            GestorBD gestor = new GestorBD();
            VMCliente cliente = gestor.BuscarCliente(idCliente);
            cliente.Generos = gestor.ListadoGeneros();
            return View(cliente);
        }
        [HttpPost]
        public ActionResult EliminarCliente(VMCliente cliente)
        {
            GestorBD gestor = new GestorBD();

            if (!String.IsNullOrWhiteSpace(cliente.ClienteModel.Enfermedades))
            {
                gestor.EliminarCliente(cliente.ClienteModel);
                return RedirectToAction("Index");
            }
            else
            {
                cliente.ClienteModel.Enfermedades = "Ninguna"; //Hardcodeo temporal
                gestor.EliminarCliente(cliente.ClienteModel);
                return RedirectToAction("Index"); 
            }
        }
    }
}