﻿using System.Collections.Generic;

namespace Shop.Domain.Model.User.Repositories
{
    public interface IUserRepository
    {
        User Insert(User user);

        void Edit(User user);

        void Delete(int id);

        User Login(string username, string password);

        User Logout(int id);

        List<User> FindAll(string sortOrder);

        User Find(int id);

        List<User> Filter(string filterValue);
    }
}
