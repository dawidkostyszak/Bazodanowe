using System;
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
            return new Album {Content = "Utwory", Name = "Tytul", Price = 10, Type = "CD", PublishDate = DateTime.Now };
        }

        public static Artist CreateArtist()
        {
            return new Artist{Name = "Eminem"};
        }

        public static Category CreateCategory()
        {
            return new Category {Name = "Hip-Hop" };
        }
    }
}
