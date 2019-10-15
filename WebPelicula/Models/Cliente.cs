using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPelicula.Models
{
    public class Cliente
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int identificacion { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
    }
}