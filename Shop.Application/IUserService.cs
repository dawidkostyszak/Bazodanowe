using System.Collections.Generic;
using Shop.Domain.Model.User;

namespace Shop.Application
{
    public interface IUserService
    {
        void CreateUser(User user);
        void EditUserAdress(int id, Address newAddress);
        void EditUserName(int id, Name newName);
        void EditUserEmailAddress(int id, string newEmailAddress);
        void EditUserPassword(int id, string newPassword);
        void EditUserPhoneNumber(int id, int newPhoneNumber);
        void DeleteUser(int id);
        bool LoginUser(string username, string password);
        bool LogoutUser(User user);
        List<User> GetAllUsers();
        User GetUser(int id);
    }
}
