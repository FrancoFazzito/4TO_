using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasVidaWebMVC.Controllers
{
    public class UsersController : Controller
    {
        private MasVidaDataContext db = new MasVidaDataContext();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.FamiliesGroup).Include(u => u.Product).Include(u => u.UserType);
            return View(users.ToList());
        }

        public ActionResult ImportClients()
        {
            var users = db.Users.Include(u => u.FamiliesGroup).Include(u => u.Product).Include(u => u.UserType);
            return View(users.ToList());
        }


        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            ViewBag.FamilyGroupID = new SelectList(db.FamiliesGroups, "FamilyGroupID", "FamilyName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.UserTypeID = new SelectList(db.UsersTypes, "UserTypeID", "UserTypeName");
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyGroupID = new SelectList(db.FamiliesGroups, "FamilyGroupID", "FamilyName", user.FamilyGroupID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", user.ProductID);
            ViewBag.UserTypeID = new SelectList(db.UsersTypes, "UserTypeID", "UserTypeName", user.UserTypeID);
            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyGroupID = new SelectList(db.FamiliesGroups, "FamilyGroupID", "FamilyName", user.FamilyGroupID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", user.ProductID);
            ViewBag.UserTypeID = new SelectList(db.UsersTypes, "UserTypeID", "UserTypeName", user.UserTypeID);
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyGroupID = new SelectList(db.FamiliesGroups, "FamilyGroupID", "FamilyName", user.FamilyGroupID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", user.ProductID);
            ViewBag.UserTypeID = new SelectList(db.UsersTypes, "UserTypeID", "UserTypeName", user.UserTypeID);
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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