//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCGA.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatoAdicionalAfiliado
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public int AfiliadoId { get; set; }
        public int TipoKeyId { get; set; }
        public string JsonData { get; set; }
    
        public virtual Afiliado Afiliado { get; set; }
        public virtual TipoKey TipoKey { get; set; }
    }
}
