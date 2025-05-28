using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_6_8.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Facturas")]
    [Authorize]
    public class FacturasController : ApiController
    {
        [HttpGet]
        [Route("ListarProductos")]
        public IQueryable ListarProductos(int NumeroFactura)
        {
            clsFactura Factura = new clsFactura();
            return Factura.ListarProductos(NumeroFactura);
        }
        [HttpPost]
        [Route("GrabarFactura")]
        public string GrabarFactura([FromBody] Factura_Detalle FacturaDetalle)//[FromBody] FacturaDetalle factura)
        {
            clsFactura factura = new clsFactura();
            factura.factura = FacturaDetalle.factura;
            factura.detalleFactura = FacturaDetalle.detalle;
            return factura.GrabarFactura();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int NumeroDetalle)
        {
            clsFactura Factura = new clsFactura();
            return Factura.EliminarProducto(NumeroDetalle);
        }
    }
}