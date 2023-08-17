using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models
{
    public class InventarioModel
    {
        [Required(ErrorMessage = "El campo Id Es obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre Es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Cantidad Es obligatorio")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
