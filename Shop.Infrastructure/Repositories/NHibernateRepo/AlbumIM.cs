using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class AlbumIM : IAlbumRepository
    {
        private ISession _session;

        public AlbumIM(ISession session)
        {
            _session = session;
        }

        public Album Insert(Album album)
        {
            _session.Save(album);
	        return album;

        }

        public void Edit(Album album)
        {
            _session.Merge(album);
        }

        public void Delete(int id)
        {
            var albumQuery = _session.Get<Album>(id);
            _session.Delete(albumQuery);
        }

        public Album Find(int id)
        {
            return _session.Get<Album>(id);
        }

        public List<Album> FindAll()
        {
            return _session.Query<Album>().ToList();
        }

        public List<Album> FindByArtist(Artist artist)
        {
            return (from a in _session.Query<Album>() where a.Artist == artist select a).ToList();
        }

        public List<Album> FindByCategory(Category category)
        {
            return (from a in _session.Query<Album>() where a.Category == category select a).ToList();
        }

        public List<Album> FindByType(string type)
        {
            return (from a in _session.Query<Album>() where a.Type == type select a).ToList();
        }
    }
}
