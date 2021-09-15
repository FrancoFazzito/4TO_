using System;
using System.Web.Mvc;
using ArtMarket.UI.Process;

namespace ArtMarket.UI.Web.Controllers
{
	public class UserController : BaseController
	{
        //public IUserManagement UserManagement { get; set; }

        //public UserController()
        //{
        //	UserManagement = new UserManagement();
        //}

        //// GET: User
        //public ActionResult Index()
        //{
        //	return View(UserManagement.GetAll());
        //}

        //public ActionResult Create()
        //{
        //	return View();
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection form)
        //{
        //	var user = new User();

        //	user.FirstName = form["firstName"];
        //	user.LastName = form["lastName"];
        //	user.Email = form["email"];
        //	user.City = form["city"];
        //	user.Country = form["country"];
        //	user.SignupDate = DateTime.Now;
        //	user.OrderCount = 0;

        //	CheckAuditPattern(user, true);
        //	UserManagement.Add(user);

        //	return RedirectToAction("Index");
        //}

        //public ActionResult Modify(int id)
        //{
        //	User user = UserManagement.Get(id);
        //	return View(user);
        //}

        //[HttpPost]
        //public ActionResult DoUpdate(User user)
        //{
        //	CheckAuditPattern(user);
        //	UserManagement.Update(user);

        //	return RedirectToAction("Index");
        //}

        //public ActionResult Delete(int id)
        //{
        //	UserManagement.Delete(id);

        //	return RedirectToAction("Index");
        //}

        //public ActionResult Login(string email, string password)
        //{

        //}


	}
}