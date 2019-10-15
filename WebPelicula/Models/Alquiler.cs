using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPelicula.Models
{
    public class Alquiler
    {
        public int Codigo_Alq { get; set;}
        public int CodigoCliente_Alq { get; set; }
        public string NombreCliente_Alq { get; set; }

        public int CodigoPelicula_Alq { get; set; }

        public string NombrePelicula_Alq { get; set; }
        public DateTime FechaAlquiler_Alq { get; set; }
        public DateTime FechaDevolucion_Alq { get; set; }
        public int CantidadPelicula_Alq { get; set; }
        public int TotalAlquiler_Alq { get; set; }

    }
}