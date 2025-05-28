using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Models
{
    public class Factura_Detalle
    {
        public FACTura factura { get; set; }
        public DEtalleFActura detalle { get; set; }
    }
}