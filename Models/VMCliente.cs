using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnicaBitsion.Models
{
    public class VMCliente
    {
        public Cliente ClienteModel { get; set; }
        public List<Genero> Generos { get; set; }
    }
}