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
            References(x => x.Customer).Column("UserId").Cascade.None();
            Map(x => x.InvoiceNumber);
            HasManyToMany(x => x.Products).ParentKeyColumn("OrderId").ChildKeyColumn("AlbumId").Cascade.All().Table("OrdersAlbums").LazyLoad();
            Map(x => x.Price);
            Map(x => x.Status).CustomType<OrderStatusType>();
            Table("[Order]");
        }
    }
}
