using Cafeteria.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cafeteria.Datos
{
    public class UsuarioDatos
    {
        public List<AlumnoModel> ListarAlumno()
        {
            var oLista =new List<AlumnoModel>();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAlumno", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = cmd.ExecuteReader()) 
                { 
                    while (dr.Read()) 
                    {
                        oLista.Add(new AlumnoModel()
                        {
                            Nss = Convert.ToInt32(dr["Nss"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Carrera = dr["Carrera"].ToString(),
                            Semestre = Convert.ToInt32(dr["Semestre"]),
                            Matricula = Convert.ToInt32(dr["Matricula"]),
                            Contraseña = dr["Contraseña"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        //##############################################################################
        public AlumnoModel BuscarAlumno(int Nss)
        {
            var oAlumno = new AlumnoModel();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarAlumno", conexion);
                cmd.Parameters.AddWithValue("Nss", Nss);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        
                        oAlumno.Nss = Convert.ToInt32(dr["Nss"]);
                        oAlumno.Nombre = dr["Nombre"].ToString();
                        oAlumno.Apellido = dr["Apellido"].ToString();
                        oAlumno.Correo = dr["Correo"].ToString();
                        oAlumno.Carrera = dr["Carrera"].ToString();
                        oAlumno.Semestre = Convert.ToInt32(dr["Semestre"]);
                        oAlumno.Matricula = Convert.ToInt32(dr["Matricula"]);
                        oAlumno.Contraseña = dr["Contraseña"].ToString();
                    }
                }
            }
            return oAlumno;
        }
        //##############################################################################
        public bool RegistrarAlumno(AlumnoModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarAlumno", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nss", model.Nss);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", model.Apellido);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Carrera", model.Carrera);
                    cmd.Parameters.AddWithValue("Semestre", model.Semestre);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecutar el prrocedimiento almacenado
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch(Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        //##############################################################################
        public bool EditarAlumno(AlumnoModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAlumno", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nss", model.Nss);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", model.Apellido);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Carrera", model.Carrera);
                    cmd.Parameters.AddWithValue("Semestre", model.Semestre);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
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
        public bool EliminarAlumno(int Nss)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAlumno", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nss", Nss);
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
