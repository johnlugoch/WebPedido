using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebPelicula.Models;

namespace WebPelicula.Services
{
    public class Servicio
    {
        public List<Int32> ObtenerConsecutivo()
        {
            List<Int32> lista = new List<Int32>();
            SqlConnection con = Conexion.obtenerConexion();
            string query = "SELECT MAX(Codigo_Cli) AS ID FROM Cliente";
            SqlCommand cmd = new SqlCommand(query);            
            cmd.Connection = con;
            Int32 ultimo = (Int32)cmd.ExecuteScalar();
            lista.Add(ultimo+1);           
            return lista;
        }

        public List<Int32> ObtenerConsecutivoPedido()
        {
            List<Int32> lista = new List<Int32>();
            SqlConnection con = Conexion.obtenerConexion();
            string query = "select top 1 Codigo_Ped as id  from Pedido order by Codigo_Ped desc";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = con;
            //SqlDataReader dr = cmd.ExecuteReader();
            Int32 ultimo = 0;            
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ultimo = int.Parse(reader[0].ToString());
                }
                else
                {
                    ultimo = 0;
                }
                lista.Add(ultimo + 1);
            }
            
            return lista;
        }


        public int GuardarCliente(Cliente c)
        {
            int result = 0;
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand cmd = con.CreateCommand();
            string query = "INSERT INTO Cliente (Codigo_Cli,identificacion_Cli,Nombre_Cli,Apellido_Cli,Direccion_Cli,Telefono_Cli,Correo_Cli)" +
                           "VALUES (@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@param1", c.codigo);
            cmd.Parameters.AddWithValue("@param2", c.identificacion);
            cmd.Parameters.AddWithValue("@param3", c.nombre);
            cmd.Parameters.AddWithValue("@param4", c.apellido);
            cmd.Parameters.AddWithValue("@param5", c.direccion);
            cmd.Parameters.AddWithValue("@param6", c.telefono);
            cmd.Parameters.AddWithValue("@param7", c.correo);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        
        
        /*-------------------Pedido------------------------*/
        public int GuardarPedido(Pedido a)
        {
            int result = 0;
            //string nombrepel = a.NombrePelicula_Alq.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand cmd = con.CreateCommand();
            string query = "INSERT INTO Pedido ( Codigo_Ped, CodigoCliente_Ped, NombreCliente_Ped, CodigoArticulo_Ped, NombreArticulo_Ped, CantidadArticulo_Ped, EstadoArticulo_Ped)" +
                           "VALUES (@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@param1", a.Codigo_Ped);
            cmd.Parameters.AddWithValue("@param2", a.CodigoCliente_ped);
            cmd.Parameters.AddWithValue("@param3", a.NombreCliente_Ped);
            cmd.Parameters.AddWithValue("@param4", a.CodigoArticulo_Ped);
            cmd.Parameters.AddWithValue("@param5", a.NombreArticulo_Ped);    
            cmd.Parameters.AddWithValue("@param6", a.CantidadArticulo_Ped);
            cmd.Parameters.AddWithValue("@param7", a.EstadoArticulo_Ped);

            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int ActualizarPedido(Pedido c)
        {
            int result = 0;
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand cmd = con.CreateCommand();
            string query = "UPDATE Pedido SET CodigoCliente_Ped = @codigoc,CodigoArticulo_Ped= @codigoa, CantidadArticulo_Ped=@cantidad, EstadoArticulo_Ped = @estado"+
                           " WHERE Codigo_Ped= @codpedido";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@codigoc", c.CodigoCliente_ped);
            cmd.Parameters.AddWithValue("@codigoa", c.CodigoArticulo_Ped);
            cmd.Parameters.AddWithValue("@acantidad", c.CantidadArticulo_Ped);
            cmd.Parameters.AddWithValue("@estado", c.EstadoArticulo_Ped);
            cmd.Parameters.AddWithValue("@codpedido", c.Codigo_Ped);            
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int EliminarPedido(Pedido c)
        {
            int result = 0;
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand cmd = con.CreateCommand();
            string query = "DELETE FROM Pedido WHERE Codigo_Ped= @cod";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@cod", c.Codigo_Ped);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int EliminarCliente(Cliente c)
        {
            int result = 0;
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand cmd = con.CreateCommand();
            string query = "DELETE FROM Cliente WHERE Codigo_Cli= @cod";                          
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@cod", c.codigo);            
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection con = Conexion.obtenerConexion();
            string query = "SELECT * FROM Cliente";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            codigo = System.Convert.ToInt32(sdr["Codigo_Cli"].ToString()),
                            nombre = sdr["Nombre_Cli"].ToString(),
                            apellido = sdr["Apellido_Cli"].ToString(),
                            identificacion = System.Convert.ToInt32(sdr["Identificacion_Cli"].ToString()),
                            direccion = sdr["Direccion_Cli"].ToString(),
                            telefono = System.Convert.ToInt32(sdr["Telefono_Cli"].ToString()),
                            correo = sdr["Correo_Cli"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }
        /*---------------------------------------------------------*/
        public List<Pedido> ListarPedido()
        {
            List<Pedido> lista = new List<Pedido>();
            SqlConnection con = Conexion.obtenerConexion();
            string query = "SELECT * FROM Pedido";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lista.Add(new Pedido
                        {
                            Codigo_Ped = System.Convert.ToInt32(sdr["Codigo_Ped"].ToString()),
                            CodigoCliente_ped = System.Convert.ToInt32(sdr["CodigoCliente_Ped"].ToString()),
                            NombreCliente_Ped = sdr["NombreCliente_Ped"].ToString(),                            
                            CodigoArticulo_Ped = System.Convert.ToInt32(sdr["CodigoArticulo_Ped"].ToString()),
                            NombreArticulo_Ped = sdr["NombreArticulo_Ped"].ToString(),
                            CantidadArticulo_Ped = System.Convert.ToInt32(sdr["CantidadArticulo_Ped"].ToString()),                            
                            EstadoArticulo_Ped = sdr["EstadoArticulo_Ped"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        /*---------------------Pedido-------------------------------------*/
        public List<Cliente> ObtenerNombreCliente(int codigoc)
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection con = Conexion.obtenerConexion();
            string query = "SELECT * FROM Cliente Where Codigo_Cli= " + codigoc;
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;                
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            codigo = System.Convert.ToInt32(sdr["Codigo_Cli"].ToString()),
                            nombre = sdr["Nombre_Cli"].ToString(),
                            apellido = sdr["Apellido_Cli"].ToString(),
                            identificacion = System.Convert.ToInt32(sdr["Identificacion_Cli"].ToString()),
                            direccion = sdr["Direccion_Cli"].ToString(),
                            telefono = System.Convert.ToInt32(sdr["Telefono_Cli"].ToString()),
                            correo = sdr["Correo_Cli"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        
        /*---------------------Pedido-------------------------------------*/
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection con = Conexion.obtenerConexion();
            string query = "SELECT * FROM Articulo";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lista.Add(new Articulo
                        {
                            Codigo = System.Convert.ToInt32(sdr["Codigo"].ToString()),
                            Nombre = sdr["Nombre"].ToString(),
                            Marca = sdr["Marca"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        
    }
}