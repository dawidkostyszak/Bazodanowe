using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure.Mappings
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            References(x => x.Artist).Column("ArtistId").LazyLoad();
            HasMany(x => x.Orders).LazyLoad();
//            HasManyToMany(x => x.Orders).ParentKeyColumn("AlbumId").ChildKeyColumn("OrderId").Table("OrdersAlbum").Cascade.All();
            References(x => x.Category).Column("CategoryId").LazyLoad();
            Map(x => x.Content);
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.PublishDate);
            Map(x => x.Type);
            Table("Album");
        }
    }
}
