using System.Collections.Generic;

namespace Shop.Domain.Model.Order.Repositories
{
    public interface IOrderRepository
    {
        Order Insert(Order order);

        void Delete(int id);

        Order Find(int id);

        List<Order> FindAll();

        List<Order> FindByCity(string city);

        List<Order> FindByUser(int customerId);
    }
}
