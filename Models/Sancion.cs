using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Sancion
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El id de alquiler debe ser un entero valido")]
        public int AlquilerId { get; set; }

        [Required(ErrorMessage = "El tipo de sancion es un campo obligatorio")]
        public string TipoSancion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Los dias de sancion deben ser un entero valido")]
        public int DiasSancion { get; set; }

        public Alquiler Alquiler { get; set; }
    }
}
