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
	public class ProfesionalController : Controller
    {
		private ProfesionalProcess process = new ProfesionalProcess();
		private TipoDocumentoProcess tipoDocumentoProcess = new TipoDocumentoProcess();

		public FileResult ExportExcel()
		{
			string[] aColumnas = { "Nombre", "Apellido", "Tipo de documento", "Nº de documento", "Dirección", "Teléfono", "Email", "Fecha de nacimiento", "Matrícula"};
			List<dynamic> lstDatos = process.GetAll().OrderBy(o => o.Nombre).ThenBy(o => o.Apellido).Select(o => new { o.Nombre, o.Apellido, o.TipoDocumento.descripcion, o.Numero, o.Direccion, o.Telefono, o.Email, FechaNacimiento = o.FechaNacimiento.ToShortDateString(), o.Matricula}).ToList<dynamic>();
			return File(new Framework.ExportExcel().ExportarExcel(aColumnas, lstDatos), "application/vnd.ms-excel", "Listado de profesionales.xls");
		}

		public JsonResult GetProfesional(string Areas, string term = "")
		{
			var lista = process.GetAll().Where(o => o.Nombre.ToUpper().Contains(term.ToUpper()) || o.Apellido.ToUpper().Contains(term.ToUpper())).OrderBy(o => o.Nombre).OrderBy(o => o.Apellido).Select(o => new { Id = o.Id, Name = string.Format("{0} {1}", o.Nombre, o.Apellido)}).ToList();
			return Json(lista, JsonRequestBehavior.AllowGet);
		}

		// GET: Profesional
		[Route("listado-profesional", Name = ProfesionalControllerRoute.GetIndex)]
		public ActionResult Index(int? page)
        {
            var profesional = process.GetAll();
			int pageSize = int.Parse(ConfigurationManager.AppSettings.Get("CantidadFilasPagina"));
			int pageNumber = (page ?? 1);
			return View(profesional.ToPagedList(pageNumber, pageSize));
        }

		// GET: Profesional/Create
		[Route("agregar-profesional", Name = ProfesionalControllerRoute.GetCreate)]
		public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion");
            return View();
        }

        // POST: Profesional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("agregar-profesional", Name = ProfesionalControllerRoute.PostCreate)]
		public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
				process.Add(profesional);
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion", profesional.TipoDocumentoId);
            return View(profesional);
        }

		// GET: Profesional/Edit/5
		[Route("editar-profesional", Name = ProfesionalControllerRoute.GetEdit)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = process.GetById(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion", profesional.TipoDocumentoId);
            return View(profesional);
        }

        // POST: Profesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Route("editar-profesional", Name = ProfesionalControllerRoute.PostEdit)]
		public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
				process.Edit(profesional);
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(tipoDocumentoProcess.GetAll(), "Id", "descripcion", profesional.TipoDocumentoId);
            return View(profesional);
        }

		// GET: Profesional/Delete/5
		[Route("eliminar-profesional", Name = ProfesionalControllerRoute.GetDelete)]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = process.GetById(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Route("eliminar-profesional", Name = ProfesionalControllerRoute.PostDelete)]
		public ActionResult DeleteConfirmed(int id)
        {
            Profesional profesional = process.GetById(id);
			process.Remove(profesional);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				process.Dispose();
				tipoDocumentoProcess.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
