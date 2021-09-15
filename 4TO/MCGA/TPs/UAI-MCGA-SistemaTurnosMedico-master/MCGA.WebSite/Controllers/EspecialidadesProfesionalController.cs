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
	public class EspecialidadesProfesionalController : Controller
    {
        private EspecialidadesProfesionalProcess process = new EspecialidadesProfesionalProcess();
		private EspecialidadProcess especialidadProcess = new EspecialidadProcess();
		private ProfesionalProcess profesionalProcess = new ProfesionalProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = {"Tipo de especialidad", "Especialidad", "Profesional" };
			List<dynamic> lstDatos = process.GetAll().Select(o => new { o.Especialidad.TipoEspecialidad.descripcion, Especialidad = o.Especialidad.descripcion, Profesiona = string.Format("{0} {1}", o.Profesional.Nombre, o.Profesional.Apellido) }).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de especialidad-profesional.xls");
		}

		public JsonResult GetEspecialidadProfesionalByProfesional(string Areas, string term = "", int idProfesional = 0)
		{
			var lista = process.GetAll().Where(o => o.ProfesionalId == idProfesional && o.Especialidad.descripcion.ToUpper().Contains(term.ToUpper())).OrderBy(o => o.Especialidad.descripcion).Select(o => new { Id = o.Id, Name = o.Especialidad.descripcion }).ToList();
			return Json(lista, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetEspecialidadProfesionalByEspecialidad(string Areas, string term = "", int idEspecialidad = 0)
		{
			var lista = process.GetAll().Where(o => o.EspecialidadId == idEspecialidad && (o.Profesional.Nombre.ToUpper().Contains(term.ToUpper()) || o.Profesional.Apellido.ToUpper().Contains(term.ToUpper()))).OrderBy(o => o.Profesional.Nombre).OrderBy(o => o.Profesional.Apellido).Select(o => new { Id = o.Id, Name = string.Format("{0} {1}", o.Profesional.Nombre, o.Profesional.Apellido) }).ToList();
			return Json(lista, JsonRequestBehavior.AllowGet);
		}

		// GET: EspecialidadesProfesional
		[Route("listado-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
			var especialidadesProfesional = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(especialidadesProfesional.ToPagedList(pageNumber, pageSize));
        }

		// GET: EspecialidadesProfesional/Create
		[Route("agregar-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.GetCreate)]
		public ActionResult Create()
        {
			ViewBag.EspecialidadTexto = string.Empty;
			ViewBag.ProfesionalTexto = string.Empty;
			return View();
        }

        // POST: EspecialidadesProfesional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,EspecialidadId,ProfesionalId")] EspecialidadesProfesional especialidadesProfesional)
        {
            if (ModelState.IsValid)
            {
				process.Add(especialidadesProfesional);
                return RedirectToAction("Index");
            }
			Especialidad especialidad = especialidadProcess.GetById(especialidadesProfesional.EspecialidadId);
			Profesional profesional = profesionalProcess.GetById(especialidadesProfesional.ProfesionalId);

			ViewBag.EspecialidadTexto = especialidad != null ? especialidad.descripcion : string.Empty;
			ViewBag.ProfesionalTexto = profesional != null ? string.Format("{0} {1}", profesional.Nombre, profesional.Apellido) : string.Empty;
            return View(especialidadesProfesional);
        }

		// GET: EspecialidadesProfesional/Edit/5
		[Route("editar-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = process.GetById(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
			Especialidad especialidad = especialidadProcess.GetById(especialidadesProfesional.EspecialidadId);
			Profesional profesional = profesionalProcess.GetById(especialidadesProfesional.ProfesionalId);

			ViewBag.EspecialidadTexto = especialidad != null ? especialidad.descripcion : string.Empty;
			ViewBag.ProfesionalTexto = profesional != null ? string.Format("{0} {1}", profesional.Nombre, profesional.Apellido) : string.Empty;
			return View(especialidadesProfesional);
        }

        // POST: EspecialidadesProfesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.PostEdit)]
        public ActionResult Edit([Bind(Include = "Id,EspecialidadId,ProfesionalId,createdon,createdby,changedon,changedby")] EspecialidadesProfesional especialidadesProfesional)
        {
            if (ModelState.IsValid)
            {
				process.Edit(especialidadesProfesional);
                return RedirectToAction("Index");
            }
			Especialidad especialidad = especialidadProcess.GetById(especialidadesProfesional.EspecialidadId);
			Profesional profesional = profesionalProcess.GetById(especialidadesProfesional.ProfesionalId);

			ViewBag.EspecialidadTexto = especialidad != null ? especialidad.descripcion : string.Empty;
			ViewBag.ProfesionalTexto = profesional != null ? string.Format("{0} {1}", profesional.Nombre, profesional.Apellido) : string.Empty;
			return View(especialidadesProfesional);
        }

		// GET: EspecialidadesProfesional/Delete/5
		[Route("eliminar-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = process.GetById(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            return View(especialidadesProfesional);
        }

        // POST: EspecialidadesProfesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-especialidades-profesional", Name = EspecialidadesProfesionalControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
            EspecialidadesProfesional especialidadesProfesional = process.GetById(id);
			process.Remove(especialidadesProfesional);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				process.Dispose();
				especialidadProcess.Dispose();
				profesionalProcess.Dispose();
			}
            base.Dispose(disposing);
        }
    }
}
