using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCGA.Constants;
using MCGA.Entities;
using MCGA.UI.Process;
using PagedList;

namespace MCGA.WebSite.Controllers
{
	[Authorize]
	public class AfiliadoController : Controller
    {
        private AfiliadoProcess process = new AfiliadoProcess();
		private EstadoCivilProcess estadoCivilProcess = new EstadoCivilProcess();
		private PlanProcess planProcess = new PlanProcess();
		private TipoDocumentoProcess tipoDocumentoProcess = new TipoDocumentoProcess();
		private TipoSexoProcess tipoSexoProcess = new TipoSexoProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Nombre", "Apellido", "Tipo de documento", "Nº de documento", "Dirección", "Teléfono", "Email", "Sexo", "Fecha de nacimiento", "Estado civil", "Nº de afiliado", "Plan" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.Nombre).ThenBy(o => o.Apellido).Select(o => new { o.Nombre, o.Apellido, o.TipoDocumento.descripcion, o.Numero, o.Direccion, o.Telefono, o.Email, Sexo = o.TipoSexo.descripcion, FechaNacimiento = o.FechaNacimiento.ToShortDateString(), EstadoCivil = o.EstadoCivil.descripcion, o.NumeroAfiliado, Plan = o.Plan.descripcion }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de afiliados.xls");
		}

		public JsonResult GetAfiliado(string Areas, string term = "")
		{
			var lista = process.GetAll().Where(o => o.Nombre.ToUpper().Contains(term.ToUpper()) || o.Apellido.ToUpper().Contains(term.ToUpper())).OrderBy(o => o.Nombre).OrderBy(o => o.Apellido).Select(o => new { Id = o.Id, Name = string.Format("{0} {1} Nº {2} ({3} {4})", o.Nombre, o.Apellido, o.NumeroAfiliado, o.TipoDocumento.descripcion, o.Numero) }).ToList();
			return Json(lista, JsonRequestBehavior.AllowGet);
		}

		// GET: Afiliado
		[Route("listado-afiliado", Name = AfiliadoControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var afiliado = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
            return View(afiliado.ToPagedList(pageNumber, pageSize));
        }

		// GET: Afiliado/Create
		[Route("agregar-afiliado", Name = AfiliadoControllerRoute.GetCreate)]
		public ActionResult Create()
        {
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.GetAll(), "Id", "descripcion");
            ViewBag.PlanId = new SelectList(planProcess.GetAll(), "Id", "descripcion");
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion");
            ViewBag.TipoSexoId = new SelectList(tipoSexoProcess.GetAll(), "Id", "descripcion");
            return View();
        }

        // POST: Afiliado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-afiliado", Name = AfiliadoControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Habilitado")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
				process.Add(afiliado);
                return RedirectToAction("Index");
            }

            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.GetAll(), "Id", "descripcion", afiliado.EstadoCivilId);
            ViewBag.PlanId = new SelectList(planProcess.GetAll(), "Id", "descripcion", afiliado.PlanId);
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoProcess.GetAll(), "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

		// GET: Afiliado/Edit/5
		[Route("editar-afiliado", Name = AfiliadoControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = process.GetById(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.GetAll(), "Id", "descripcion", afiliado.EstadoCivilId);
            ViewBag.PlanId = new SelectList(planProcess.GetAll(), "Id", "descripcion", afiliado.PlanId);
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoProcess.GetAll(), "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

        // POST: Afiliado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-afiliado", Name = AfiliadoControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Habilitado")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
				process.Edit(afiliado);
                return RedirectToAction("Index");
            }
            ViewBag.EstadoCivilId = new SelectList(estadoCivilProcess.GetAll(), "Id", "descripcion", afiliado.EstadoCivilId);
            ViewBag.PlanId = new SelectList(planProcess.GetAll(), "Id", "descripcion", afiliado.PlanId);
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(tipoSexoProcess.GetAll(), "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

		// GET: Afiliado/Delete/5
		[Route("eliminar-afiliado", Name = AfiliadoControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = process.GetById(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-afiliado", Name = AfiliadoControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
            Afiliado afiliado = process.GetById(id);
            process.Remove(afiliado);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				process.Dispose();
				estadoCivilProcess.Dispose();
				planProcess.Dispose();
				tipoDocumentoProcess.Dispose();
				tipoSexoProcess.Dispose();
			}
            base.Dispose(disposing);
        }
    }
}
