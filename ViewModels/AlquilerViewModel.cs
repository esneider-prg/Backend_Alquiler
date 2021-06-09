using Backend_Alquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.ViewModels
{
    public class AlquilerViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string FechaAlquiler { get; set; }
        public int valor { get; set; }
        public int[] Detalle { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleAlquiler> DetalleAlquilers { get; set; }
    }
}
