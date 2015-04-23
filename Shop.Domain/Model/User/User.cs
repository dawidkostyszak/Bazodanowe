using System.Collections.Generic;

namespace Shop.Domain.Model.User
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual Address Address { get; set; }
        public virtual Name Name { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual int PhoneNumber { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual Validations Validations { get; set; }
    }
}
