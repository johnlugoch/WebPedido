using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebPelicula.Models
{
    public class Conexion
    {
        public static SqlConnection obtenerConexion()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            return con;
        }

        public static void cerrarConexion()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Close();
        }
    }
}