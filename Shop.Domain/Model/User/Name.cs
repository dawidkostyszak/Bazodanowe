using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.User
{
    public class Name
    {
        [NotNullValidator(MessageTemplate = "Add First Name")]
        [StringLengthValidator(3, 20, MessageTemplate = "First Name must be between 3 and 20 characters")]
        public virtual string FirstName { get; set; }
        [NotNullValidator(MessageTemplate = "Add Last Name")]
        [StringLengthValidator(3, 20, MessageTemplate = "Last Name must be between 3 and 20 characters")]
        public virtual string LastName { get; set; }
    }
}
