namespace Cafeteria.Models
{
    public class PagoModel
    {
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public AlumnoModel refAlumno { get; set; }
        public decimal Monto { get; set; }


    }
}
