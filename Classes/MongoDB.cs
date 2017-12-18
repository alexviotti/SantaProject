using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaProject.Classes
{
    public class MongoDB : IDataBase
    {
        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public IEnumerable<Order> GetAllOrder()
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(new BsonDocument()).SortBy(o => o.RequestDate).ToList();
        }

        public IEnumerable<Toy> GetAllOrderPrice(Order order)
        {
            IMongoCollection<Toy> toysCollection = database.GetCollection<Toy>("toys");
            return toysCollection.Find(new BsonDocument()).ToList()
                                        .Where(toy => order.Toys.Any(orderToy => orderToy.Name == toy.Name))
                                        .ToList();
        }

        public IEnumerable<Toy> GetAllToy()
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(new BsonDocument()).ToList();
        }

        public Order GetOrder(string id)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public Toy GetToy(string id)
        {
            IMongoCollection<Toy> transactionCollection = database.GetCollection<Toy>("toys");
            return transactionCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public User GetUser(User user)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            return userCollection.Find(_ => _.Email == user.Email && _.PasswordClearText == user.PasswordClearText && _.Password == User.Hash(user.PasswordClearText)).FirstOrDefault();
        }

        public bool UpdateOrder(string id, OrderStatus status)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Order>.Update
                .Set("status", (int)status);
            try
            {
                orderCollection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
