using System.Collections.Generic;

namespace Shop.Domain.Model.Artist.Repositories
{
    public interface IArtistRepository
    {
        void Insert(Artist artist);

        void Delete(int id);

        List<Artist> FindAll();

        Artist Find(int id);
    }
}
