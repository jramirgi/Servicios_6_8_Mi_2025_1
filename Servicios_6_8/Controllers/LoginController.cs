﻿using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_6_8.Controllers
{
    [RoutePrefix("api/Login")]
    //[Authorize]: Directiva para obligar a que se tenga autorización usar al servicio
    //[AllowAnonymous]: Directiva para que se pueda usar el servicio sin autorización.
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar(Login login)
        {
            clsLogin _Login = new clsLogin();
            _Login.login = login;
            return _Login.Ingresar();
        }
    }
}