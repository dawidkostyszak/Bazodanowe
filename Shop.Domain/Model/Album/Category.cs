using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Album
{
    public class Category
    {
        public virtual int Id { get; set; }
        [StringLengthValidator(3, 20, MessageTemplate = "Add category name")]
        public virtual string Name { get; set; }
    }
}
