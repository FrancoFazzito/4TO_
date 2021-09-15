using MCGA.Constants;
using MCGA.Entities;
using MCGA.UI.Process;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
	[Authorize]
    public class AtencionController : Controller
    {
		private AtencionProcess atencionProcess = new AtencionProcess();
		private AfiliadoProcess afiliadoProcess = new AfiliadoProcess();

		// GET: Atencion
		[Route("atencion-paciente", Name = AtencionControllerRoute.GetList)]
		public ActionResult List(int afiliadoId, int? page)
		{
			Afiliado afiliado = afiliadoProcess.GetById(afiliadoId);
			ViewBag.AfiliadoId = afiliado.Id;
			ViewBag.Afiliado = string.Format("{0} {1} Nº {2} ({3} {4})", afiliado.Nombre, afiliado.Apellido, afiliado.NumeroAfiliado, afiliado.TipoDocumento.descripcion, afiliado.Numero);
			var atencion = atencionProcess.GetAll().Where(o=> o.Turno.AfiliadoId == afiliado.Id).ToList();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(atencion.ToPagedList(pageNumber, pageSize));
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				atencionProcess.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}