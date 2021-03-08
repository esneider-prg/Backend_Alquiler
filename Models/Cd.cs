using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Cd
    {
        public int Id { get; set; }

        public string Condicion { get; set; }

        public string Ubicacion { get; set; }

        public string Estado { get; set; }

        public int TituloId { get; set; }

        public Titulo Titulo { get; set; }





    }
}
