using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.WbSite.Services.Utils;

namespace ASF.UI.WbSite.Areas.Category.Controllers
{
    public class CategoryController : Controller
    {
        
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly ASF.UI.Process.CategoryProcess categoryProcess = new Process.CategoryProcess();
         // GET: Category/Category
        public ActionResult Index()
        {
            logger.Info("Start index method");
            var resp = categoryProcess.SelectList();

            return View("view",resp);
        }

        // GET: Category/Category/Details/5
        public ActionResult Details(int id)
        {
            var category = categoryProcess.GetCategory(id);

            return View(category);
        }

        // GET: Category/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Category/Create
        [HttpPost]
        public ActionResult Create(ASF.Entities.Category category)
        {
            try
            {
                // TODO: Add insert logic here

                

                //var category = CustomConverterUtils.MapFormCollection<ASF.Entities.Category>(collection);

                categoryProcess.SaveCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categoryProcess.GetCategory(id);

            return View(category);
        }

        // POST: Category/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ASF.Entities.Category category)
        {
            try
            {
                categoryProcess.EditCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Category/Delete/5
        public ActionResult Delete(int id)
        {
            
            categoryProcess.DeleteCategory(id);
            
            return RedirectToAction("Index");
        }

        // POST: Category/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
