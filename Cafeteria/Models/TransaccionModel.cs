namespace Cafeteria.Models
{
    public class TransaccionModel
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public EmpleadoModel ref_Empleado { get; set; }
        public ProductosModel ref_Productos{ get; set; }
        public string Cantidad { get; set; }
        public int Total { get; set; }



    }
}
