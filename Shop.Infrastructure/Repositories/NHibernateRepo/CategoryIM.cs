using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class CategoryIM : ICategoryRepository
    {
        private ISession _session;

        public CategoryIM(ISession session)
        {
            _session = session;
        }

        public Category Insert(Category category)
        {
            _session.Save(category);
            return category;
        }

        public void Edit(Category category)
        {
            _session.Merge(category);
        }

        public void Delete(int id)
        {
            var categoryQuery = _session.Get<Category>(id);
            _session.Delete(categoryQuery);
        }

        public List<Category> FindAll(string sortOrder)
        {
            var categories = _session.Query<Category>();
            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(c => c.Name);
                    break;
                default:
                    categories = categories.OrderBy(c => c.Name);
                    break;
            }
            return categories.ToList();
        }

        public Category Find(int id)
        {
            return _session.Get<Category>(id);
        }

        public List<Category> Filter(string name)
        {
            return _session.Query<Category>().Where(c => c.Name.Contains(name)).ToList();
        }
    }
}
