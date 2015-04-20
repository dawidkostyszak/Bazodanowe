using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class CategoryIM : ICategoryRepository
    {
        public CategoryIM()
        {
            Insert(new Category {Id = 1, Name = "Rock"});
            Insert(new Category {Id = 2, Name = "Soul"});
            Insert(new Category {Id = 3, Name = "Jazz"});
        }

        public void Insert(Category category)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(category);
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categoryQuery = (from a in session.Query<Category>() where a.Id == id select a).Single();
                    session.Delete(categoryQuery);
                    transaction.Commit();
                }
            }
        }

        public List<Category> FindAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Category>().ToList();
            }
        }
    }
}
