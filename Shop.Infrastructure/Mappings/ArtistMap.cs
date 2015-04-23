using FluentNHibernate.Mapping;
using Shop.Domain.Model.Artist;

namespace Shop.Infrastructure.Mappings
{
    public class ArtistMap : ClassMap<Artist>
    {
        public ArtistMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name);
            HasMany(x => x.Albums).Cascade.All().Inverse().KeyColumn("ArtistId").LazyLoad();
            Table("Artist");
        }
    }
}
