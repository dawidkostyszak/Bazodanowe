using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Album
{
    public class Category
    {
        public virtual int Id { get; set; }
        [StringLengthValidator(3, 20, MessageTemplate = "Add category name")]
        public virtual string Name { get; set; }
        public virtual IList<Album> Albums { get; set; }

        public Category()
        {
            Albums = new List<Album>();
        }
    }
}
