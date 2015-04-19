using System.Collections.Generic;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using Shop.Inftastructure.Repositories;

namespace Shop.Application
{
	public class OrderService : IOrderService
	{
		private IOrderRepository _orderRepository;
        private IInvoiceRepository _invoiceRepository;

		//Order Service
		public OrderService()
		{
			_orderRepository = new OrderIM();
            _invoiceRepository = new InvoiceIM();
		}
		public OrderService(IOrderRepository orderRepository, IInvoiceRepository invoiceRepository)
		{
			this._orderRepository = orderRepository;
		    this._invoiceRepository = invoiceRepository;
		}

		public void CreateNewOrder(Order order) {
			_orderRepository.Insert (order);
		}
		public void DeleteOrder(int orderId) {
			_orderRepository.Delete(orderId);
		}
		public Order GetOrder (int orderId) {
			return _orderRepository.Find(orderId);
		}
		public List<Order> GetAllOrders() {
			return _orderRepository.FindAll();
		}
		public List<Order> GetAllOrdersByCity(string city)
		{
		    return _orderRepository.FindByCity(city);
		}
		public List<Order> GetAllOrdersByUser(int customerId)
		{
		    return _orderRepository.FindByUser(customerId);
		}

        //Invoice
        public void CreateNewInvoice(Invoice invoice)
        {
            _invoiceRepository.Insert(invoice);
        }
        public Invoice GetInvoice(int invoiceId)
        {
            return _invoiceRepository.Find(invoiceId);
        }
	}
}
