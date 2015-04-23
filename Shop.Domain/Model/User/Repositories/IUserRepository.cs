using System.Collections.Generic;

namespace Shop.Domain.Model.User.Repositories
{
    public interface IUserRepository
    {
        User Insert(User user);

        void EditAddress(int id, Address newAddress);

        void EditName(int id, Name newName);

        void EditEmailAddress(int id, string newEmailAddress);

        void EditPassword(int id, string newPassword);

        void EditPhoneNumber(int id, int newPhoneNumber);

        void Delete(int id);

        User Login(string username, string password);

        User Logout(int id);

        List<User> FindAll();

        User Find(int id);
    }
}
