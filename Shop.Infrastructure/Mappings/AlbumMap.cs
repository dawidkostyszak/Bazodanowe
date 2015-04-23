using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure.Mappings
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("");
            References(x => x.Artist).Column("ArtistId").Cascade.All();
            HasManyToMany(x => x.Orders).ParentKeyColumn("AlbumId").ChildKeyColumn("OrderId").Table("OrdersAlbum").Cascade.All();
            HasManyToMany(x => x.Categories).ParentKeyColumn("AlbumId").ChildKeyColumn("CategoryId").Table("CategoriesAlbums").Cascade.All();
            Map(x => x.Content);
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.PublishDate);
            Map(x => x.Type);
            Table("Album");
        }
    }
}
