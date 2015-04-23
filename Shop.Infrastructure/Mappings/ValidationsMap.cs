using FluentNHibernate.Mapping;
using Shop.Domain.Model.User;

namespace Shop.Infrastructure.Mappings
{
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
