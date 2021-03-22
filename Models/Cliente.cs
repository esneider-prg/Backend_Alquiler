
using System.ComponentModel.DataAnnotations;


namespace Backend_Alquiler.Models
{
    public class Cliente
    {
        public int Id  { get; set; }


        [Required(ErrorMessage = "La direccion del cliente es un campo obligatorio")]
        public string DireccionCliente { get; set; }

    
        [Required(ErrorMessage = "El telefono del cliente es un campo obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es un campo obligatorio")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El email del cliente es un campo obligatorio")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Formato de Email invalido")]
        public string Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El DNI debe ser un entero valido")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento del cliente es un campo obligatorio")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La fecha en que se inscribio el cliente es obligatoria")]
        public string FechaInscripcion { get; set; }

        [Required(ErrorMessage = "El tema de interes es un campo obligatorio")]
        public string TemaInteres { get; set; }

        [Required(ErrorMessage = "El estado del cliente es un campo obligatorio")]
        public string Estado { get; set; }


    }
}
