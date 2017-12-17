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
    public class Toys
    {
        private IMongoDatabase db;

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
            collection.InsertOne(new Toy
            {
                Name = "toyTest"
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("toys");
            }
        }

        [TestMethod]
        public void GetAllToys_Should_Return_A_List()
        {
            var db = new ProjectMongoDB();
            var list = db.GetAllToy();
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void GetToy_Should_Return_TestToy()
        {
            var db = new ProjectMongoDB();

            string toyID = ObjectId.GenerateNewId().ToString();

            var toy = db.GetToy(toyID);

            Assert.IsNotNull(toy);
        }
    }
}
