﻿using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Shop.Domain.Model.User;
using Shop.Domain.Model.User.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class UserIM : IUserRepository
    {
        private ISession _session;

        public UserIM(ISession session)
        {
            _session = session;
        }

        public User Insert(User user)
        {
            _session.Save(user);
            return user;
        }

        public void Edit(User user)
        {
            _session.Merge(user);
        }

        public void Delete(int id)
        {
            var userQuery = _session.Get<User>(id);
            _session.Delete(userQuery);
        }

        public User Login(string username, string password)
        {
            var userQuery = (from u in _session.Query<User>() where u.Validations.Username == username && u.Validations.Password == password select u).Single();
            userQuery.Validations.Logged = true;
            _session.Update(userQuery);
            return userQuery;
        }

        public User Logout(int id)
        {
            var userQuery = _session.Get<User>(id);
            userQuery.Validations.Logged = false;
            _session.Update(userQuery);
            return userQuery;
        }

        public List<User> FindAll(string sortOrder)
        {
            var users = _session.Query<User>();
            switch (sortOrder)
            {
                case "lastname_desc":
                    users = users.OrderByDescending(a => a.Name.LastName);
                    break;
                case "lastname_asc":
                    users = users.OrderBy(a => a.Name.LastName);
                    break;
                case "firstname_desc":
                    users = users.OrderByDescending(a => a.Name.FirstName);
                    break;
                default:
                    users = users.OrderBy(a => a.Name.FirstName);
                    break;
            }
            return users.ToList();
        }

        public User Find(int id)
        {
            return _session.Get<User>(id);
        }

        public List<User> Filter(string filterValue)
        {
            return _session.Query<User>().AsEnumerable().Where(a => string.Format("{0} {1}", a.Name.FirstName, a.Name.LastName).Contains(filterValue)).ToList();
        }
    }
}
