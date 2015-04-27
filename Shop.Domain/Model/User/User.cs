using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.User
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual Address Address { get; set; }
        public virtual Name Name { get; set; }
        [RegexValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public virtual string EmailAddress { get; set; }
        [StringLengthValidator(9, 9, MessageTemplate = "Add phone number")]
        [RegexValidator(@"\d", ErrorMessage = "Phone number should contain only digits")]
        public virtual string PhoneNumber { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual Validations Validations { get; set; }
    }
}
