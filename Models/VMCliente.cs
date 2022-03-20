using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnicaBitsion.Models
{
    public class VMCliente
    {
        public Clientes ClienteModel { get; set; }
        public List<Generos> Generos { get; set; }
    }
}