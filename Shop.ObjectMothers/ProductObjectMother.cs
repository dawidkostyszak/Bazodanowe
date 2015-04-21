using System;
using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;

namespace Shop.ObjectMothers
{
    public class ProductObjectMother
    {
        public static Album CreateAlbum(int id)
        {
            Artist artist = CreateArtist(id);
            Category category = CreateCategory(id);
            return new Album { Id = id, Content = "Utwory", Artist = artist, Categories = new List<Category> { category }, Name = "Tytul", Price = 10, Type = "CD", PublishDate = DateTime.Now };
        }

        public static Artist CreateArtist(int id)
        {
            return new Artist{Id = id, Name = "Eminem"};
        }

        public static Category CreateCategory(int id)
        {
            return new Category { Id = id, Name = "Hip-Hop" };
        }
    }
}
