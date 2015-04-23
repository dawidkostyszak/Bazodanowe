using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class OrderIM : IOrderRepository
    {
        public Order Insert(Order order)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Insert(order);
                    transaction.Commit();
                    return order;
                }
            }
        }

        public void Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var orderQuery = (from o in session.Query<Order>() where o.Id == id select o).Single();
                    session.Delete(orderQuery);
                    transaction.Commit();
                }
            }
        }

        public Order Find(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Order>(id);
            }
        }

        public List<Order> FindAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Order>().ToList();
            }
        }

        public List<Order> FindByCity(string city)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from o in session.Query<Order>() where o.Customer.Address.City == city select o).ToList();
            }
        }

        public List<Order> FindByUser(int customerId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from o in session.Query<Order>() where o.Customer.Id == customerId select o).ToList();
            }
        }
    }
}
