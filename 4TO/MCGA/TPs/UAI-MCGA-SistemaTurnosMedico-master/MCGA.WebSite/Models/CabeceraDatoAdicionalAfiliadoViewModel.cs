using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.WebSite.Models
{
	public class CabeceraDatoAdicionalAfiliadoViewModel
	{
		public int TipoKeyId { get; set; }
		public string NombreKey { get; set; }
		public List<ControlDatoAdicionalAfiliadoViewModel> ListControl { get; set; }
	}
}