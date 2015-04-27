using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;
using Shop.Infrastructure;
using Shop.ObjectMothers;

namespace Shop.Application.UnitTests
{
    [TestClass]
    public class ProductServiceMockTests
    {
        [TestMethod]
        public void CheckFindAlbumMethodCalled()
        {
            Mock<IAlbumRepository> albumMock = new Mock<IAlbumRepository>();
            Mock<IArtistRepository> artistMock = new Mock<IArtistRepository>();
            Mock<ICategoryRepository> categoryMock = new Mock<ICategoryRepository>();
            IProductService ps = new ProductService(albumMock.Object, artistMock.Object, categoryMock.Object);

            ps.GetAllAlbums();

            albumMock.Verify(k => k.FindAll(), Times.Once());
        }

        [TestMethod]
        public void CheckAddAlbumMethodCalled()
        {
            Mock<IAlbumRepository> albumMock = new Mock<IAlbumRepository>();
            Mock<IArtistRepository> artistMock = new Mock<IArtistRepository>();
            Mock<ICategoryRepository> categoryMock = new Mock<ICategoryRepository>();
            IProductService ps = new ProductService(albumMock.Object, artistMock.Object, categoryMock.Object);

            Mock<Album> album = new Mock<Album>();
            ps.CreateAlbum(album.Object);

            albumMock.Verify(k => k.Insert(album.Object), Times.Once());
        }
    }

    [TestClass]
    public class ProductServiceReturnTests
    {
        private ISession _session = NHibernateHelper.OpenSession();
        private IProductService ps = new ProductService();

        public Album CreateArtistCategoryAlbum()
        {
            var transaction = _session.BeginTransaction();

            Artist artist = ps.CreateArtist(ProductObjectMother.CreateArtist());
            Category category = ps.CreateCategory(ProductObjectMother.CreateCategory());
            Album album = ProductObjectMother.CreateAlbum();

            album.Artist = artist;
            album.Category = category;
            album = ps.CreateAlbum(album);

            transaction.Commit();
            return album;
        }

        [TestCleanup]
        public void CleanAfterTest()
        {
            var transaction = _session.BeginTransaction();

            foreach (var a in ps.GetAllAlbums())
            {
                ps.DeleteAlbum(a.Id);
            }

            foreach (var a in ps.GetAllArtists())
            {
                ps.DeleteArtist(a.Id);
            }

            foreach (var c in ps.GetAllCategory())
            {
                ps.DeleteCategory(c.Id);
            }

            transaction.Commit();
        }

        //Album
        [TestMethod]
        public void CheckGetAllAlbumMethodResult()
        {
            CreateArtistCategoryAlbum();
            CreateArtistCategoryAlbum();

            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(2, albums.Count);
        }

        [TestMethod]
        public void CheckAddAlbumMethodResult()
        {
            CreateArtistCategoryAlbum();

            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckDeleteAlbumMethodResult()
        {
            var album = CreateArtistCategoryAlbum();

            var transaction = _session.BeginTransaction();
            ps.DeleteAlbum(album.Id);
            transaction.Commit();

            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(0, albums.Count);
        }

        [TestMethod]
        public void CheckFindAlbumMethodResult()
        {
            var album = CreateArtistCategoryAlbum();

            Album result = ps.GetAlbum(album.Id);

            Assert.AreEqual(album.Id, result.Id);
        }

        [TestMethod]
        public void CheckGetAlbumsForCategoryMethodResult()
        {
            var album = CreateArtistCategoryAlbum();

            List<Album> albums = ps.GetAlbumsForCategory(album.Category);

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckGetAlbumsForArtistMethodResult()
        {
            var album = CreateArtistCategoryAlbum();

            List<Album> albums = ps.GetAlbumsForArtist(album.Artist);

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckGetAlbumsForTypeMethodResult()
        {
            CreateArtistCategoryAlbum();

            List<Album> albums = ps.GetAlbumsForType("CD");

            Assert.AreEqual(1, albums.Count);
        }

        //Artist
        [TestMethod]
        public void CheckGetAllArtistsMethodResult()
        {
            CreateArtistCategoryAlbum();
            CreateArtistCategoryAlbum();

            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(2, artists.Count);
        }

        [TestMethod]
        public void CheckGetArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            var transaction = _session.BeginTransaction();
            ps.CreateArtist(artist);
            transaction.Commit();

            Artist result = ps.GetArtist(artist.Id);

            Assert.AreEqual(artist.Id, result.Id);
        }

        [TestMethod]
        public void CheckCreateArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            var transaction = _session.BeginTransaction();
            ps.CreateArtist(artist);
            transaction.Commit();

            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(1, artists.Count);
        }

        [TestMethod]
        public void CheckDeleteArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            var transaction = _session.BeginTransaction();
            ps.CreateArtist(artist);

            ps.DeleteArtist(artist.Id);
            transaction.Commit();

            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(0, artists.Count);
        }

        //Category
        [TestMethod]
        public void CheckGetAllCategoriesMethodResult()
        {
            CreateArtistCategoryAlbum();
            CreateArtistCategoryAlbum();

            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(2, categories.Count);
        }

        [TestMethod]
        public void CheckCreateCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();
            var transaction = _session.BeginTransaction();
            ps.CreateCategory(category);
            transaction.Commit();

            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(1, categories.Count);
        }

        [TestMethod]
        public void CheckDeleteCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();
            var transaction = _session.BeginTransaction();
            ps.CreateCategory(category);

            ps.DeleteCategory(category.Id);
            transaction.Commit();

            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(0, categories.Count);
        }
    }
}
