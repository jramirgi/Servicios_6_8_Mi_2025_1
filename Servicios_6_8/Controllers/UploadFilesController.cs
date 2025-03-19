using Servicios_6_8.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Servicios_6_8.Controllers
{
    [RoutePrefix("UploadFiles")]
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> GrabarArchivo(HttpRequestMessage Request, string Datos, string Proceso)
        {
            clsUpload UploadFiles = new clsUpload();
            UploadFiles.request = Request;
            return await UploadFiles.GrabarArchivo();
        }
    }
}