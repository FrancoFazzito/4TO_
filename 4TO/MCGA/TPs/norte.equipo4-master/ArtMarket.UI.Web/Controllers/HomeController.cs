using System.Linq;
using System.Web.Mvc;
using ArtMarket.UI.Process;

namespace ArtMarket.UI.Web.Controllers
{
	public class HomeController : Controller
    {
        private ProductProcess pp;

        public HomeController()
        {
            pp = new ProductProcess();
        }

        public ActionResult Index()
        {
            var products = pp.GetAll().OrderByDescending(x => x.CreatedOn).Take(4);

            return View(products.ToList());
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}