using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using SantaProject.Classes;
using ProjectMongoDB = SantaProject.Classes.MongoDB;

namespace SantaProject.Test.Integration
{
    [TestClass]
    public class Orders
    {
        private IMongoDatabase db;
        private string testOrderId = ObjectId.GenerateNewId().ToString(); 

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Order> collection = db.GetCollection<Order>("orders");
            collection.InsertOne(new Order
            {
                ID = testOrderId
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("orders");
            }
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_A_List()
        {
            var db = new ProjectMongoDB();
            var list = db.GetAllOrder();
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void GetOrder_Should_Return_TestOrder()
        {
            var db = new ProjectMongoDB();
            var order = db.GetOrder(testOrderId);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void UpdateOrder_Should_Return_True()
        {
            var db = new ProjectMongoDB();
            var order = db.GetOrder(testOrderId);
            order.Status = OrderStatus.InProgress;
            Assert.IsTrue(db.UpdateOrder(order.ID, order.Status));
        }
    }
}
