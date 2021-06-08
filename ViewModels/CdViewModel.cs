using Backend_Alquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.ViewModels
{
    public class CdViewModel
    {
        public int Id { get; set; }
        public string Condicion { get; set; }
        public string estado { get; set; }
        public Titulo Titulo { get; set; }
        public string Ubicacion { get; set; }
    }
}
