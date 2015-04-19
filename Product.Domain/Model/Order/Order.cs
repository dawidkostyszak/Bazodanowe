using System;
using System.Collections.Generic;

namespace Shop.Domain.Model.Order
{
    public class Order
    {
        public enum OrderStatus
        {
            Created,
            ToPay,
            Paid,
            Shipment,
            Finished,
            Cancelled
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public User.User Customer { get; set; }
        public Invoice Invoice { get; set; }
        public List<Album.Album> Products { get; set; }
        public int Price { get; set; }
        public OrderStatus Status { get; set; }
    }
}
