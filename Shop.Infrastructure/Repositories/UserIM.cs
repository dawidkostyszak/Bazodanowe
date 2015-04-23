using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.User;
using Shop.Domain.Model.User.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class UserIM : IUserRepository
    {
        private List<User> _users = new List<User>();

        public UserIM()
        {
            _users = new List<User>
            {
                new User {Id = 1, Address = new Address(), Name = new Name(), EmailAddress = "bob@gmail.com", PhoneNumber = 123456789, Role = UserRole.Customer,Validations = new Validations()},
                new User {Id = 2, Address = new Address(), Name = new Name(), EmailAddress = "bob2@gmail.com", PhoneNumber = 123456789, Role = UserRole.Customer, Validations = new Validations()},
                new User {Id = 3, Address = new Address(), Name = new Name(), EmailAddress = "bob3@gmail.com", PhoneNumber = 123456789, Role = UserRole.Worker, Validations = new Validations()}
            };
        }

        public void Insert(User user)
        {
            _users.Add(user);
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

        public void EditPhoneNumber(int id, int newPhoneNumber)
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
