using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure.Mappings
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Id(x => x.Id).Not.Nullable().Column("AlbumId").GeneratedBy.Assigned();
            References(x => x.Artist).Column("ArtistId");
            HasMany(x => x.Categories).KeyColumn("AlbumId");
            Map(x => x.Content);
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.PublishDate);
            Map(x => x.Type);
            Table("Album");
        }
    }
}
