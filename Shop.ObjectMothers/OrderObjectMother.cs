using System;
using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.User;

namespace Shop.ObjectMothers
{
    public class OrderObjectMother
    {
        public static Order CreateOrder(int id, string username)
        {
            User customer = UserObjectMother.CreateCustomerWithAddress(id, username);
            return new Order { Id = id, CreatedAt = DateTime.Now, Customer = customer, InvoiceNumber = "ABC/100/DEF", Price = 100, Products = new List<Album>(), Status = OrderStatus.Created };
        }
    }
}
