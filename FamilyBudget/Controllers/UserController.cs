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
    [Authorize]
    public class UserController : Controller
    {
        private IDBService dBService;
        public UserController(IDBService service)
		{
            dBService = service;
        }
        // GET: User
        public ActionResult All()
        {
            var users = dBService.GetAllUser();
            return View(users);
        }
        [HttpGet]
        public ActionResult Edit(int? userId)
        {
            User user = userId != null? dBService.FindUserById(userId.Value):null;
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            dBService.SaveUser(user);
            return RedirectToAction("All");
        }
    }
}