using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;
using Shop.Inftastructure.Repositories;

namespace Shop.Application
{
    public class ProductService : IProductService
    {
        private IAlbumRepository _albumRepository;
        private IArtistRepository _artistRepository;
        private ICategoryRepository _categoryRepository;

        //Product Service
        public ProductService()
        {
            _albumRepository = new AlbumIM();
            _artistRepository = new ArtistIM();
            _categoryRepository = new CategoryIM();
        }
        public ProductService(IAlbumRepository albumRepository, IArtistRepository artistRepository, ICategoryRepository categoryRepository)
        {
            this._albumRepository = albumRepository;
            this._artistRepository = artistRepository;
            this._categoryRepository = categoryRepository;
        }

        //Album
        public void CreateNewAlbum(Album album)
        {
            _albumRepository.Insert(album);
        }
        public void DeleteAlbum(int id)
        {
            _albumRepository.Delete(id);
        }
        public Album GetAlbum(int id)
        {
            return _albumRepository.Find(id);
        }
        public List<Album> GetAllAlbumsForCategory(Category category)
        {
            return _albumRepository.FindByCategory(category);
        }
        public List<Album> GetAllAlbumsForArtist(Artist artist)
        {
            return _albumRepository.FindByArtist(artist);
        }
        public List<Album> GetAllAlbumsForType(string type)
        {
            return _albumRepository.FindByType(type);
        }
        public List<Album> GetAllAlbums()
        {
            return _albumRepository.FindAll();
        }

        //Artist
        public void CreateNewArtist(Artist artist)
        {
            _artistRepository.Insert(artist);
        }
        public void DeleteArtist(int id)
        {
            _artistRepository.Delete(id);
        }
        public List<Artist> GetAllArtists()
        {
            return _artistRepository.FindAll();
        }

        //Category
        public void CreateNewCategory(Category category)
        {
            _categoryRepository.Insert(category);
        }
        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }
        public List<Category> GetAllCategory()
        {
            return _categoryRepository.FindAll();
        }
    }
}
