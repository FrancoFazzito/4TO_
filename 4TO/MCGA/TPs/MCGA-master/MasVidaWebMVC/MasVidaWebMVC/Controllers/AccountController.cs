using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MasVidaWebMVC.Filters;
using MasVidaWebMVC.Models;
using MasVidaWebMVC.Common;

namespace MasVidaWebMVC.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            MasVidaDataContext db = new MasVidaDataContext();
            if (ModelState.IsValid)
            {
                //The ".FirstOrDefault()" method will return either the first matched
                //result or null
                var myUser = db.Users
                    .FirstOrDefault(u => u.UserName == model.UserName
                                 && u.IsActive == true);


                if (myUser != null)    //User was found
                {
                    if (!PasswordHash.ValidatePassword(model.Password, myUser.UserPassword.ToString()))
                    {
                        ModelState.AddModelError("", "Los datos ingresados no son correctos.");
                    }
                    else { 
                        FormsAuthentication.SetAuthCookie(model.UserName, false);

                        //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        //    "UserInfo",
                        //    DateTime.Now,
                        //    DateTime.Now.AddMinutes(30), // value of time out property
                        //    false, // Value of IsPersistent property
                        //    String.Empty,
                        //    FormsAuthentication.FormsCookiePath);

                        //string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                        //HttpCookie authCookie = new HttpCookie(
                        //        FormsAuthentication.FormsCookieName,
                        //        encryptedTicket);

                        //authCookie.Secure = true;

                        //Response.Cookies.Add(authCookie);

                        return RedirectToAction("Index", "Home");
                    }
                }
                else    //User was not found
                {
                    //Do something to let them know that their credentials were not valid
                    ModelState.AddModelError("", "Los datos ingresados no son correctos.");
                }

            }
            else
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("", "Ocurrio un error.");
            
            return View(model);
        }

        //
        // POST: /Account/LogOut

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
