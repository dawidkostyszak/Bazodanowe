using System.Collections.Generic;

namespace Shop.Domain.Model.Album.Repositories
{
    public interface ICategoryRepository
    {
        Category Insert(Category category);

        void Edit(Category category);

        void Delete(int id);

        List<Category> FindAll(string sortOrder);

        Category Find(int id);

        List<Category> Filter(string name);
    }
}
