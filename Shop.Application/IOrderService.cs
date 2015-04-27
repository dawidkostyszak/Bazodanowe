using System.Collections.Generic;
using Shop.Domain.Model.Order;

namespace Shop.Application
{
    public interface IOrderService
    {
        //Order
        Order CreateOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrder(int id);
        List<Order> GetAllOrders();
        List<Order> GetOrdersByCity(string city);
        List<Order> GetOrdersByUser(int customerId);
    }
}
