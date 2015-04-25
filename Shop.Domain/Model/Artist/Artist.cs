using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Shop.Domain.Model.Artist
{
    public class Artist
    {
        public virtual int Id { get; set; }
        [StringLengthValidator(3, 50, MessageTemplate = "Add artist name")]
        public virtual string Name { get; set; }
        public virtual ICollection<Album.Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album.Album>();
        }
    }
}
