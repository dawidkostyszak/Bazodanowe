using System;
using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.User;

namespace Shop.ObjectMothers
{
    public class OrderObjectMother
    {
        public static Order CreateOrder()
        {
            User customer = UserObjectMother.CreateCustomerWithAddress();
            return new Order { Id = 100, CreatedAt = DateTime.Now, Customer = customer, InvoiceNumber = "ABC/100/DEF", Price = 100, Products = new List<Album>(), Status = OrderStatus.Created };
        }
    }
}
