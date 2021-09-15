using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasVidaWebMVC.Controllers
{
    public class ParametersController : Controller
    {
        private MasVidaDataContext db = new MasVidaDataContext();

        //
        // GET: /Parameters/

        public ActionResult Index()
        {
            return View(db.Parameters.ToList());
        }

        //
        // GET: /Parameters/Details/5

        public ActionResult Details(int id = 0)
        {
            Parameter parameter = db.Parameters.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // GET: /Parameters/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Parameters/Create

        [HttpPost]
        public ActionResult Create(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                db.Parameters.Add(parameter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parameter);
        }

        //
        // GET: /Parameters/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Parameter parameter = db.Parameters.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /Parameters/Edit/5

        [HttpPost]
        public ActionResult Edit(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parameter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        //
        // GET: /Parameters/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Parameter parameter = db.Parameters.Find(id);
            if (parameter == null)
            {
                return HttpNotFound();
            }
            return View(parameter);
        }

        //
        // POST: /Parameters/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Parameter parameter = db.Parameters.Find(id);
            db.Parameters.Remove(parameter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}