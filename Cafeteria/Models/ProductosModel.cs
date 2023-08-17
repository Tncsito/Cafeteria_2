using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models
{
    public class ProductosModel
    {
        [Required(ErrorMessage = "El campo Id Es obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre Es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Descripcion Es obligatorio")]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
