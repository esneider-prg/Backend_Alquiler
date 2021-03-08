using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class DetalleAlquiler
    {
        public int Id { get; set; }

        public int AlquilerId { get; set; }

        public int CdId { get; set; }

        public int DiasPrestamo { get; set; }

        public string FechaDevolucion { get; set; }

        public Alquiler Alquiler { get; set; }

        public Cd Cd { get; set; }
    }
}
