using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models
{
    public class PedidoModel
    {
        public string id { get; set; }
        public string Fecha { get; set; }
        public AlumnoModel refAlumno { get; set; }
        public ProductosModel refProducto { get; set; }
        public string Cantidad { get;set; }
        public string Total { get;set; }



    }
}
