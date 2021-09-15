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
	public class EstadoCivilController : Controller
    {
		private EstadoCivilProcess process = new EstadoCivilProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Descripción" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.descripcion).Select(o => new { o.descripcion }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de estado civil.xls");
		}

		// GET: EstadoCivil
		[Route("listado-estado-civil", Name = EstadoCivilControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var estadoCivil = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(estadoCivil.ToPagedList(pageNumber, pageSize));
		}

		// GET: EstadoCivil/Create
		[Route("agregar-estado-civil", Name = EstadoCivilControllerRoute.GetCreate)]
		public ActionResult Create()
        {
			return View(EstadoCivilControllerAction.Create);
        }

        // POST: EstadoCivil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-estado-civil", Name = EstadoCivilControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,descripcion")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
				process.Add(estadoCivil);
				return RedirectToAction("Index");
            }
			return View(EstadoCivilControllerAction.Create, estadoCivil);
        }

		// GET: EstadoCivil/Edit/5
		[Route("editar-estado-civil", Name = EstadoCivilControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EstadoCivil estadoCivil = process.GetById(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            return View(EstadoCivilControllerAction.Edit,estadoCivil);
        }

        // POST: EstadoCivil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-estado-civil", Name = EstadoCivilControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,descripcion")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
				process.Edit(estadoCivil);
				return RedirectToAction("Index");
            }
			return View(EstadoCivilControllerAction.Edit, estadoCivil);
        }

		// GET: EstadoCivil/Delete/5
		[Route("eliminar-estado-civil", Name = EstadoCivilControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCivil estadoCivil = process.GetById(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
			return View(EstadoCivilControllerAction.Delete, estadoCivil);
        }

        // POST: EstadoCivil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-estado-civil", Name = EstadoCivilControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
            EstadoCivil estadoCivil = process.GetById(id);
			process.Remove(estadoCivil);
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
