using System.Collections.Generic;

namespace Shop.Domain.Model.Artist.Repositories
{
    public interface IArtistRepository
    {
        Artist Insert(Artist artist);

        void Edit(Artist artist);

        void Delete(int id);

        List<Artist> FindAll(string sortOrder);

        Artist Find(int id);

        List<Artist> Filter(string name);
    }
}
