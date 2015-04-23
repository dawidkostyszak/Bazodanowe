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

        public Order CreateOrder(string username)
        {
            Order order = OrderObjectMother.CreateOrder(username);
            User user = us.CreateUser(UserObjectMother.CreateCustomerWithAddress(username));
            order.Customer = user;
            return os.CreateNewOrder(order);
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
            CreateOrder("username1");
            CreateOrder("username2");
            List<Order> orders = os.GetAllOrders();

            Assert.AreEqual(2, orders.Count);
        }

        [TestMethod]
        public void CheckCreateOrderMethodResult()
        {
            CreateOrder("username");
            List<Order> orders = os.GetAllOrders();

            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckDeleteOrderMethodResult()
        {
            var order = CreateOrder("username");

            os.DeleteOrder(order.Id);
            List<Order> result = os.GetAllOrders();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CheckGetOrderMethodResult()
        {
            var order = CreateOrder("username");
            Order result = os.GetOrder(order.Id);
            Assert.AreEqual(order.Id, result.Id);
        }

        [TestMethod]
        public void CheckGetOrderByCityMethodResult()
        {
            var order = CreateOrder("username");
            List<Order> orders = os.GetAllOrdersByCity(order.Customer.Address.City);
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckGetOrderByUserMethodResult()
        {
            var order = CreateOrder("username");
            List<Order> orders = os.GetAllOrdersByUser(order.Customer.Id);
            Assert.AreEqual(1, orders.Count);
        }
    }
}
