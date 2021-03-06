﻿using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Order
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual User.User Customer { get; set; }
        public virtual string InvoiceNumber { get; set; }
        public virtual IList<Album.Album> Products { get; set; }
        [NotNullValidator(MessageTemplate = "Add price")]
        public virtual int Price { get; set; }
        public virtual OrderStatus Status { get; set; }

        public Order()
        {
            Products = new List<Album.Album>();
        }
    }
}
