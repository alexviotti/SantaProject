﻿using SantaProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaProject.Test.Mocks
{
    class DatabaseMock : IDataBase
    {
        public IEnumerable<Order> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Toy> GetAllOrderPrice(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Toy> GetAllToy()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string id)
        {
            throw new NotImplementedException();
        }

        public Toy GetToy(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(string id, OrderStatus status)
        {
            throw new NotImplementedException();
        }

    }
}
