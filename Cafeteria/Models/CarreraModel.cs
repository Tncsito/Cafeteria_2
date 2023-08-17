using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models
{
    public class CarreraModel
    {
        [Required(ErrorMessage = "El campo Codigo Es obligatorio")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El campo Nombre Es obligatorio")]
        public string Nombre { get; set; }
    }
}
