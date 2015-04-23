using System;
using System.Collections.Generic;
using Shop.Application;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;

namespace Application
{
    class Program
    {
        static void Main()
        {
            ClearDatabase();

            IProductService productService = new ProductService();
//            var session = NHibernateHelper.OpenSession();
//            IUserService userService = new UserService();
//            IOrderService orderService = new OrderService();

            var artist = new Artist {Name = "AC/DC"};
            var category = new Category {Name = "Rock"};

//            productService.CreateNewArtist(artist);
            productService.CreateNewCategory(category);
            productService.CreateNewAlbum(new Album {Name = "Album1", Artist = artist, Categories = new List<Category>{category}, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100});
//            var album = productService.GetAlbum(1);
//            album.Categories.Add(category);
//            var albums = productService.GetAllAlbums();
//            foreach (var a in albums)
//                Console.WriteLine(string.Format("{0}, {1}", a.PublishDate, a.Content));
        }

        static private void ClearDatabase()
        {
            IProductService productService = new ProductService();
            foreach (var a in productService.GetAllAlbums())
            {
                productService.DeleteAlbum(a.Id);
            }
            foreach (var a in productService.GetAllArtists())
            {
                productService.DeleteArtist(a.Id);
            }
            foreach (var c in productService.GetAllCategory())
            {
                productService.DeleteCategory(c.Id);
            }
        }
    }
}
