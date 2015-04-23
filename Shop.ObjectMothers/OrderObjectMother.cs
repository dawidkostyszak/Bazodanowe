using System;
using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.User;

namespace Shop.ObjectMothers
{
    public class OrderObjectMother
    {
        public static Order CreateOrder(string username)
        {
            User customer = UserObjectMother.CreateCustomerWithAddress(username);
            return new Order { CreatedAt = DateTime.Now, Customer = customer, InvoiceNumber = "ABC/100/DEF", Price = 100, Products = new List<Album>(), Status = OrderStatus.Created };
        }
    }
}
