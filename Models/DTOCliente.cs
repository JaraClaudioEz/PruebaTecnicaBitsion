using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnicaBitsion.Models
{
    public class DTOCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public bool Estado { get; set; }
        public bool Maneja { get; set; }
        public bool Lentes { get; set; }
        public bool Diabetico { get; set; }
        public int DNI { get; set; }
        public string Descripcion { get; set; }

        public int calcularEdad()
        {
            TimeSpan edad = DateTime.Today - Nacimiento;
            DateTime total = new DateTime(edad.Ticks);
            return total.Year - 1;
        }
    }
}