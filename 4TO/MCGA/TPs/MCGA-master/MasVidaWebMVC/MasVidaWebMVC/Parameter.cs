//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasVidaWebMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Parameter
    {
        [Key]
        public int ParameterID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public byte[] ParameterDescription { get; set; }
    }
}
