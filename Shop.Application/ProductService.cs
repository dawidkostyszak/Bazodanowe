using System.Collections.Generic;
using NHibernate;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;
using Shop.Infrastructure;
using Shop.Infrastructure.Repositories.NHibernateRepo;

namespace Shop.Application
{
    public class ProductService : IProductService
    {
        private IAlbumRepository _albumRepository;
        private IArtistRepository _artistRepository;
        private ICategoryRepository _categoryRepository;

        private readonly ISession _session = NHibernateHelper.GetSession();

        //Product Service
        public ProductService()
        {
            _artistRepository = new ArtistIM(_session);
            _categoryRepository = new CategoryIM(_session);
            _albumRepository = new AlbumIM(_session);
        }

        public ProductService(IAlbumRepository albumRepository, IArtistRepository artistRepository, ICategoryRepository categoryRepository)
        {
            this._albumRepository = albumRepository;
            this._artistRepository = artistRepository;
            this._categoryRepository = categoryRepository;
        }

        //Album
        public Album CreateAlbum(Album album)
        {
            return _albumRepository.Insert(album);
        }

        public void EditAlbum(Album album)
        {
            _albumRepository.Edit(album);
        }

        public void DeleteAlbum(int id)
        {
            _albumRepository.Delete(id);
        }

        public Album GetAlbum(int id)
        {
            return _albumRepository.Find(id);
        }

        public List<Album> GetAlbumsForCategory(Category category)
        {
            return _albumRepository.FindByCategory(category);
        }

        public List<Album> GetAlbumsForArtist(Artist artist)
        {
            return _albumRepository.FindByArtist(artist);
        }

        public List<Album> GetAlbumsForType(string type)
        {
            return _albumRepository.FindByType(type);
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.FindAll();
        }

        //Artist
        public Artist CreateArtist(Artist artist)
        {
            return _artistRepository.Insert(artist);
        }

        public void EditArtist(Artist artist)
        {
            _artistRepository.Edit(artist);
        }

        public void DeleteArtist(int id)
        {
            _artistRepository.Delete(id);
        }

        public List<Artist> GetAllArtists()
        {
            return _artistRepository.FindAll();
        }

        public Artist GetArtist(int id)
        {
            return _artistRepository.Find(id);
        }

        //Category
        public Category CreateCategory(Category category)
        {
            return _categoryRepository.Insert(category);
        }

        public void EditCategory(Category category)
        {
            _categoryRepository.Edit(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public Category GetCategory(int id)
        {
            return _categoryRepository.Find(id);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.FindAll();
        }
    }
}
