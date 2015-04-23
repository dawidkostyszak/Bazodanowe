using FluentNHibernate.Mapping;
using Shop.Domain.Model.User;

namespace Shop.Infrastructure.Mappings
{
    public class AddressMap : ComponentMap<Address>
    {
        public AddressMap()
        {
            Map(x => x.City);
            Map(x => x.Street);
            Map(x => x.House);
            Map(x => x.Flat);
            Map(x => x.ZipCode);
        }
    }
}
