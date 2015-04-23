using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class CategoryIM : ICategoryRepository
    {
        private List<Category> categories = new List<Category>();

        public CategoryIM()
        {
            categories = new List<Category>
            {
                new Category {Id = 1, Name = "Rock"},
                new Category {Id = 2, Name = "Soul"},
                new Category {Id = 3, Name = "Jazz"}
            };
        }

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
