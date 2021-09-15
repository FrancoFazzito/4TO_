using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasVidaWebMVC.Controllers
{
    public class GruposFamiliaresController : Controller
    {
        private MasVidaDataContext db = new MasVidaDataContext();

        //
        // GET: /GruposFamiliares/

        public ActionResult Index()
        {
            return View(db.FamiliesGroups.ToList());
        }

        //
        // GET: /GruposFamiliares/Details/5

        public ActionResult Details(int id = 0)
        {
            FamilyGroup familygroup = db.FamiliesGroups.Find(id);
            if (familygroup == null)
            {
                return HttpNotFound();
            }
            return View(familygroup);
        }

        //
        // GET: /GruposFamiliares/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GruposFamiliares/Create

        [HttpPost]
        public ActionResult Create(FamilyGroup familygroup)
        {
            if (ModelState.IsValid)
            {
                db.FamiliesGroups.Add(familygroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familygroup);
        }

        //
        // GET: /GruposFamiliares/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FamilyGroup familygroup = db.FamiliesGroups.Find(id);
            if (familygroup == null)
            {
                return HttpNotFound();
            }
            return View(familygroup);
        }

        //
        // POST: /GruposFamiliares/Edit/5

        [HttpPost]
        public ActionResult Edit(FamilyGroup familygroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familygroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familygroup);
        }

        //
        // GET: /GruposFamiliares/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FamilyGroup familygroup = db.FamiliesGroups.Find(id);
            if (familygroup == null)
            {
                return HttpNotFound();
            }
            return View(familygroup);
        }

        //
        // POST: /GruposFamiliares/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyGroup familygroup = db.FamiliesGroups.Find(id);
            db.FamiliesGroups.Remove(familygroup);
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