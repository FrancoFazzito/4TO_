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
	public class TipoResevaController : Controller
    {
		private TipoResevaProcess process = new TipoResevaProcess();

		public JsonResult GetTipoReseva()
		{
			var listTipoReserva = process.GetAll().Select(o=> new { Id=o.Id, descripcion = o.descripcion }).ToList();
			return Json(listTipoReserva, JsonRequestBehavior.AllowGet);			
		}

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Descripción" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.descripcion).Select(o => new { o.descripcion }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de tipos de reserva.xls");
		}

		// GET: TipoReseva
		[Route("listado-tipo-reserva", Name = TipoResevaControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var tipoReserva = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(tipoReserva.ToPagedList(pageNumber, pageSize));
		}

		// GET: TipoReseva/Create
		[Route("agregar-tipo-reserva", Name = TipoResevaControllerRoute.GetCreate)]
		public ActionResult Create()
        {
			return View(TipoResevaControllerAction.Create);
		}

        // POST: TipoReseva/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-tipo-reserva", Name = TipoResevaControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,descripcion")] TipoReseva tipoReseva)
        {
            if (ModelState.IsValid)
            {
				process.Add(tipoReseva);
                return RedirectToAction("Index");
            }
			return View(TipoResevaControllerAction.Create, tipoReseva);
		}

		// GET: TipoReseva/Edit/5
		[Route("editar-tipo-reserva", Name = TipoResevaControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoReseva tipoReseva = process.GetById(id);
			if (tipoReseva == null)
            {
                return HttpNotFound();
            }
			return View(TipoResevaControllerAction.Edit, tipoReseva);
        }

        // POST: TipoReseva/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-tipo-reserva", Name = TipoResevaControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoReseva tipoReseva)
        {
            if (ModelState.IsValid)
            {
				process.Edit(tipoReseva);
                return RedirectToAction("Index");
            }
			return View(TipoResevaControllerAction.Edit, tipoReseva);
		}

		// GET: TipoReseva/Delete/5
		[Route("eliminar-tipo-reserva", Name = TipoResevaControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoReseva tipoReseva = process.GetById(id);
			if (tipoReseva == null)
            {
                return HttpNotFound();
            }
			return View(TipoResevaControllerAction.Delete, tipoReseva);
        }

        // POST: TipoReseva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-tipo-reserva", Name = TipoResevaControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
			TipoReseva tipoReseva = process.GetById(id);
			process.Remove(tipoReseva);
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
