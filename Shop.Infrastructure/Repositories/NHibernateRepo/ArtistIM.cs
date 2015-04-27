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
            _session.Update(artist);
        }

        public void Delete(int id)
        {
            var artistQuery = _session.Get<Artist>(id);
            _session.Delete(artistQuery);
        }

        public List<Artist> FindAll()
        {
            return _session.Query<Artist>().ToList();
        }

        public Artist Find(int id)
        {
            return _session.Get<Artist>(id);
        }
    }
}
