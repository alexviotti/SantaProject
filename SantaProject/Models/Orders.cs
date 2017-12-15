using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SantaProject.Classes;

namespace SantaProject.Models
{
    public class Orders
    {
        public List<Order> EntityList { get; set; }

        /*public void Sum()
        {
            EntityList.Sum(toy => toy.Cost);
        }*/
    }
}