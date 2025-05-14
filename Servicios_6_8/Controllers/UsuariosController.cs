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
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
        [Authorize]
        public string CrearUsuario([FromBody] Usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.CrearUsuario(idPerfil);
        }
    }
}