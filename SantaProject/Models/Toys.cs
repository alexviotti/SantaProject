using SantaProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaProject.Models
{
    public class Toys
    {
        public Toys()
        {
            EntityList = new List<Toy>();
        }
        public List<Toy> EntityList { get; private set; }

        public void Sum()
        {
            EntityList.Sum(toy => toy.Cost);
        }
    }

}