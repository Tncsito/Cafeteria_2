using Cafeteria.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cafeteria.Datos
{
    public class InventarioDatos
    {
        public List<InventarioModel> ListarInventario()
        {
            var oLista = new List<InventarioModel>();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarInventario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new InventarioModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                        });
                    }
                }
            }
            return oLista;
        }
        //##############################################################################
        public InventarioModel BuscarInventario(int Id)
        {
            var oAlumno = new InventarioModel();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarInventario", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oAlumno.Id = Convert.ToInt32(dr["Id"]);
                        oAlumno.Nombre = dr["Nombre"].ToString();
                        oAlumno.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        oAlumno.Precio = Convert.ToDecimal(dr["Precio"]);
                    }
                }
            }
            return oAlumno;
        }
        //##############################################################################
        public bool RegistrarInventario(InventarioModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarInventario", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", model.Id);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("Precio", model.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el prrocedimiento almacenado
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //##############################################################################
        public bool EditarInventario(InventarioModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarInventario", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", model.Id);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("Precio", model.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el prrocedimiento almacenado
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //##############################################################################
        public bool EliminarInventario(int Id)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarInventario", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el prrocedimiento almacenado
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //##############################################################################
    }
}
