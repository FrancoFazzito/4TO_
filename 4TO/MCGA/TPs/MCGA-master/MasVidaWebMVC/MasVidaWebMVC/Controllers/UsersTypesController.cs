using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasVidaWebMVC.Controllers
{
    public class UsersTypesController : Controller
    {
        private MasVidaDataContext db = new MasVidaDataContext();

        //
        // GET: /UsersTypes/

        public ActionResult Index()
        {
            return View(db.UsersTypes.ToList());
        }

        //
        // GET: /UsersTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            UserType usertype = db.UsersTypes.Find(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        //
        // GET: /UsersTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UsersTypes/Create

        [HttpPost]
        public ActionResult Create(UserType usertype)
        {
            if (ModelState.IsValid)
            {
                db.UsersTypes.Add(usertype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usertype);
        }

        //
        // GET: /UsersTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserType usertype = db.UsersTypes.Find(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        //
        // POST: /UsersTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(UserType usertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usertype);
        }

        //
        // GET: /UsersTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserType usertype = db.UsersTypes.Find(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        //
        // POST: /UsersTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserType usertype = db.UsersTypes.Find(id);
            db.UsersTypes.Remove(usertype);
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