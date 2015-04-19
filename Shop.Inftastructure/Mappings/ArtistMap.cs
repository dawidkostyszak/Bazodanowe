using FluentNHibernate.Mapping;
using Shop.Domain.Model.Artist;

namespace Shop.Inftastructure.Mappings
{
    public class ArtistMap : ClassMap<Artist>
    {
        public ArtistMap()
        {
            Id(x => x.Id).Not.Nullable().Column("ArtistId").GeneratedBy.Assigned();
            Map(x => x.Name);
            HasMany(x => x.Albums).KeyColumn("AlbumId");
            Table("Artist");
        }
    }
}
