using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;

namespace Shop.Application
{
    public interface IProductService
    {
        //Album
        Album CreateNewAlbum(Album album);
        void EditAlbum(Album album);
        void DeleteAlbum(int id);
        Album GetAlbum(int id);
        List<Album> GetAllAlbumsForCategory(Category category);
        List<Album> GetAllAlbumsForArtist(Artist artist);
        List<Album> GetAllAlbumsForType(string type);
        List<Album> GetAllAlbums();

        //Artist
        Artist CreateNewArtist(Artist artist);
        void DeleteArtist(int id);
        List<Artist> GetAllArtists();
        Artist GetArtist(int id);

        //Category
        Category CreateNewCategory(Category category);
        void DeleteCategory(int id);
        List<Category> GetAllCategory();
    }
}
