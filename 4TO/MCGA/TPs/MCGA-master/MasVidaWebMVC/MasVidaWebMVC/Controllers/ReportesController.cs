using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasVidaWebMVC.Common;

namespace MasVidaWebMVC.Controllers
{
    public class ReportesController : Controller
    {

        private MasVidaDataContext db = new MasVidaDataContext();

        //
        // GET: /Reportes/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ReporteDeClientes()
        {
            var users = db.Users.Include(u => u.FamiliesGroup).Include(u => u.Product).Include(u => u.UserType).Where(u => u.UserTypeID == (int)AppConstants.UserType.CLIENT).Where(u => u.IsActive == true).OrderBy(u => u.LastName).OrderBy(u => u.Name);

            return View(users.ToList());
        }

        public ActionResult ImprimirReporteDeClientes()
        {
            var users = db.Users.Include(u => u.FamiliesGroup).Include(u => u.Product).Include(u => u.UserType).Where(u => u.UserTypeID == (int)AppConstants.UserType.CLIENT).Where(u => u.IsActive == true).OrderBy(u => u.LastName).OrderBy(u => u.Name);

            return View(users.ToList());
        }


    }
}
