using SantaProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMongoDB = SantaProject.Classes.MongoDB;

namespace SantaProject.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            ProjectMongoDB db = new ProjectMongoDB();
            var usr = db.GetUser(user);
            if (usr != null)
            {
                Session["Email"] = usr.Email.ToString();
                Session["ID"] = usr.ID.ToString();
                Session["ScreenName"] = usr.ScreenName.ToString();
                if (usr.IsAdmin)
                {
                    Session["IsAdmin"] = usr.IsAdmin.ToString();
                }
                return RedirectToAction($"../Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password Error");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["ID"] != null)
            {
                Session.Clear();
                return RedirectToAction("Logout");
            }
            return View();
        }
    }
}