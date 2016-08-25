using ImdbWeb.Model.AccountModels;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ImdbWeb.Controllers
{
    public class AccountController : Controller
    {
		[AllowAnonymous]
        public ActionResult Logon()
        {
            return View();
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Logon(LogonModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (model.Username == "arjan" && model.Password == "pass")
				{
					FormsAuthentication.SetAuthCookie(model.Username, false);
					if (string.IsNullOrWhiteSpace(returnUrl))
					{
						return RedirectToAction("Index", "Home");
					}
					return Redirect(returnUrl);
				}

				ModelState.AddModelError("", "Ugyldig brukernavn og/eller passord");
			}
			return View();
		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		[ChildActionOnly]
		[AllowAnonymous]
		public ActionResult LoginStatus()
		{
			if (Request.IsAuthenticated)
			{
				ViewData.Model = User.Identity;
				return PartialView("LoggedIn");
			}

			return PartialView("NotLoggedIn");
		}
    }
}