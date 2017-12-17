using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SantaProject.Classes;
using Moq;

namespace SantaProject.Test
{
    [TestClass]
    public class MongoDBTest
    {
        [TestMethod]
        public void Get_Order_Should_Throw_Exception_When_ID_Has_Not_Value()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(order => order.GetOrder(It.Is<string>(id => id == String.Empty))).Throws<ArgumentNullException>();

            mock.Object.GetOrder("test");
        }

        [TestMethod]
        public void Get_Toy_Should_Throw_Exception_When_ID_Has_Not_Value()
        {
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(toy => toy.GetToy(It.Is<string>(id => id == String.Empty))).Throws<ArgumentNullException>();

            mock.Object.GetToy("test");
        }

        [TestMethod]
        public void Get_User_Should_Throw_Exception_When_User_Has_Null()
        {
            User test = new User();
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(user => user.GetUser(It.Is<User>(obj => obj == null))).Throws<ArgumentNullException>();

            mock.Object.GetUser(test);
        }

        [TestMethod]
        public void Update_Order_Should_Throw_Exception_When_Order_Has_Null()
        {
            Order test = new Order();
            Mock<IDataBase> mock = new Mock<IDataBase>();
            mock.Setup(m => m.UpdateOrder(It.Is<string>(id => id == string.Empty), It.IsAny<OrderStatus>())).Throws<ArgumentNullException>();

            mock.Object.UpdateOrder("id",0);
        }
    }
}
