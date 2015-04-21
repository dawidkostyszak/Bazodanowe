using NHibernate.Type;

namespace Shop.Domain.Model.User
{
    public enum UserRole
    {
        Customer,
        Worker
    }

    public class UserRoleType : EnumStringType<UserRole>
    {
        public static string GetDescription(UserRole role)
        {
            switch (role)
            {
                case UserRole.Customer: return "Customer";
                case UserRole.Worker: return "Worker";
                default: return string.Empty;
            }
        }
    }
}
