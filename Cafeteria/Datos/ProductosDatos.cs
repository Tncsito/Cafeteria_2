using Cafeteria.Models;
using System.Data.SqlClient;
using System.Data;

namespace Cafeteria.Datos
{
    public class ProductosDatos
    {
            public List<ProductosModel> ListarProducto()
            {
                var oLista = new List<ProductosModel>();
                var al = new Conexion();
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ListarProducto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new ProductosModel()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"])
                               
                            });
                        }
                    }
                }
                return oLista;
            }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ProductosModel BuscarProducto(int Id)
        {
            var oProducto = new ProductosModel();
            var al = new Conexion();
            using (var conexion = new SqlConnection(al.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarProducto", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oProducto.Id = Convert.ToInt32(dr["Id"]);
                        oProducto.Nombre = dr["Nombre"].ToString();
                        oProducto.Descripcion = dr["Descripcion"].ToString();
                        oProducto.Precio = Convert.ToDecimal(dr["Precio"]);
                        
                    }
                }
            }
            return oProducto;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool RegistrarProducto(ProductosModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", model.Id);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool EditarProducto(ProductosModel model)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarProducto", conexion);
                    //enviando un parametro al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Id", model.Id);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool EliminarProducto(int Id)
        {   //creo una variable boolean
            bool respuesta;
            try
            {
                var al = new Conexion();
                //utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(al.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarProducto", conexion);
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
        //////
    }
}
