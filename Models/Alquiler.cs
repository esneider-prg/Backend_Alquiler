using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Alquiler
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public string FechaAlquiler { get; set; }

        public int ValorAlquiler { get; set; }

        public Cliente Cliente { get; set; }
    }
}
