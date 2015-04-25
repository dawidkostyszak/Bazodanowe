using System;
using System.Collections.Generic;
using Shop.Application;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.User;

namespace Application
{
    class Program
    {
        static void Main()
        {
//            ClearDatabase();
            CreateData();
        }

        static private void ClearDatabase()
        {
            IProductService productService = new ProductService();
            IUserService userService = new UserService();
            IOrderService orderService = new OrderService();
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
//            foreach (var u in userService.GetAllUsers())
//            {
//                userService.DeleteUser(u.Id);
//            }
            foreach (var o in orderService.GetAllOrders())
            {
                orderService.DeleteOrder(o.Id);
            }
        }

        static private void CreateData()
        {
            IProductService productService = new ProductService();
            IUserService userService = new UserService();
            IOrderService orderService = new OrderService();

            for (var i = 0; i <= 10; i++)
            {
                var artist = productService.CreateNewArtist(new Artist { Name = "AC/DC" });
                var category = productService.CreateNewCategory(new Category { Name = "Rock" });
                productService.CreateNewAlbum(new Album { Name = "Album" + i, Artist = artist, Category = category, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100 });
            }

            var ar = productService.CreateNewArtist(new Artist { Name = "AC/DC" });
            var cat = productService.CreateNewCategory(new Category { Name = "Rock" });
            var album = productService.CreateNewAlbum(new Album { Name = "Inny Album", Artist = ar, Category = cat, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100 });
            var user = userService.CreateUser(new User{Address = new Address{City = "Wrocław", Flat = "1", House = "1", Street = "Ostrowskiego", ZipCode = "59-220"}, EmailAddress = "test@test.pl", Name = new Name{FirstName = "Jan", LastName = "Kowalski"}, PhoneNumber = "123456789", Role = UserRole.Customer, Validations = new Validations{Username = "user" + DateTime.Now.TimeOfDay, Password = "user"}});
            orderService.CreateNewOrder(new Order{CreatedAt = DateTime.Now, Customer = user, InvoiceNumber = "ABC", Price = 100, Products = new List<Album>{album}, Status = OrderStatus.Created});
        }
    }
}
