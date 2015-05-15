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
        List<Album> GetAlbumsForName(string name);
        List<Album> GetAlbumsForCategory(string category);
        List<Album> GetAlbumsForArtist(string artist);
        List<Album> GetAlbumsForType(string type);
        List<Album> GetAllAlbums(string sortOrder = "name_asc");

        //Artist
        Artist CreateArtist(Artist artist);
        void EditArtist(Artist artist);
        void DeleteArtist(int id);
        List<Artist> GetAllArtists(string sortOrder = "name_asc");
        List<Artist> GetArtistsForName(string artistName);
        Artist GetArtist(int id);

        //Category
        Category CreateCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
        Category GetCategory(int id);
        List<Category> GetAllCategory(string sortOrder = "name_asc");
        List<Category> GetCategoriesForName(string categoryName);
    }
}
