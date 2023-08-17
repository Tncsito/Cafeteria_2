using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models
{
    public class EmpleadoModel
    {
        [Required(ErrorMessage = "El campo Id Es obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre Es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido Es obligatorio")]

        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Correo Es obligatorio")]

        public string Correo { get; set; }
        [Required(ErrorMessage = "El campo Puesto Es obligatorio")]

        public string Puesto { get; set; }
        [Required(ErrorMessage = "El campo Salario Es obligatorio")]

        public decimal Salario { get; set; }
        [Required(ErrorMessage = "El campo Contraseña Es obligatorio")]
        public int Contraseña { get; set; }
    }
}
