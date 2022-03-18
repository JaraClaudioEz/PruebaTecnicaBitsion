using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaBitsion.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Genero { get; set; }
        public bool Estado { get; set; }
        public bool Maneja { get; set; }
        public bool Lentes { get; set; }
        public bool Diabetico { get; set; }
        public string Enfermedades { get; set; }
        public int DNI { get; set; }

        public int calcularEdad()
        {
            return 0;
        }

    }
}