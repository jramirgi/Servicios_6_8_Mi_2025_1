using Microsoft.Ajax.Utilities;
using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_6_8.Controllers
{
    [RoutePrefix("api/Productos")]
    [Authorize]
    public class ProductosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarImagenes")]
        public IQueryable ConsultarImagenes(int idProducto)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarImagenesXProducto(idProducto);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PRODucto> ConsultarTodos()
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarTodos();
        }
        [HttpGet]
        [Route("Consultar")]
        public PRODucto Consultar(int CodigoProducto)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Consultar(CodigoProducto);
        }
        [HttpGet]
        [Route("ConsultarXTipoProducto")]
        public List<PRODucto> ConsultarXTipoProducto(int TipoProducto)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarXTipo(TipoProducto);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Actualizar();   
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int CodigoProducto)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Eliminar(CodigoProducto);
        }
    }
}