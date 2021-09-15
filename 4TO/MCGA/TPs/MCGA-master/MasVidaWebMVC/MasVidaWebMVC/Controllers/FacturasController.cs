using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasVidaWebMVC.Common;
using PagedList;

namespace MasVidaWebMVC.Controllers
{
    public class FacturasController : Controller
    {
        private MasVidaDataContext db = new MasVidaDataContext();

        //
        // GET: /Facturas/

        public ActionResult Index(int? page)
        {
            var transaction = from t in db.Transactions.Include(t => t.Product).Include(t => t.TransactionType)
                                  .Include(t => t.Users).OrderByDescending(t => t.TransactionID) select t;

            //var transactions = db.Transactions.Include(t => t.Product).Include(t => t.TransactionType).Include(t => t.Users).OrderByDescending(t => t.TransactionID);
            //return View(transaction.ToList());

            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(transaction.ToPagedList(pageNumber, pageSize));

        }

        //
        // GET: /Facturas/Details/5

        public ActionResult Details(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // GET: /Facturas/Create

        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.TransactionTypeID = new SelectList(db.TransactionsTypes, "TransactionTypeID", "TransactionTypeName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        //
        // POST: /Facturas/Create

        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", transaction.ProductID);
            ViewBag.TransactionTypeID = new SelectList(db.TransactionsTypes, "TransactionTypeID", "TransactionTypeName", transaction.TransactionTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", transaction.UserID);
            return View(transaction);
        }

        //
        // GET: /Facturas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", transaction.ProductID);
            ViewBag.TransactionTypeID = new SelectList(db.TransactionsTypes, "TransactionTypeID", "TransactionTypeName", transaction.TransactionTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", transaction.UserID);
            return View(transaction);
        }

        //
        // POST: /Facturas/Edit/5

        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", transaction.ProductID);
            ViewBag.TransactionTypeID = new SelectList(db.TransactionsTypes, "TransactionTypeID", "TransactionTypeName", transaction.TransactionTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", transaction.UserID);
            return View(transaction);
        }

        //
        // GET: /Facturas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // POST: /Facturas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GenerarComprobantes()
        {

            var transac = db.Transactions.OrderByDescending(u => u.TransactionID).FirstOrDefault();

            
            DateTime lastTrans = transac.TransactionCreationDate;
            
            //Verificar si es Diciembre modificar año
            int newTransMonth = (lastTrans.Month == (int)Common.AppConstants.Months.DICIEMBRE) ? 1 : lastTrans.Month + 1;
            int newTransYear = (newTransMonth == (int)Common.AppConstants.Months.ENERO) ? lastTrans.Year + 1 : lastTrans.Year;

            var users = db.Users.Include(u => u.FamiliesGroup).Include(u => u.Product).Include(u => u.UserType).Where(u => u.UserTypeID == (int)AppConstants.UserType.CLIENT).Where(u => u.ProductID != null).Where(u => u.IsActive == true);

            foreach (User u in users)
            {
                Transaction trans = new Transaction();
                trans.ProductName = u.Product.ProductName;
                trans.ProductPrice = u.Product.ProductPrice;
                trans.IsPaid = false;
                trans.TransactionTypeID = (int)AppConstants.TransactionType.LIQUIDACION;
                trans.ProductID = Convert.ToInt32(u.ProductID);
                trans.UserID = u.UserID;
                trans.TransactionCreationDate = new DateTime(newTransYear, newTransMonth, 1);
                
                //TODO Hacer el trigger que sume todo en la tabla de usuario
                u.AccountTotal += u.Product.ProductPrice * -1;
                
                db.Entry(u).State = EntityState.Modified;
                db.Transactions.Add(trans);
               
            }

            db.SaveChanges();
            return RedirectToAction("Index");

            //var transactions = db.Transactions.Include(t => t.Product).Include(t => t.TransactionType).Include(t => t.Users);
            //return View(transactions.ToList());
        }

        public ActionResult ImprimirComprobantes()
        {
            var transac = db.Transactions.OrderByDescending(u => u.TransactionID).FirstOrDefault();


            DateTime lastTrans = transac.TransactionCreationDate;

            //Verificar si es Diciembre modificar año
            int lastTransMonth = lastTrans.Month;
            int lastTransYear = lastTrans.Year;


            //Clientes activos con producto asignado ordenados por direccion.
            var users = db.Users.Include(u => u.FamiliesGroup).Include(u => u.Product).Include(u => u.Transactions).Include(u => u.UserType).Where(u => u.IsActive == true).Where(u => u.UserTypeID == (int)AppConstants.UserType.CLIENT)
                    .Where(u => u.ProductID != null).Where(u => u.Transactions.Count > 0).OrderBy(u => u.Address);


            //TODO Ver como usar las constantes dependiendo de la fecha de la transaccion.
            string monthxxx = Common.Utilities.GetMonth(lastTrans.Month);
            ViewBag.Month = Common.Utilities.GetMonth(lastTrans.Month);
            ViewBag.MonthInt = lastTransMonth;
            ViewBag.Year = lastTransYear;

            return View(users.ToList());
        }


        public ActionResult Imprimir(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);

            //ver como usar el texto de las constantes dependiendo del nro
            ViewBag.Month = Common.Utilities.GetMonth(transaction.TransactionCreationDate.Month);

            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }


        public ActionResult Pagar(int id = 0)
        {
            Transaction transaction = db.Transactions.Find(id);

            transaction.IsPaid = true;

            Transaction transForPay = new Transaction();
            transForPay.ProductName = transaction.ProductName;
            transForPay.ProductPrice = transaction.ProductPrice;
            transForPay.IsPaid = true;
            transForPay.TransactionTypeID = (int)AppConstants.TransactionType.RECIBO;
            transForPay.ProductID = Convert.ToInt32(transaction.ProductID);
            transForPay.UserID = transaction.Users.UserID;
            transForPay.TransactionCreationDate = DateTime.Now;

            db.Entry(transaction).State = EntityState.Modified;
            db.Transactions.Add(transForPay);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}