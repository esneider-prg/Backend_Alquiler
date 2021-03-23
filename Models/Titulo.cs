using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Titulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del titulo es un campo obligatorio")]
        public string NombreTitulo { get; set; }

        [Required(ErrorMessage = "El interprete del titulo es un campo obligatorio")]
        public string Interprete { get; set; }


    }
}
