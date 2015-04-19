using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Inftastructure.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).Not.Nullable().Column("CategoryId").GeneratedBy.Assigned();
            Map(x => x.Name);
            HasMany(x => x.Albums).KeyColumn("AlbumId");
            Table("Category");
        }
    }
}
