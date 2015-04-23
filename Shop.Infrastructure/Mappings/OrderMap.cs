﻿using FluentNHibernate.Mapping;
using Shop.Domain.Model.Order;

namespace Shop.Infrastructure.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("");
            Map(x => x.CreatedAt);
            References(x => x.Customer).Column("UserId");
            Map(x => x.InvoiceNumber);
            HasManyToMany(x => x.Products).ParentKeyColumn("OrderId").ChildKeyColumn("AlbumId").Table("OrdersAlbum");
            Map(x => x.Price);
            Map(x => x.Status).CustomType<OrderStatusType>();
            Table("[Order]");
        }
    }
}
