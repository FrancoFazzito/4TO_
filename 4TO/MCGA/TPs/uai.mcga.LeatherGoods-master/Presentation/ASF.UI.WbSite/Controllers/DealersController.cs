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

namespace ASF.UI.WbSite.Controllers
{
    public class DealersController : Controller
    {
        private DealerProcess dealerProcess = new DealerProcess();


        // GET: Dealers
        public ActionResult Index()
        {
            return View(dealerProcess.SelectList());
        }

        // GET: Dealers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = dealerProcess.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        // GET: Dealers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,CategoryId,CountryId,Description,TotalProducts,Rowid,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                dealerProcess.Add(dealer);
                
                return RedirectToAction("Index");
            }

            return View(dealer);
        }

        // GET: Dealers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = dealerProcess.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        // POST: Dealers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,CategoryId,CountryId,Description,TotalProducts,Rowid,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                dealerProcess.Edit(dealer);
                return RedirectToAction("Index");
            }
            return View(dealer);
        }

        // GET: Dealers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = dealerProcess.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        // POST: Dealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dealerProcess.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
