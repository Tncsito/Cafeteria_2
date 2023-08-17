using Cafeteria.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cafeteria.Datos
{
    public class EmpleadoDatos
    {
        public List<EmpleadoModel> ListarEmpleado()
        {
            var oLista = new List<EmpleadoModel>();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Puesto = dr["Puesto"].ToString(),
                            Salario = Convert.ToDecimal(dr["Salario"]),
                            Contraseña = Convert.ToInt32(dr["Contraseña"]),
                        });
                    }
                }
            }
            return oLista;
        }
        //##############################################################################
        public EmpleadoModel BuscarEmpleado(int Id)
        {
            var oAlumno = new EmpleadoModel();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarEmpleado", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oAlumno.Id = Convert.ToInt32(dr["Id"]);
                        oAlumno.Nombre = dr["Nombre"].ToString();
                        oAlumno.Apellido = dr["Apellido"].ToString();
                        oAlumno.Correo = dr["Correo"].ToString();
                        oAlumno.Puesto = dr["Puesto"].ToString();
                        oAlumno.Salario = Convert.ToDecimal(dr["Salario"]);
                        oAlumno.Contraseña = Convert.ToInt32(dr["Contraseña"]);
                    }
                }
            }
            return oAlumno;
        }
        //##############################################################################
        public bool RegistrarEmpleado(EmpleadoModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEmpleado", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", model.Id);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", model.Apellido);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Puesto", model.Puesto);
                    cmd.Parameters.AddWithValue("Salario", model.Salario);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
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
        public bool EditarEmpleado(EmpleadoModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", model.Id);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", model.Apellido);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Puesto", model.Puesto);
                    cmd.Parameters.AddWithValue("Salario", model.Salario);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
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
        public bool EliminarEmpleado(int Id)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", conexion);
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
