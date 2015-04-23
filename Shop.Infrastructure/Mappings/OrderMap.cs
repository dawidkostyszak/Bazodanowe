using FluentNHibernate.Mapping;
using Shop.Domain.Model.Order;

namespace Shop.Infrastructure.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.CreatedAt);
            References(x => x.Customer).Column("UserId").LazyLoad();
            Map(x => x.InvoiceNumber);
            HasMany(x => x.Products).LazyLoad();
            Map(x => x.Price);
            Map(x => x.Status).CustomType<OrderStatusType>();
            Table("[Order]");
        }
    }
}
