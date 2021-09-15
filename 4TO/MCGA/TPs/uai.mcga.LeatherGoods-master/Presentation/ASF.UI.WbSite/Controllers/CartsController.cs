using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASF.Data;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite
{
    public class CartsController : Controller
    {
        CartProcess cartProcess = new CartProcess();

        public ActionResult Index()
        {
            var list = cartProcess.SelectList();
            return View(list);
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = cartProcess.Find((int)id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cookie,CartDate,ItemCount,Rowid,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                cartProcess.Add(cart);
                
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = cartProcess.Find((int)id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cookie,CartDate,ItemCount,Rowid,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                cartProcess.Edit(cart);
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = cartProcess.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cartProcess.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
