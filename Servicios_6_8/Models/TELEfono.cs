//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_6_8.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TELEfono
    {
        public int Codigo { get; set; }
        public string Numero { get; set; }
        public string Documento { get; set; }
        public int CodigoTipoTelefono { get; set; }
    
        public virtual CLIEnte CLIEnte { get; set; }
        public virtual TIpoTElefono TIpoTElefono { get; set; }
    }
}
