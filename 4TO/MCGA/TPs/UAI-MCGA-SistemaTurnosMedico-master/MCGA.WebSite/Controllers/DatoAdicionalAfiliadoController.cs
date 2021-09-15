using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.Constants;
using MCGA.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
	[Authorize(Roles = "Administrador")]
	public class DatoAdicionalAfiliadoController : Controller
    {
		AfiliadoProcess afiliadoProcess = new AfiliadoProcess();
		TipoKeyProcess tipoKeyProcess = new TipoKeyProcess();
		DatoAdicionalAfiliadoProcess datoAdicionalAfiliadoProcess = new DatoAdicionalAfiliadoProcess();

		public JsonResult GetDatoAdicional(int afiliadoId)
		{
			List<CabeceraDatoAdicionalAfiliadoViewModel> listDatoAdicional = new List<CabeceraDatoAdicionalAfiliadoViewModel>();
			List<TipoKey> listTipoKey = tipoKeyProcess.GetAll();
			foreach(TipoKey tipoKey in listTipoKey)
			{
				var datoAdicionalAfiliado = datoAdicionalAfiliadoProcess.GetAll().Where(o => o.AfiliadoId == afiliadoId && o.TipoKeyId == tipoKey.Id).Select(o => new { o.JsonData }).FirstOrDefault();
				string jsonData = string.Empty;
				if (datoAdicionalAfiliado != null)
					jsonData = datoAdicionalAfiliado.JsonData;

				CabeceraDatoAdicionalAfiliadoViewModel grupoDatoAdicional = new CabeceraDatoAdicionalAfiliadoViewModel();
				grupoDatoAdicional.TipoKeyId = tipoKey.Id;
				grupoDatoAdicional.NombreKey = tipoKey.Descripcion;
				List<ControlDatoAdicionalAfiliadoViewModel> listControl = new List<ControlDatoAdicionalAfiliadoViewModel>();
				foreach (DetalleTipoKey detalleTipoKey in tipoKey.DetalleTipoKey)
				{
					ControlDatoAdicionalAfiliadoViewModel control = new ControlDatoAdicionalAfiliadoViewModel();
					control.Id = detalleTipoKey.Id;
					control.Tipo = detalleTipoKey.TipoCampo.Tipo;
					control.Label = detalleTipoKey.Nombre;
					control.Valor = (jsonData == string.Empty) ? string.Empty : Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonData)[control.Label].ToString();
					listControl.Add(control);
				}
				grupoDatoAdicional.ListControl = listControl;
				listDatoAdicional.Add(grupoDatoAdicional);
			}
			return Json(listDatoAdicional, JsonRequestBehavior.AllowGet);
		}

		// GET: DatoAdicionalAfiliado
		[Route("dato-adicional", Name = DatoAdicionalAfiliadoControllerRoute.GetDatoAdicional)]
		public ActionResult Create(int afiliadoId)
        {
			var afiliado = afiliadoProcess.GetById(afiliadoId);
			ViewBag.AfiliadoId = afiliado.Id;
			ViewBag.NombreAfiliado = string.Format("{0} {1}", afiliado.Nombre, afiliado.Apellido);
			return View();
        }

		[HttpPost]
		public JsonResult GuardarDatoAdicionalAfiliad(List<string> listJsonData)
		{
			List<DatoAdicionalAfiliado> listDatoAdicionalAfiliado = new List<DatoAdicionalAfiliado>();
			foreach(string jsonData in listJsonData)
			{
				listDatoAdicionalAfiliado.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<DatoAdicionalAfiliado>(jsonData));
			}
			datoAdicionalAfiliadoProcess.GuardarDatoAdicional(listDatoAdicionalAfiliado);
			return Json(listJsonData, JsonRequestBehavior.AllowGet);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				afiliadoProcess.Dispose();
				tipoKeyProcess.Dispose();
				datoAdicionalAfiliadoProcess.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}