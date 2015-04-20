using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Domain.Model.Album;
using Shop.Domain.Model.Album.Repositories;
using Shop.Domain.Model.Artist;
using Shop.Domain.Model.Artist.Repositories;
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
            ps.CreateNewAlbum(album.Object);

            albumMock.Verify(k => k.Insert(album.Object), Times.Once());
        }
    }

    [TestClass]
    public class ProductServiceReturnTests
    {
        [TestCleanup]
        public void CleanAfterTest()
        {
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
        }

        public IProductService ps = new ProductService();

        public void CreateArtisCategoryAlbum()
        {
            Album album = ProductObjectMother.CreateAlbum();
            Artist artist = ProductObjectMother.CreateArtist();
            Category category = ProductObjectMother.CreateCategory();
            ps.CreateNewArtist(artist);
            ps.CreateNewCategory(category);
            ps.CreateNewAlbum(album);
        }

        //Album
        [TestMethod]
        public void CheckGetAllAlbumMethodResult()
        {
            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(3, albums.Count);
        }

        [TestMethod]
        public void CheckAddAlbumMethodResult()
        {
            CreateArtisCategoryAlbum();
            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(4, albums.Count);
        }

        [TestMethod]
        public void CheckDeleteAlbumMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            CreateArtisCategoryAlbum();

            ps.DeleteAlbum(album.Id);
            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(3, albums.Count);
        }

        [TestMethod]
        public void CheckFindAlbumMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            CreateArtisCategoryAlbum();

            Album result = ps.GetAlbum(album.Id);

            Assert.AreEqual(album.Id, result.Id);
        }

        [TestMethod]
        public void CheckGetAlbumsForCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();
            CreateArtisCategoryAlbum();

            List<Album> albums = ps.GetAllAlbumsForCategory(category);

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckGetAlbumsForArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            CreateArtisCategoryAlbum();

            List<Album> albums = ps.GetAllAlbumsForArtist(artist);

            Assert.AreEqual(1, albums.Count);
        }

        //Artist
        [TestMethod]
        public void CheckGetAllArtistsMethodResult()
        {
            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(3, artists.Count);
        }

        [TestMethod]
        public void CheckCreateArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();

            ps.CreateNewArtist(artist);
            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(4, artists.Count);
        }

        [TestMethod]
        public void CheckDeleteArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            ps.CreateNewArtist(artist);

            ps.DeleteArtist(artist.Id);
            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(3, artists.Count);
        }

        //Category
        [TestMethod]
        public void CheckGetAllCategoriesMethodResult()
        {
            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(3, categories.Count);
        }

        [TestMethod]
        public void CheckCreateCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();

            ps.CreateNewCategory(category);
            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(4, categories.Count);
        }

        [TestMethod]
        public void CheckDeleteCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();
            ps.CreateNewCategory(category);

            ps.DeleteCategory(category.Id);
            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(3, categories.Count);
        }
    }
}
