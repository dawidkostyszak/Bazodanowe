using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class OrderIM : IOrderRepository
    {
        private ISession _session;

        public OrderIM(ISession session)
        {
            _session = session;
        }

        public Order Insert(Order order)
        {
            _session.Save(order);
            return order;
        }

        public void Delete(int id)
        {
            var orderQuery = _session.Get<Order>(id);
            _session.Delete(orderQuery);
        }

        public Order Find(int id)
        {
            return _session.Get<Order>(id);
        }

        public List<Order> FindAll()
        {
            return _session.Query<Order>().ToList();
        }

        public List<Order> FindByCity(string city)
        {
            return (from o in _session.Query<Order>() where o.Customer.Address.City == city select o).ToList();
        }

        public List<Order> FindByUser(int customerId)
        {
            return (from o in _session.Query<Order>() where o.Customer.Id == customerId select o).ToList();
        }
    }
}
