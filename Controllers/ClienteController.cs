using PruebaTecnicaBitsion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PruebaTecnicaBitsion.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            List<DTOCliente> clientes;
            using (FicticiaEntities db = new FicticiaEntities())
            {
                clientes = (from c in db.Clientes
                            join g in db.Generos on c.idGenero equals g.idGenero
                            select new DTOCliente()
                            {
                                Id = c.idCliente,
                                Nombre = c.nombre,
                                DNI = c.dni,
                                Nacimiento = c.nacimiento,
                                Estado = c.estado,
                                Maneja = c.maneja,
                                Lentes = c.lentes,
                                Diabetico = c.diabetico,
                                Descripcion = g.descripcion
                            }).ToList();
            }
            return View(clientes);
        }

        public ActionResult AltaCliente()
        {
            List<Generos> generos;
            VMCliente cliente = new VMCliente();
            using (FicticiaEntities db = new FicticiaEntities())
            {
                var lista = db.Generos;
                foreach (Generos g in lista)
                {
                    lista.Add(g);
                }
                generos = lista.ToList();
            }
            cliente.Generos = generos;
            return View(cliente);
        }
        [HttpPost]
        public ActionResult AltaCliente(VMCliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (FicticiaEntities db = new FicticiaEntities())
                {
                    if (!String.IsNullOrWhiteSpace(cliente.ClienteModel.enfermedades))
                    {
                        db.Clientes.Add(cliente.ClienteModel);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        cliente.ClienteModel.enfermedades = "N/A";
                        db.Clientes.Add(cliente.ClienteModel);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
            }
            return View(cliente);
        }

        public ActionResult EditarCliente(int idCliente)
        {
            List<Generos> generos;
            VMCliente cliente = new VMCliente();
            using (FicticiaEntities db = new FicticiaEntities())
            {
                cliente.ClienteModel = db.Clientes.Find(idCliente);
                var lista = db.Generos;
                foreach (Generos g in lista)
                {
                    lista.Add(g);
                }
                generos = lista.ToList();
            }
            cliente.Generos = generos;
            return View(cliente);
        }
        [HttpPost]
        public ActionResult EditarCliente(VMCliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (FicticiaEntities db = new FicticiaEntities())
                {
                    var editado = db.Clientes.Find(cliente.ClienteModel.idCliente);
                    editado.nombre = cliente.ClienteModel.nombre;
                    editado.nacimiento = cliente.ClienteModel.nacimiento;
                    editado.dni = cliente.ClienteModel.dni;
                    editado.estado = cliente.ClienteModel.estado;
                    editado.maneja = cliente.ClienteModel.maneja;
                    editado.lentes = cliente.ClienteModel.lentes;
                    editado.diabetico = cliente.ClienteModel.diabetico;
                    editado.enfermedades = cliente.ClienteModel.enfermedades;

                    db.Entry(editado).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult EliminarCliente(int idCliente)
        {
            List<Generos> generos;
            VMCliente cliente = new VMCliente();
            using (FicticiaEntities db = new FicticiaEntities())
            {
                cliente.ClienteModel = db.Clientes.Find(idCliente);
                var lista = db.Generos;
                foreach (Generos g in lista)
                {
                    lista.Add(g);
                }
                generos = lista.ToList();
            }
            cliente.Generos = generos;
            return View(cliente);
        }
        [HttpPost]
        public ActionResult EliminarCliente(VMCliente cliente)
        {
            using (FicticiaEntities db = new FicticiaEntities())
            {
                var eliminado = db.Clientes.Find(cliente.ClienteModel.idCliente);
                db.Clientes.Remove(eliminado);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}