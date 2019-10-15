using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPelicula.Models;
using WebPelicula.Services;

namespace WebPelicula.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        /*Listar Peliculas*/
        public JsonResult ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            Servicio s = new Servicio();
            lista = s.ListarArticulos();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerConsecutivoPedido()
        {
            List<Int32> lista = new List<Int32>();
            Servicio s = new Servicio();
            lista = s.ObtenerConsecutivoPedido();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        /*Obtener Nombre de Cliente*/
        public JsonResult ObtenerNombreCLiente(int codigoc)
        {
            List<Cliente> lista = new List<Cliente>();
            Servicio s = new Servicio();
            lista = s.ObtenerNombreCliente(codigoc);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarPedido(int codigoa, int codigoc, string nombre, int codarticulo, string articulo,
           int cantidad, string estado)
        {
            int result = 0;
            Pedido a = new Pedido();
            Servicio s = new Servicio();
            a.Codigo_Ped = codigoa;
            a.CodigoCliente_ped = codigoc;
            a.NombreCliente_Ped = nombre;
            a.CodigoArticulo_Ped = codarticulo;
            a.NombreArticulo_Ped = articulo;
            a.CantidadArticulo_Ped = cantidad;
            a.EstadoArticulo_Ped = estado;
            
            result = s.GuardarPedido(a);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarPedido()
        {
            List<Pedido> lista = new List<Pedido>();
            Servicio s = new Servicio();
            lista = s.ListarPedido();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActualizarPedido(int codigoa, int codigoc, int articulo,
            int cantidad, string estado)
        {
            int result = 0;
            Pedido c = new Pedido();
            Servicio s = new Servicio();
            c.Codigo_Ped = codigoa;
            c.CodigoCliente_ped = codigoc;
            
            c.CantidadArticulo_Ped = cantidad;
            c.EstadoArticulo_Ped = estado;            
            result = s.ActualizarPedido(c);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /*Eliminar Cliente*/
        public JsonResult EliminarPedido(int codigo)
        {
            int result = 0;
            Pedido c = new Pedido();
            Servicio s = new Servicio();
            c.Codigo_Ped = codigo;
            result = s.EliminarPedido(c);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}