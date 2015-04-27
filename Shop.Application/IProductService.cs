using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;

namespace Shop.Application
{
    public interface IProductService
    {
        //Album
        Album CreateAlbum(Album album);
        void EditAlbum(Album album);
        void DeleteAlbum(int id);
        Album GetAlbum(int id);
        List<Album> GetAlbumsForCategory(Category category);
        List<Album> GetAlbumsForArtist(Artist artist);
        List<Album> GetAlbumsForType(string type);
        List<Album> GetAllAlbums();

        //Artist
        Artist CreateArtist(Artist artist);
        void EditArtist(Artist artist);
        void DeleteArtist(int id);
        List<Artist> GetAllArtists();
        Artist GetArtist(int id);

        //Category
        Category CreateCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
        Category GetCategory(int id);
        List<Category> GetAllCategory();
    }
}
