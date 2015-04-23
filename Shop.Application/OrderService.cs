using System.Collections.Generic;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using Shop.Infrastructure.Repositories.NHibernateRepo;

namespace Shop.Application
{
	public class OrderService : IOrderService
	{
		private IOrderRepository _orderRepository;

		//Order Service
		public OrderService()
		{
			_orderRepository = new OrderIM();
		}
		public OrderService(IOrderRepository orderRepository)
		{
			this._orderRepository = orderRepository;
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
	}
}
