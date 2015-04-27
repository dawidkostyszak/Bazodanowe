using System.Collections.Generic;
using NHibernate;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using Shop.Infrastructure;
using Shop.Infrastructure.Repositories.NHibernateRepo;

namespace Shop.Application
{
	public class OrderService : IOrderService
	{
		private IOrderRepository _orderRepository;

        private readonly ISession _session = NHibernateHelper.GetSession();

		//Order Service
		public OrderService()
		{
			_orderRepository = new OrderIM(_session);
		}

		public OrderService(IOrderRepository orderRepository)
		{
			this._orderRepository = orderRepository;
		}

        public Order CreateOrder(Order order)
        {
			return _orderRepository.Insert (order);
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

		public List<Order> GetOrdersByCity(string city)
		{
		    return _orderRepository.FindByCity(city);
		}

		public List<Order> GetOrdersByUser(int customerId)
		{
		    return _orderRepository.FindByUser(customerId);
		}
	}
}
