using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Servicios_6_8.Clases
{
    public class clsUpload
    {
        public HttpRequestMessage request { get; set; }
        public  string Datos { get; set; }
        public  string Proceso { get; set; }
        public async Task<HttpResponseMessage> GrabarArchivo()
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Archivos");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await request.Content.ReadAsMultipartAsync(provider);
                foreach (MultipartFileData file in provider.FileData)
                {
                    string fileName = file.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    if (File.Exists(Path.Combine(root, fileName)))
                    {
                        //No se pueden tener archivos con el mismo nombre. Es decir, las imágenes tienen que tener nombres únicos
                        //Si el archivo existe, se borra el archivo temporal que se subió
                        File.Delete(file.LocalFileName);
                        //Se da una respuesta de error
                        return request.CreateErrorResponse(HttpStatusCode.Conflict, "El archivo ya existe");
                    }
                    //Se renombra el archivo
                    File.Move(file.LocalFileName, Path.Combine(root, fileName));
                }
                //Se da una respuesta de éxito
                return request.CreateResponse(HttpStatusCode.OK, "Archivo subido con éxito");
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error al cargar el archivo: " + ex.Message);
            }
        }
    }
}