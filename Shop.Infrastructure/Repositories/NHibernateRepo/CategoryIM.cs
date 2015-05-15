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

        public List<Category> FindAll()
        {
            return _session.Query<Category>().ToList();
        }

        public Category Find(int id)
        {
            return _session.Get<Category>(id);
        }
    }
}
