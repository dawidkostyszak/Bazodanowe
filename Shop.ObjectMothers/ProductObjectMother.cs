using System;
using System.Collections.Generic;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;

namespace Shop.ObjectMothers
{
    public class ProductObjectMother
    {
        public static Album CreateAlbum()
        {
            Artist artist = CreateArtist();
            Category category = CreateCategory();
            return new Album { Id = 100, Content = "Utwory", Artist = artist, Categories = new List<Category> { category }, Name = "Tytul", Price = 10, Type = "CD", PublishDate = DateTime.Now };
        }

        public static Artist CreateArtist()
        {
            return new Artist{Id = 100, Name = "Eminem"};
        }

        public static Category CreateCategory()
        {
            return new Category { Id = 100, Name = "Hip-Hop" };
        }
    }
}
