using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.HiLo("");
            Map(x => x.Name);
            HasManyToMany(x => x.Albums).ParentKeyColumn("CategoryId").ChildKeyColumn("AlbumId").Table("CategoriesAlbums");
            Table("Category");
        }
    }
}
