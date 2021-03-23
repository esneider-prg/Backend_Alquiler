using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class DetalleAlquiler
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El id de alquiler debe ser un entero valido")]
        public int AlquilerId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El id de CD debe ser un entero valido")]
        public int CdId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Los dias de prestamo deben ser un entero valido")]
        public int DiasPrestamo { get; set; }

        [Required(ErrorMessage = "La fecha de devolucion es un campo obligatorio")]
        public string FechaDevolucion { get; set; }

        public Alquiler Alquiler { get; set; }

        public Cd Cd { get; set; }
    }
}
