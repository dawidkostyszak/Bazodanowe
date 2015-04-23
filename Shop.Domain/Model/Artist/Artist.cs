using System.Collections.Generic;

namespace Shop.Domain.Model.Artist
{
    public class Artist
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Album.Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album.Album>();
        }
    }
}
