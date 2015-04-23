using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using Shop.Domain.Model.User;

namespace Shop.Infrastructure.Repositories
{
    public class OrderIM : IOrderRepository
    {
        private List<Order> orders = new List<Order>();

        public OrderIM()
        {
            orders = new List<Order>
            {
                new Order{Id = 1, CreatedAt = DateTime.Now, Customer = new User{Address = new Address()}, InvoiceNumber = "ABC/1/DEF", Price = 10, Products = new List<Album>(), Status = OrderStatus.Created },
                new Order{Id = 2, CreatedAt = DateTime.Now, Customer = new User{Address = new Address()}, InvoiceNumber = "ABC/2/DEF", Price = 100, Products = new List<Album>(), Status = OrderStatus.Paid },
                new Order{Id = 3, CreatedAt = DateTime.Now, Customer = new User{Address = new Address()}, InvoiceNumber = "ABC/3/DEF", Price = 30, Products = new List<Album>(), Status = OrderStatus.Finished }
            };
        }

        public void Insert(Order order)
        {
            orders.Add(order);
        }

        public void Delete(int id)
        {
            foreach (var o in orders.Where(o => o.Id == id))
            {
                orders.Remove(o);
                break;
            }
        }

        public Order Find(int id)
        {
            return orders.Single(o => o.Id == id);
        }

        public List<Order> FindAll()
        {
            return orders;
        }

        public List<Order> FindByCity(string city)
        {
            return orders.Where(o => o.Customer.Address.City == city).ToList();
        }

        public List<Order> FindByUser(int customerId)
        {
            return orders.Where(o => o.Customer.Id == customerId).ToList();
        }
    }
}
