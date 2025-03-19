using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsImagenesProducto
    {
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public string idProducto { get; set; }
        public List<string> Archivos { get; set; }
        public string GrabarImagenes()
        {
            try
            {
                if (Archivos.Count > 0)
                {
                    foreach (string Archivo in Archivos)
                    {
                        ImagenesProducto Imagen = new ImagenesProducto();
                        Imagen.idProducto = Convert.ToInt32(idProducto);
                        Imagen.NombreImagen = Archivo;
                        dbSuper.ImagenesProductoes.Add(Imagen);
                        dbSuper.SaveChanges();
                    }
                    return "Imagenes guardadas correctamente";
                }
                else
                {
                    return "No se enviaron archivos para guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}