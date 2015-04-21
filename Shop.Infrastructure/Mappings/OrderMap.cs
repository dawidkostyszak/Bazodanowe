using FluentNHibernate.Mapping;
using Shop.Domain.Model.Order;

namespace Shop.Infrastructure.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).Not.Nullable().Column("OrderId").GeneratedBy.Assigned();
            Map(x => x.CreatedAt);
            References(x => x.Customer).Column("UserId").Not.Nullable();
            Map(x => x.InvoiceNumber);
            HasMany(x => x.Products).KeyColumn("AlbumId");
            Map(x => x.Price);
            Map(x => x.Status).CustomType<OrderStatusType>();
            Table("[Order]");
        }
    }
}
