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
            IProductService productService = new ProductService();
//            IUserService userService = new UserService();
//            IOrderService orderService = new OrderService();

            var artist = new Artist {Id = 1, Name = "AC/DC"};
            var category = new Category {Id = 1, Name = "Rock"};

            productService.CreateNewArtist(artist);
            productService.CreateNewCategory(category);
            productService.CreateNewAlbum(new Album{Id = 1, Name = "Album1", Artist = artist, Categories = new List<Category>{category}, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100});

            foreach (var a in productService.GetAllAlbums())
                Console.WriteLine(string.Format("{0}, {1}", a.Price, a.PublishDate));
        }
    }
}
