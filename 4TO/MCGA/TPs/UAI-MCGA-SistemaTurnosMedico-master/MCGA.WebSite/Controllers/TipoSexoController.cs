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
	public class TipoSexoController : Controller
    {
        private TipoSexoProcess process = new TipoSexoProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Descripción" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.descripcion).Select(o => new { o.descripcion }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de tipos de sexo.xls");
		}

		// GET: TipoSexo
		[Route("listado-tipo-sexo", Name = TipoSexoControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var tipoSexo = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(tipoSexo.ToPagedList(pageNumber, pageSize));
		}

		// GET: TipoSexo/Create
		[Route("agregar-tipo-sexo", Name = TipoSexoControllerRoute.GetCreate)]
		public ActionResult Create()
        {
			return View(TipoSexoControllerAction.Create);
		}

        // POST: TipoSexo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-tipo-sexo", Name = TipoSexoControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,descripcion")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
				process.Add(tipoSexo);
				return RedirectToAction("Index");
            }
			return View(TipoSexoControllerAction.Create, tipoSexo);
        }

		// GET: TipoSexo/Edit/5
		[Route("editar-tipo-sexo", Name = TipoSexoControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoSexo tipoSexo = process.GetById(id);
			if (tipoSexo == null)
            {
                return HttpNotFound();
            }
			return View(TipoSexoControllerAction.Edit, tipoSexo);
		}

        // POST: TipoSexo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-tipo-sexo", Name = TipoSexoControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
				process.Edit(tipoSexo);
				return RedirectToAction("Index");
            }
			return View(TipoSexoControllerAction.Edit, tipoSexo);
		}

		// GET: TipoSexo/Delete/5
		[Route("eliminar-tipo-sexo", Name = TipoSexoControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			TipoSexo tipoSexo = process.GetById(id);
			if (tipoSexo == null)
            {
                return HttpNotFound();
            }
			return View(TipoSexoControllerAction.Delete, tipoSexo);
        }

        // POST: TipoSexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-tipo-sexo", Name = TipoSexoControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
			TipoSexo tipoSexo = process.GetById(id);
			process.Remove(tipoSexo);
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
