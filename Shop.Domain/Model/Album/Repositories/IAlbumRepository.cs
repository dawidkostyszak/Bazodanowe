using System.Collections.Generic;

namespace Shop.Domain.Model.Album.Repositories
{
    public interface IAlbumRepository
    {
        Album Insert(Album album);

        void Edit(Album album);

        void Delete(int id);

        Album Find(int id);

        List<Album> FindAll();

        List<Album> FindByArtist(Artist.Artist artist);

        List<Album> FindByCategory(Category category);

        List<Album> FindByType(string type);
    }
}
