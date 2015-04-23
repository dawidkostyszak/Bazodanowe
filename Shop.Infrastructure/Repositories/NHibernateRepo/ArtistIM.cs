using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class ArtistIM : IArtistRepository
    {
        public Artist Insert(Artist artist)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Insert(artist);
                    transaction.Commit();
                    return artist;
                }
            }
        }

        public void Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var artistQuery = (from a in session.Query<Artist>() where a.Id == id select a).Single();
                    session.Delete(artistQuery);
                    transaction.Commit();
                }
            }
        }

        public List<Artist> FindAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Artist>().ToList();
            }
        }

        public Artist Find(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from a in session.Query<Artist>() where a.Id == id select a).Single();
            }
        }
    }
}
