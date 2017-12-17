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
            var orders = db.GetAllOrder().ToList();
            if(Session["IsAdmin"] != null)
            {
                orders.ForEach(order => order.Toys = db.GetAllOrderPrice(order) as List<Toy>);
            }
            Orders model = new Orders();
            model.EntityList = orders;
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
            model.RequestDate = order.RequestDate;
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            ProjectMongoDB db = new ProjectMongoDB();
            var order = db.GetOrder(id);
            Order model = new Order();
            model.Status = order.Status;
            model.ID = order.ID;
            return View(model);
        }

        public ActionResult Save(OrderStatus status, string id)
        {
            ProjectMongoDB db = new ProjectMongoDB();
            bool result;
            result = db.UpdateOrder(id, status);
            return RedirectToAction("Index");//, new { result = result }
        }
    }
}