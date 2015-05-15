using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class ArtistIM : IArtistRepository
    {
        private ISession _session;

        public ArtistIM(ISession session)
        {
            _session = session;
        }

        public Artist Insert(Artist artist)
        {
            _session.Save(artist);
            return artist;
        }

        public void Edit(Artist artist)
        {
            _session.Merge(artist);
        }

        public void Delete(int id)
        {
            var artistQuery = _session.Get<Artist>(id);
            _session.Delete(artistQuery);
        }

        public List<Artist> FindAll(string sortOrder)
        {
            var artists = _session.Query<Artist>();
            switch (sortOrder)
            {
                case "name_desc":
                    artists = artists.OrderByDescending(c => c.Name);
                    break;
                default:
                    artists = artists.OrderBy(c => c.Name);
                    break;
            }
            return artists.ToList();
        }

        public Artist Find(int id)
        {
            return _session.Get<Artist>(id);
        }

        public List<Artist> Filter(string name)
        {
            return _session.Query<Artist>().Where(a => a.Name.Contains(name)).ToList();
        }
    }
}
