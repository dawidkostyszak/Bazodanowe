﻿using System.Collections.Generic;

namespace Shop.Domain.Model.Album.Repositories
{
    public interface ICategoryRepository
    {
        void Insert(Category category);

        void Delete(int id);

        List<Category> FindAll();
    }
}