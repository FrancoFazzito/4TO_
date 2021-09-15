using MCGA.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
	
	public class HomeController : Controller
    {

		[Route("", Name = HomeControllerRoute.GetIndex)]
		public ActionResult Index()
		{
			return View(HomeControllerAction.Index);
		}

		[Route("quienes-somos", Name = HomeControllerRoute.GetAbout)]
		public ActionResult About()
        {
			return View(HomeControllerAction.About);
		}

		[Route("contactese-con-nosotros", Name = HomeControllerRoute.GetContact)]
		public ActionResult Contact()
        {
			return View(HomeControllerAction.Contact);
		}
    }
}