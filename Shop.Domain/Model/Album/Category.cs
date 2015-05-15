using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Album
{
    public class Category
    {
        public virtual int Id { get; set; }
        [NotNullValidator(MessageTemplate = "Add name")]
        [StringLengthValidator(3, 20, MessageTemplate = "Category name must be between 3 and 20 characters")]
        public virtual string Name { get; set; }
    }
}
