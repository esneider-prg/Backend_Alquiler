using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Alquiler
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID del CLIENTE es obligatorio y debe ser un entero valido dentro del rango")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La fecha del alquiler es obligatoria")]
        public string FechaAlquiler { get; set; }

        [Range(1000, int.MaxValue, ErrorMessage = "El valor del alquiler es obligatorio y debe ser un entero valido dentro del rango")]
        public int ValorAlquiler { get; set; }

        public Cliente Cliente { get; set; }
    }
}
