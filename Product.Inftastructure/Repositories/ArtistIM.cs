using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;

namespace Shop.Inftastructure.Repositories
{
    public class ArtistIM : IArtistRepository
    {
        private List<Artist> artists = new List<Artist>();

        public ArtistIM()
        {
            artists = new List<Artist>
            {
                new Artist{Id = 1, Name = "Artist"},
                new Artist{Id = 2, Name = "Artist2"},
                new Artist{Id = 3, Name = "Artist3"}
            };
        }

        public void Insert(Artist artist)
        {
            artists.Add(artist);
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
