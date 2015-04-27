using FluentNHibernate.Mapping;
using Shop.Domain.Model.User;

namespace Shop.Infrastructure.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Component(x => x.Address);
            Component(x => x.Name);
            Map(x => x.EmailAddress);
            Map(x => x.PhoneNumber);
            Map(x => x.Role).CustomType<UserRoleType>();
            Component(x => x.Validations);
            Table("[User]");
        }
    }
}
