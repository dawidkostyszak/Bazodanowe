using System.Collections.Generic;

namespace Shop.Domain.Model.Album.Repositories
{
    public interface IAlbumRepository
    {
        Album Insert(Album album);

        void Edit(Album album);

        void Delete(int id);

        Album Find(int id);

        List<Album> FindAll(string sortOrder);

        List<Album> Filter(string filterName, string filterValue);

    }
}
