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
	public class TipoEspecialidadController : Controller
    {
        private TipoEspecialidadProcess process = new TipoEspecialidadProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Descripción" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.descripcion).Select(o => new { o.descripcion }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de tipos de especialidad.xls");
		}

		// GET: TipoEspecialidad
		[Route("listado-tipo-especialidad", Name = TipoEspecialidadControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var tipoEspecialidad = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(tipoEspecialidad.ToPagedList(pageNumber, pageSize));
        }

		// GET: TipoEspecialidad/Create
		[Route("agregar-tipo-especialidad", Name = TipoEspecialidadControllerRoute.GetCreate)]
		public ActionResult Create()
        {
            return View(TipoEspecialidadControllerAction.Create);
        }

        // POST: TipoEspecialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-tipo-especialidad", Name = TipoEspecialidadControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,descripcion")] TipoEspecialidad tipoEspecialidad)
        {
            if (ModelState.IsValid)
            {
				process.Add(tipoEspecialidad);
                return RedirectToAction("Index");
            }
			return View(TipoEspecialidadControllerAction.Create, tipoEspecialidad);
		}

		// GET: TipoEspecialidad/Edit/5
		[Route("editar-tipo-especialidad", Name = TipoEspecialidadControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoEspecialidad tipoEspecialidad = process.GetById(id);
			if (tipoEspecialidad == null)
            {
                return HttpNotFound();
            }
			return View(TipoEspecialidadControllerAction.Edit, tipoEspecialidad);
        }

        // POST: TipoEspecialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-tipo-especialidad", Name = TipoEspecialidadControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoEspecialidad tipoEspecialidad)
        {
            if (ModelState.IsValid)
            {
				process.Edit(tipoEspecialidad);
                return RedirectToAction("Index");
            }
			return View(TipoEspecialidadControllerAction.Edit, tipoEspecialidad);
		}

		// GET: TipoEspecialidad/Delete/5
		[Route("eliminar-tipo-especialidad", Name = TipoEspecialidadControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoEspecialidad tipoEspecialidad = process.GetById(id);
			if (tipoEspecialidad == null)
            {
                return HttpNotFound();
            }
			return View(TipoEspecialidadControllerAction.Delete, tipoEspecialidad);
        }

        // POST: TipoEspecialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-tipo-especialidad", Name = TipoEspecialidadControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
			TipoEspecialidad tipoEspecialidad = process.GetById(id);
			process.Remove(tipoEspecialidad);
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
