using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;

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

        public List<Album> FindAll(string sortOrder)
        {
            var albums = _session.Query<Album>();
            switch (sortOrder)
            {
                case "artist_desc":
                    albums = albums.OrderByDescending(a => a.Artist.Name);
                    break;
                case "artist_asc":
                    albums = albums.OrderBy(a => a.Artist.Name);
                    break;
                case "category_desc":
                    albums = albums.OrderByDescending(a => a.Category.Name);
                    break;
                case "category_asc":
                    albums = albums.OrderBy(a => a.Category.Name);
                    break;
                case "name_desc":
                    albums = albums.OrderByDescending(a => a.Name);
                    break;
                case "type_desc":
                    albums = albums.OrderByDescending(a => a.Type);
                    break;
                case "type_asc":
                    albums = albums.OrderBy(a => a.Type);
                    break;
                default:
                    albums = albums.OrderBy(a => a.Name);
                    break;
            }
            return albums.ToList();
        }

        public List<Album> Filter(string filterName, string filterValue)
        {
            var albums = _session.Query<Album>();
            switch (filterName)
            {
                case "artist":
                    albums = albums.Where(a => a.Artist.Name.Contains(filterValue));
                    break;
                case "category":
                    albums = albums.Where(a => a.Category.Name.Contains(filterValue));
                    break;
                case "name":
                    albums = albums.Where(a => a.Name.Contains(filterValue));
                    break;
                case "type":
                    albums = albums.Where(a => a.Type.Contains(filterValue));
                    break;
            }
            return albums.ToList();
        }
    }
}
