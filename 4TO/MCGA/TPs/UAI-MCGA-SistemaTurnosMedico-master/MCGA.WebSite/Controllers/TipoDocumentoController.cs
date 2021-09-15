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
	public class TipoDocumentoController : Controller
    {
        private TipoDocumentoProcess process = new TipoDocumentoProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Descripción" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.descripcion).Select(o => new { o.descripcion }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de tipos de documento.xls");
		}

		// GET: TipoDocumento
		[Route("listado-tipo-documento", Name = TipoDocumentoControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var tipoDocumento = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(tipoDocumento.ToPagedList(pageNumber, pageSize));
        }

		// GET: TipoDocumento/Create
		[Route("agregar-tipo-documento", Name = TipoDocumentoControllerRoute.GetCreate)]
		public ActionResult Create()
        {
			return View(TipoDocumentoControllerAction.Create);
        }

        // POST: TipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-tipo-documento", Name = TipoDocumentoControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,descripcion")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
				process.Add(tipoDocumento);
                return RedirectToAction("Index");
            }

			return View(TipoDocumentoControllerAction.Create, tipoDocumento);
        }

		// GET: TipoDocumento/Edit/5
		[Route("editar-tipo-documento", Name = TipoDocumentoControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoDocumento tipoDocumento = process.GetById(id);
			if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
			return View(TipoDocumentoControllerAction.Edit, tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-tipo-documento", Name = TipoDocumentoControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
				process.Edit(tipoDocumento);
                return RedirectToAction("Index");
            }
			return View(TipoDocumentoControllerAction.Edit, tipoDocumento);
        }

		// GET: TipoDocumento/Delete/5
		[Route("eliminar-tipo-documento", Name = TipoDocumentoControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoDocumento tipoDocumento = process.GetById(id);
			if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
			return View(TipoDocumentoControllerAction.Delete, tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-tipo-documento", Name = TipoDocumentoControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
			TipoDocumento tipoDocumento = process.GetById(id);
			process.Remove(tipoDocumento);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				process.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
