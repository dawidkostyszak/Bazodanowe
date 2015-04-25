using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.User;
using Shop.Domain.Model.User.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class UserIM : IUserRepository
    {
        private List<User> _users = new List<User>();

        public User Insert(User user)
        {
            _users.Add(user);
            return user;
        }

        public void EditAddress(int id, Address newAddress)
        {
            foreach (var u in _users.Where(u => u.Id == id))
                u.Address = newAddress;
        }

        public void EditName(int id, Name newName)
        {
            foreach (var u in _users.Where(u => u.Id == id))
                u.Name = newName;
        }

        public void EditEmailAddress(int id, string newEmailAddress)
        {
            foreach (var u in _users.Where(u => u.Id == id))
                u.EmailAddress = newEmailAddress;
        }

        public void EditPassword(int id, string newPassword)
        {
            foreach (var u in _users.Where(u => u.Id == id))
                u.Validations.Password = newPassword;
        }

        public void EditPhoneNumber(int id, string newPhoneNumber)
        {
            foreach (var u in _users.Where(u => u.Id == id))
                u.PhoneNumber = newPhoneNumber;
        }

        public void Delete(int id)
        {
            foreach (var u in _users.Where(u => u.Id == id))
            {
                _users.Remove(u);
                break;
            }
        }

        public User Login(string username, string password)
        {
            foreach (var u in _users.Where(u => u.Validations.Username == username && u.Validations.Password == password))
            {
                u.Validations.Logged = true;
                return u;
            }

            return null;
        }

        public User Logout(int id)
        {
            foreach (var u in _users.Where(u => u.Id == id && u.Validations.Logged))
            {
                u.Validations.Logged = false;
                return u;
            }

            return null;
        }

        public List<User> FindAll()
        {
            return _users;
        }

        public User Find(int id)
        {
            return _users.Single(u => u.Id == id);
        }
    }
}
