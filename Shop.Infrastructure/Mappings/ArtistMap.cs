using FluentNHibernate.Mapping;
using Shop.Domain.Model.Artist;

namespace Shop.Infrastructure.Mappings
{
    public class ArtistMap : ClassMap<Artist>
    {
        public ArtistMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.HiLo("");
            Map(x => x.Name);
            Table("Artist");
        }
    }
}
