using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Album
{
    public class Album
    {
        public virtual int Id { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Artist.Artist Artist { get; set; }
        public virtual Category Category { get; set; }
        [NotNullValidator(MessageTemplate = "Add additional information about album")]
        public virtual string Content { get; set; }
        [NotNullValidator(MessageTemplate = "Add album name")]
        [StringLengthValidator(3, 100, MessageTemplate = "Album name must be between 3 and 100 characters")]
        public virtual string Name { get; set; }
        [NotNullValidator(MessageTemplate = "Add price")]
        public virtual int Price { get; set; }
        [NotNullValidator(MessageTemplate = "Add publish date")]
        public virtual DateTime PublishDate { get; set; }
        [NotNullValidator(MessageTemplate = "Add type")]
        [RegexValidator("CD|DVD|Vinyl", MessageTemplate = "Type should be CD, DVD or Vinyl")]
        public virtual string Type { get; set; }
    }
}
