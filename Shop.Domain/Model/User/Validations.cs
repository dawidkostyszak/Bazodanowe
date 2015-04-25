using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.User
{
    public class Validations
    {
        [StringLengthValidator(5, 20, MessageTemplate = "Add username", ErrorMessage = "Username must be between 5 and 20 characters")]
        [RegexValidator(@"\d*\w", ErrorMessage = "Username can contain only letters and digits")]
        public virtual string Username { get; set; }
        [StringLengthValidator(5, 20, MessageTemplate = "Add password", ErrorMessage = "Password must be between 5 and 20 characters")]
        public virtual string Password { get; set; }
        public virtual bool Logged { get; set; }
    }
}
