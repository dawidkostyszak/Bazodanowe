using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Model.Order;
using Shop.ObjectMothers;

namespace Shop.Application.UnitTests
{
    [TestClass]
    public class OrderServiceTests
    {
        public IOrderService os = new OrderService();

        [TestMethod]
        public void CheckGetAllOrdersMethodResult()
        {
            List<Order> orders = os.GetAllOrders();

            Assert.AreEqual(3, orders.Count);
        }

        [TestMethod]
        public void CheckCreateOrderMethodResult()
        {
            Order order = OrderObjectMother.CreateOrder();
            os.CreateNewOrder(order);
            List<Order> orders = os.GetAllOrders();

            Assert.AreEqual(4, orders.Count);
        }

        [TestMethod]
        public void CheckDeleteOrderMethodResult()
        {
            Order order = OrderObjectMother.CreateOrder();
            os.CreateNewOrder(order);
            List<Order> orders = os.GetAllOrders();
            Assert.AreEqual(4, orders.Count);

            os.DeleteOrder(order.Id);
            List<Order> result = os.GetAllOrders();

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void CheckGetOrderMethodResult()
        {
            Order order = OrderObjectMother.CreateOrder();
            os.CreateNewOrder(order);
            Order result = os.GetOrder(order.Id);
            Assert.AreEqual(order.Id, result.Id);
        }

        [TestMethod]
        public void CheckGetOrderByCityMethodResult()
        {
            Order order = OrderObjectMother.CreateOrder();
            os.CreateNewOrder(order);
            List<Order> orders = os.GetAllOrdersByCity(order.Customer.Address.City);
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckGetOrderByUserMethodResult()
        {
            Order order = OrderObjectMother.CreateOrder();
            os.CreateNewOrder(order);
            List<Order> orders = os.GetAllOrdersByUser(order.Customer.Id);
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckCreateInvoiceMethodResult()
        {
            Invoice invoice = OrderObjectMother.CreateInvoice();
            os.CreateNewInvoice(invoice);

            Invoice result = os.GetInvoice(invoice.Id);
            Assert.AreEqual(invoice.Id, result.Id);
        }
    }
}
