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
    [RoutePrefix("api/TipoProductos")]
    [Authorize]
    public class TipoProductosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<TIpoPRoducto> ConsultarTodos()
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.ConsultarTodos();
        }
        [HttpGet]
        [Route("LlenarCombo")]
        public List<TIpoPRoducto> LlenarCombo()
        {
            clsTipoProducto tipoProducto = new clsTipoProducto();
            return tipoProducto.LlenarCombo();
        }
        [HttpGet]
        [Route("Consultar")]
        public TIpoPRoducto Consultar(int Codigo)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.Consultar(Codigo);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TIpoPRoducto TipoProducto)
        {
            clsTipoProducto tipoProducto = new clsTipoProducto();
            tipoProducto.TipoProducto = TipoProducto;
            return tipoProducto.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TIpoPRoducto TipoProducto)
        {
            clsTipoProducto tipoProducto = new clsTipoProducto();
            tipoProducto.TipoProducto = TipoProducto;
            return tipoProducto.Actualizar();
        }
    }
}