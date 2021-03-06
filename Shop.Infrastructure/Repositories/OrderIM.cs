﻿using System;
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

        public Order Insert(Order order)
        {
            orders.Add(order);
            return order;
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
