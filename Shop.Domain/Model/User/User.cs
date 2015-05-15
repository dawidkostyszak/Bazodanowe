using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.User
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual Address Address { get; set; }
        public virtual Name Name { get; set; }
        [RegexValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", MessageTemplate = "Email address should have format John.Smith@example.com")]
        public virtual string EmailAddress { get; set; }
        [StringLengthValidator(9, 9, MessageTemplate = "Phone number should have 9 characters")]
        [RegexValidator(@"\d", MessageTemplate = "Phone number should contain only digits")]
        public virtual string PhoneNumber { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual Validations Validations { get; set; }
    }
}
