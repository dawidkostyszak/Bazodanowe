using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Artist
{
    public class Artist
    {
        public virtual int Id { get; set; }
        [NotNullValidator(MessageTemplate = "Add name")]
        [StringLengthValidator(3, 50, MessageTemplate = "Artist name must be between 3 and 50 characters")]
        public virtual string Name { get; set; }
        public virtual ICollection<Album.Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album.Album>();
        }
    }
}
