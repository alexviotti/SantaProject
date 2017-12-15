using SantaProject.Classes;
using SantaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMongoDB = SantaProject.Classes.MongoDB;

namespace SantaProject.Controllers
{
    public class ToysController : Controller
    {
       
        public ActionResult Index()
        {
            ProjectMongoDB db = new ProjectMongoDB();
            var toys = db.GetAllToy();
            Toys model = new Toys();
            model.EntityList = toys.ToList();
            return View(model);
        }
                                                                           
    }
}
