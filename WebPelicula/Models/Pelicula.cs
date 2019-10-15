using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPelicula.Models
{
    public class Pelicula
    {
        public int Codigo_Pel { get; set; }
        public string Titulo_Pel { get; set; }
        public string Director_Pel { get; set; }
        public string Genero_Pel { get; set; }
        public int Anio_Pel { get; set; }
        public int Cantidad_Pel { get; set; }
        public int Precio_Pel { get; set; }
    }
}