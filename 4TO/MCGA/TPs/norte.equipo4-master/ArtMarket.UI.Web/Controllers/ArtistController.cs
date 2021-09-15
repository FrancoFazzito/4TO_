using System;
using System.Web.Mvc;
using ArtMarket.Entities.Model;
using ArtMarket.UI.Process;

namespace ArtMarket.UI.Web.Controllers
{
	public class ArtistController : BaseController
	{
		public ArtistProcess process { get; set; }

		public ArtistController()
		{
            process = new ArtistProcess();
		}

		// GET: Artist
		public ActionResult Index()
		{
            var ap = new ArtistProcess();
            var list = ap.GetAll();

            return View(list);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(FormCollection form)
		{
			var artist = new Artist();

			artist.FirstName = form["firstName"];
			artist.LastName = form["lastName"];
			artist.LifeSpan = form["lifeSpan"];
			artist.Country = form["country"];
			artist.Description = form["description"];
			artist.TotalProducts = Convert.ToInt32(form["totalProducts"]);

			//CheckAuditPattern(artist, true);
			process.Add(artist);

			return RedirectToAction("Index");
		}

		public ActionResult Modify(int id)
		{
			Artist artist = process.Get(id);

			return View(artist);
		}


		[HttpPost]
		public ActionResult DoUpdate(Artist artist)
		{
			//CheckAuditPattern(artist);
			artist.CreatedOn = DateTime.Now;
			artist.ChangedOn = DateTime.Now;
            process.Edit(artist);

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
            process.Delete(id);

			return RedirectToAction("Index");
		}
	}
}