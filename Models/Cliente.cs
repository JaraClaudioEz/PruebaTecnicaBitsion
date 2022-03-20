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
        [Required(ErrorMessage = "Introduzca un nombre!")]
        [StringLength(50, ErrorMessage = "Su nombre debe ser de al menos de 10 caracteres y no superar los 50.", MinimumLength = 10)]
        [RegularExpression(@"[a-zA-Z ]{2,254}", ErrorMessage = "No se permiten caracteres especiales ;)")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Seleccione una fecha de nacimiento.")]
        public DateTime Nacimiento { get; set; }
        [Required(ErrorMessage = "Seleccione un género!")]
        public int IdGenero { get; set; }
        public bool Estado { get; set; }
        public bool Maneja { get; set; }
        public bool Lentes { get; set; }
        public bool Diabetico { get; set; }
        public string Enfermedades { get; set; }
        [Range(999999, 99999999)]
        public int DNI { get; set; }

        public int calcularEdad()
        {
            TimeSpan edad = DateTime.Today - Nacimiento;
            DateTime total = new DateTime(edad.Ticks);
            return total.Year - 1;
        }
    }
}