using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using SantaProject.Classes;
using ProjectMongoDB = SantaProject.Classes.MongoDB;

namespace SantaProject.Test.Integration
{
    [TestClass]
    public class Users
    {
        private IMongoDatabase db;
        private const string ScreenNameTest = "test-screenName";
        private const string PasswordTest = "test-password";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            collection.InsertOne(new User
            {
                ScreenName = ScreenNameTest,
                Password = PasswordTest
            });
        }
        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("users");
            }
        }

        [TestMethod]
        public void GetUser_Should_Return_TestUser()
        {
            var db = new ProjectMongoDB();
            var test = new User
            {
                ScreenName = ScreenNameTest,
                Password = PasswordTest
            };
            var user = db.GetUser(test);

            Assert.IsNotNull(user);
        }
    }
}
