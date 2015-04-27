using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class ArtistIM : IArtistRepository
    {
        private List<Artist> artists = new List<Artist>();

        public Artist Insert(Artist artist)
        {
            artists.Add(artist);
            return artist;
        }

        public void Delete(int id)
        {
            foreach (var a in artists.Where(a => a.Id == id))
            {
                artists.Remove(a);
                break;
            }
        }

        public List<Artist> FindAll()
        {
            return artists;
        }

        public Artist Find(int id)
        {
            return artists.Single(a => a.Id == id);
        }
    }
}
