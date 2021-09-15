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
	public class EspecialidadController : Controller
    {
		private EspecialidadProcess process = new EspecialidadProcess();
		private TipoEspecialidadProcess tipoEspecialidadProcess = new TipoEspecialidadProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Descripción", "Frecuencia" };
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.descripcion).Select(o => new { o.descripcion, Frecuencia= o.frecuencia.ToString() }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de especialidades.xls");
		}

		public JsonResult GetEspecialidad(string Areas, string term = "")
		{
			var lista = process.GetAll().Where(o => o.descripcion.ToUpper().Contains(term.ToUpper())).OrderBy(o => o.descripcion).Select(o => new { Id = o.Id, Name = o.descripcion }).ToList();
			return Json(lista, JsonRequestBehavior.AllowGet);
		}

		// GET: Especialidad
		[Route("listado-especialidad", Name = EspecialidadControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
            var especialidad = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(especialidad.ToPagedList(pageNumber, pageSize));
        }

		// GET: Especialidad/Create
		[Route("agregar-especialidad", Name = EspecialidadControllerRoute.GetCreate)]
		public ActionResult Create()
        {
            ViewBag.TipoEspecialidadId = new SelectList(tipoEspecialidadProcess.GetAll(), "Id", "descripcion");
            return View();
        }

        // POST: Especialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-especialidad", Name = EspecialidadControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,descripcion,frecuencia,TipoEspecialidadId")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
				process.Add(especialidad);
                return RedirectToAction("Index");
            }

            ViewBag.TipoEspecialidadId = new SelectList(tipoEspecialidadProcess.GetAll(), "Id", "descripcion", especialidad.TipoEspecialidadId);
            return View(especialidad);
        }

		// GET: Especialidad/Edit/5
		[Route("editar-especialidad", Name = EspecialidadControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = process.GetById(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoEspecialidadId = new SelectList(tipoEspecialidadProcess.GetAll(), "Id", "descripcion", especialidad.TipoEspecialidadId);
            return View(especialidad);
        }

        // POST: Especialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-especialidad", Name = EspecialidadControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,descripcion,frecuencia,TipoEspecialidadId")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
				process.Edit(especialidad);
                return RedirectToAction("Index");
            }
            ViewBag.TipoEspecialidadId = new SelectList(tipoEspecialidadProcess.GetAll(), "Id", "descripcion", especialidad.TipoEspecialidadId);
            return View(especialidad);
        }

		// GET: Especialidad/Delete/5
		[Route("eliminar-especialidad", Name = EspecialidadControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = process.GetById(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-especialidad", Name = EspecialidadControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
            Especialidad especialidad = process.GetById(id);
			process.Remove(especialidad);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                process.Dispose();
				tipoEspecialidadProcess.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
