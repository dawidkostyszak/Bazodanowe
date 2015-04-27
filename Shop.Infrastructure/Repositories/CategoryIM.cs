using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class CategoryIM : ICategoryRepository
    {
        private List<Category> categories = new List<Category>();

        public Category Insert(Category category)
        {
            categories.Add(category);
            return category;
        }

        public void Delete(int id)
        {
            foreach (var c in categories.Where(c => c.Id == id))
            {
                categories.Remove(c);
                break;
            }
        }

        public List<Category> FindAll()
        {
            return categories;
        }
    }
}
