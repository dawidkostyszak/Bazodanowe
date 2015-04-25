using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Shop.Domain.Model.User;
using Shop.Domain.Model.User.Repositories;

namespace Shop.Infrastructure.Repositories.NHibernateRepo
{
    public class UserIM : IUserRepository
    {
        public User Insert(User user)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Insert(user);
                    transaction.Commit();
                    return user;
                }
            }
        }

        public void EditAddress(int id, Address newAddress)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    userQuery.Address = newAddress;
                    session.Update(userQuery);
                    transaction.Commit();
                }
            }
        }

        public void EditName(int id, Name newName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    userQuery.Name = newName;
                    session.Update(userQuery);
                    transaction.Commit();
                }
            }
        }

        public void EditEmailAddress(int id, string newEmailAddress)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    userQuery.EmailAddress = newEmailAddress;
                    session.Update(userQuery);
                    transaction.Commit();
                }
            }
        }

        public void EditPassword(int id, string newPassword)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    userQuery.Validations.Password = newPassword;
                    session.Update(userQuery);
                    transaction.Commit();
                }
            }
        }

        public void EditPhoneNumber(int id, string newPhoneNumber)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    userQuery.PhoneNumber = newPhoneNumber;
                    session.Update(userQuery);
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
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    session.Delete(userQuery);
                    transaction.Commit();
                }
            }
        }

        public User Login(string username, string password)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Validations.Username == username && u.Validations.Password == password select u).Single();
                    userQuery.Validations.Logged = true;
                    session.Update(userQuery);
                    transaction.Commit();
                    return userQuery;
                }
            }
        }

        public User Logout(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userQuery = (from u in session.Query<User>() where u.Id == id select u).Single();
                    userQuery.Validations.Logged = false;
                    session.Update(userQuery);
                    transaction.Commit();
                    return userQuery;
                }
            }
        }

        public List<User> FindAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<User>().ToList();
            }
        }

        public User Find(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<User>(id);
            }
        }
    }
}
