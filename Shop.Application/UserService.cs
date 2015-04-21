using System.Collections.Generic;
using Shop.Domain.Model.User;
using Shop.Domain.Model.User.Repositories;
using Shop.Infrastructure.Repositories.NHibernateRepo;

namespace Shop.Application
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        //User Service
        public UserService()
        {
            _userRepository = new UserIM();
        }
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            _userRepository.Insert(user);
        }

        public void EditUserAdress(int id, Address newAddress)
        {
            _userRepository.EditAddress(id, newAddress);
        }

        public void EditUserName(int id, Name newName)
        {
            _userRepository.EditName(id, newName);
        }

        public void EditUserEmailAddress(int id, string newEmailAddress)
        {
            _userRepository.EditEmailAddress(id, newEmailAddress);
        }

        public void EditUserPassword(int id, string newPassword)
        {
            _userRepository.EditPassword(id, newPassword);
        }

        public void EditUserPhoneNumber(int id, int newPhoneNumber)
        {
            _userRepository.EditPhoneNumber(id, newPhoneNumber);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public bool LoginUser(string username, string password)
        {
            return _userRepository.Login(username, password) != null;
        }

        public bool LogoutUser(User user)
        {
            return _userRepository.Logout(user.Id) != null;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.FindAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.Find(id);
        }
    }
}
