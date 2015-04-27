using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name);
            Table("Category");
        }
    }
}
