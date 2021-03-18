using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FamilyBudget.Controllers
{
    public class AccountController : Controller
    {
        private IDBService dBService;
        public AccountController(IDBService dBService)
		{
            this.dBService = dBService;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
		{
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
		}
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
		{
            if(ModelState.IsValid)
			{
                var user = dBService.Login(t => t.Login == model.Login && t.Password == model.Password);
                if(user != null)
				{
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
				}
				else
				{
                    ModelState.AddModelError("", "Пользователь не найден");
				}
			}
			
            return View(model);
		}

        [HttpGet]
        public ActionResult Registration()
		{
            return View();
		}

        [HttpPost]
        public ActionResult Registration(User user)
        {
            dBService.CreateUser(user);
            return RedirectToAction("Login");
        }
    }
}