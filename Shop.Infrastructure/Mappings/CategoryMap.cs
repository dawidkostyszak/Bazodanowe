﻿using FluentNHibernate.Mapping;
using Shop.Domain.Model.Album;

namespace Shop.Infrastructure.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Name);
            HasMany(x => x.Albums).ForeignKeyCascadeOnDelete().Inverse().KeyColumn("CategoryId").LazyLoad();
            Table("Category");
        }
    }
}
