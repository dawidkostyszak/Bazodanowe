using FluentNHibernate.Mapping;
using Shop.Domain.Model.User;

namespace Shop.Infrastructure.Mappings
{
    public class NameMap : ComponentMap<Name>
    {
        public NameMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
