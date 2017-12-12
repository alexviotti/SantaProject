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
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            ProjectMongoDB db = new ProjectMongoDB();
            var orders = db.GetAllOrder();
            Orders model = new Orders();
            model.EntityList = orders.ToList();
            return View(model);
        }

        public ActionResult Details(string id)
        {
            ProjectMongoDB db = new ProjectMongoDB();
            var order = db.GetOrder(id);
            Order model = new Order();
            model.ID = order.ID;
            model.Kid = order.Kid;
            model.Status = order.Status;
            model.Toys = order.Toys;
            model.requestDate = order.requestDate;
            return View(model);
        }
    }
}