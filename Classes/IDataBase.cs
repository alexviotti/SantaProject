using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaProject.Classes
{
    public interface IDataBase
    {
        bool UpdateOrder(string id, OrderStatus status);
        IEnumerable<Order> GetAllOrder();
        IEnumerable<Toy> GetAllToy();
        Order GetOrder(string id);
        Toy GetToy(string id);
        User GetUser(User user);
        IEnumerable<Toy> GetAllOrderPrice(Order order);
    }
}
