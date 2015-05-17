using System.Collections.Generic;
using NHibernate;
using Shop.Domain.Model.User;
using Shop.Domain.Model.User.Repositories;
using Shop.Infrastructure;
using Shop.Infrastructure.Repositories.NHibernateRepo;

namespace Shop.Application
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        private readonly ISession _session = NHibernateHelper.GetSession();

        //User Service
        public UserService()
        {
            _userRepository = new UserIM(_session);
        }

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            return _userRepository.Insert(user);
        }

        public void EditUser(User user)
        {
            _userRepository.Edit(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public bool LoginUser(string username, string password)
        {
            var transaction = _session.BeginTransaction();
            var user = _userRepository.Login(username, password);
            transaction.Commit();
            return user != null;
        }

        public bool LogoutUser(User user)
        {
            var transaction = _session.BeginTransaction();
            user = _userRepository.Logout(user.Id);
            transaction.Commit();
            return user != null;
        }

        public List<User> GetAllUsers(string sortOrder)
        {
            return _userRepository.FindAll(sortOrder);
        }

        public User GetUser(int id)
        {
            return _userRepository.Find(id);
        }

        public List<User> FilterUserByName(string filterValue)
        {
            return _userRepository.Filter(filterValue);
        }
    }
}
