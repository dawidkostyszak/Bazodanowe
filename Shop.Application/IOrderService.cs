using System.Collections.Generic;
using Shop.Domain.Model.Order;

namespace Shop.Application
{
    public interface IOrderService
    {
        //Order
        void CreateNewOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrder(int orderId);
        List<Order> GetAllOrders();
        List<Order> GetAllOrdersByCity(string city);
        List<Order> GetAllOrdersByUser(int customerId);

        //Invoice
        void CreateNewInvoice(Invoice invoice);
        Invoice GetInvoice(int invoiceId);
    }
}
