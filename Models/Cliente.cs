using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class Cliente
    {
        public int Id  { get; set; }

        public string DireccionCliente { get; set; }

        public string Telefono { get; set; }

        public string NombreCliente { get; set; }

        public string Email { get; set; }

        public int DNI { get; set; }

        public string FechaNacimiento { get; set; }

        public string FechaInscripcion { get; set; }

        public string TemaInteres { get; set; }

        public string Estado { get; set; }


    }
}
