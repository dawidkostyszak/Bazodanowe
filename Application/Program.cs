using System;
using System.Collections.Generic;
using NHibernate;
using Shop.Application;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.User;
using Shop.Infrastructure;

namespace Application
{
    class Program
    {
        private static ISession session = NHibernateHelper.OpenSession();
        private static IProductService productService = new ProductService();
        private static IUserService userService = new UserService();
        private static IOrderService orderService = new OrderService();

        static void Main()
        {
//            ClearDatabase();
            CreateData();
        }

        static private void ClearDatabase()
        {
            var transaction = session.BeginTransaction();
            
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

            foreach (var o in orderService.GetAllOrders())
            {
                orderService.DeleteOrder(o.Id);
            }

            foreach (var u in userService.GetAllUsers())
            {
                userService.DeleteUser(u.Id);
            }

            transaction.Commit();
        }

        static private void CreateData()
        { 
            var transaction = session.BeginTransaction();

            for (var i = 0; i <= 100; i++)
            {
                productService.CreateAlbum(new Album { Name = "A" + i, Artist = new Artist { Name = "AC/DC" }, Category = new Category { Name = "Rock" }, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100 });
            }

            var ar = productService.CreateArtist(new Artist { Name = "AC/DC" });
            var cat = productService.CreateCategory(new Category { Name = "Rock" });
            var album = productService.CreateAlbum(new Album { Name = "Inny Album", Artist = ar, Category = cat, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100 });
            var album2 = productService.CreateAlbum(new Album { Name = "Inn Album", Artist = ar, Category = cat, PublishDate = DateTime.Now, Content = "Opis", Type = "CD", Price = 100 });
            var user = userService.CreateUser(new User{Address = new Address{City = "Wrocław", Flat = "1", House = "1", Street = "Ostrowskiego", ZipCode = "59-220"}, EmailAddress = "test@test.pl", Name = new Name{FirstName = "Jan", LastName = "Kowalski"}, PhoneNumber = "123456789", Role = UserRole.Customer, Validations = new Validations{Username = "user" + DateTime.Now.TimeOfDay, Password = "user"}});
            orderService.CreateOrder(new Order{CreatedAt = DateTime.Now, Customer = user, InvoiceNumber = "ABC", Price = 100, Products = new List<Album>{album}, Status = OrderStatus.Created});
            orderService.CreateOrder(new Order { CreatedAt = DateTime.Now, Customer = user, InvoiceNumber = "ABC", Price = 100, Products = new List<Album> { album, album2 }, Status = OrderStatus.Created });
            
            transaction.Commit();
        }
    }
}
