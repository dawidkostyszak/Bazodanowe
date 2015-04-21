using FluentNHibernate.Mapping;
using Shop.Domain.Model.User;

namespace Shop.Infrastructure.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Not.Nullable().Column("UserId").GeneratedBy.Assigned();
            Component(x => x.Address);
            Component(x => x.Name);
            Map(x => x.EmailAddress);
            Map(x => x.PhoneNumber);
            Map(x => x.Role).CustomType<UserRoleType>();
            Component(x => x.Validations);
            Table("[User]");
        }
    }

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

    public class NameMap : ComponentMap<Name>
    {
        public NameMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }

    public class ValidationsMap : ComponentMap<Validations>
    {
        public ValidationsMap()
        {
            Map(x => x.Username).Unique();
            Map(x => x.Password);
            Map(x => x.Logged);
        }
    }
}
