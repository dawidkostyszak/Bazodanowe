using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.User
{
    public class Name
    {
        [StringLengthValidator(3, 20, MessageTemplate = "Add First Name", ErrorMessage = "First Name must be between 3 and 20 characters")]
        public virtual string FirstName { get; set; }
        [StringLengthValidator(3, 20, MessageTemplate = "Add Last Name", ErrorMessage = "Last Name must be between 3 and 20 characters")]
        public virtual string LastName { get; set; }
    }
}
