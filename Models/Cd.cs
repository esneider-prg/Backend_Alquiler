using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Cd
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La condicion del CD es un campo obligatorio")]
        public string Condicion { get; set; }

        [Required(ErrorMessage = "La ubicacion del CD es un campo obligatorio")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "El estado del CD es un campo obligatorio")]
        public string Estado { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID del titulo es obligatorio y debe ser un entero valido dentro del rango")]
        public int TituloId { get; set; }


        public Titulo Titulo { get; set; }





    }
}
