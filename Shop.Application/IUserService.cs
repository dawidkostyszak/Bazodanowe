using System.Collections.Generic;
using Shop.Domain.Model.User;

namespace Shop.Application
{
    public interface IUserService
    {
        User CreateUser(User user);
        void EditUser(User user);
        void DeleteUser(int id);
        bool LoginUser(string username, string password);
        bool LogoutUser(User user);
        List<User> GetAllUsers(string sortOrder = "name_asc");
        User GetUser(int id);
        List<User> FilterUserByName(string filterValue);
    }
}
