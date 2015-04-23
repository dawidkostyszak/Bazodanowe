using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class AlbumIM : IAlbumRepository
    {
        public void Insert(Album album)
        {
            using (var session = NHibernateHelper.OpenSession())
	        {
	            using (var transaction = session.BeginTransaction())
	            {
	                session.Insert(album.Artist);
                    foreach (var category in album.Categories)
                    {
                        session.Insert(category);
                    }
                    session.Insert(album);
	                transaction.Commit();
	            }
	        }
        }

        public void Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var albumQuery = (from a in session.Query<Album>() where a.Id == id select a).Single();
                    session.Delete(albumQuery);
                    transaction.Commit();
                }
            }
        }

        public Album Find(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from a in session.Query<Album>() where a.Id == id select a).Single();
            }
        }

        public List<Album> FindAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Album>().ToList();
            }
        }

        public List<Album> FindByArtist(Artist artist)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from a in session.Query<Album>() where a.Artist == artist select a).ToList();
            }
        }

        public List<Album> FindByCategory(Category category)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from a in session.Query<Album>() from c in a.Categories where c == category select a).ToList();
            }
        }

        public List<Album> FindByType(string type)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from a in session.Query<Album>() where a.Type == type select a).ToList();
            }
        }
    }
}
