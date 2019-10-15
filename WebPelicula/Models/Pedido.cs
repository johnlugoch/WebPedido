using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPelicula.Models
{
    public class Pedido
    {
        public int Codigo_Ped { get; set; }
        public int CodigoCliente_ped { get; set; }
        public string NombreCliente_Ped { get; set; }
        public int CodigoArticulo_Ped { get; set; }
        public string NombreArticulo_Ped { get; set; }
        public int CantidadArticulo_Ped { get; set; }
        public string EstadoArticulo_Ped { get; set; }
    }
}