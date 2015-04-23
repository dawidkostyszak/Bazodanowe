using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.User;
using Shop.ObjectMothers;

namespace Shop.Application.UnitTests
{
    [TestClass]
    public class OrderServiceTests
    {
        public IOrderService os = new OrderService();
        public IUserService us = new UserService();

        public void CreateOrder(int id, string username)
        {
            Order order = OrderObjectMother.CreateOrder(id, username);
            User user = UserObjectMother.CreateCustomerWithAddress(id, username);
            us.CreateUser(user);
            os.CreateNewOrder(order);
        }

        [TestCleanup]
        public void CleanAfterTest()
        {
            foreach (var o in os.GetAllOrders())
            {
                os.DeleteOrder(o.Id);
            }
            foreach (var u in us.GetAllUsers())
            {
                us.DeleteUser(u.Id);
            }
        }

        [TestMethod]
        public void CheckGetAllOrdersMethodResult()
        {
            CreateOrder(1, "username1");
            CreateOrder(2, "username2");
            List<Order> orders = os.GetAllOrders();

            Assert.AreEqual(2, orders.Count);
        }

        [TestMethod]
        public void CheckCreateOrderMethodResult()
        {
            CreateOrder(1, "username");
            List<Order> orders = os.GetAllOrders();

            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckDeleteOrderMethodResult()
        {
            CreateOrder(1, "username");

            os.DeleteOrder(1);
            List<Order> result = os.GetAllOrders();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CheckGetOrderMethodResult()
        {
            CreateOrder(1, "username");
            Order result = os.GetOrder(1);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void CheckGetOrderByCityMethodResult()
        {
            User user = UserObjectMother.CreateCustomerWithAddress(1, "username");
            CreateOrder(1, "username");
            List<Order> orders = os.GetAllOrdersByCity(user.Address.City);
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckGetOrderByUserMethodResult()
        {
            User user = UserObjectMother.CreateCustomerWithAddress(1, "username");
            CreateOrder(1, "username");
            List<Order> orders = os.GetAllOrdersByUser(user.Id);
            Assert.AreEqual(1, orders.Count);
        }
    }
}
