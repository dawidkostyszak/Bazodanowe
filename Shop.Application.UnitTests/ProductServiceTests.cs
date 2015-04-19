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
        public IProductService ps = new ProductService();

        //Album
        [TestMethod]
        public void CheckGetAllAlbumMethodResult()
        {
            IList<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(3, albums.Count);
        }

        [TestMethod]
        public void CheckAddAlbumMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            ps.CreateNewAlbum(album);
            IList<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(4, albums.Count);
        }

        [TestMethod]
        public void CheckDeleteAlbumMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            ps.CreateNewAlbum(album);
            IList<Album> cos = ps.GetAllAlbums();
            ps.DeleteAlbum(album.Id);
            IList<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(3, albums.Count);
        }

        [TestMethod]
        public void CheckFindAlbumMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            ps.CreateNewAlbum(album);
            Album result = ps.GetAlbum(album.Id);

            Assert.AreEqual(album.Id, result.Id);
        }

        [TestMethod]
        public void CheckGetAlbumsForCategoryMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            ps.CreateNewAlbum(album);
            Category category = ProductObjectMother.CreateCategory();
            IList<Album> albums = ps.GetAllAlbumsForCategory(category);

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckGetAlbumsForArtistMethodResult()
        {
            Album album = ProductObjectMother.CreateAlbum();
            ps.CreateNewAlbum(album);
            Artist artist = ProductObjectMother.CreateArtist();
            IList<Album> albums = ps.GetAllAlbumsForArtist(artist);

            Assert.AreEqual(1, albums.Count);
        }

        //Artist
        [TestMethod]
        public void CheckGetAllArtistsMethodResult()
        {
            IList<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(3, artists.Count);
        }

        [TestMethod]
        public void CheckCreateArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            ps.CreateNewArtist(artist);
            IList<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(4, artists.Count);
        }

        [TestMethod]
        public void CheckDeleteArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist();
            ps.DeleteArtist(artist.Id);
            IList<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(3, artists.Count);
        }

        //Category
        [TestMethod]
        public void CheckGetAllCategoriesMethodResult()
        {
            IList<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(3, categories.Count);
        }

        [TestMethod]
        public void CheckCreateCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();
            ps.CreateNewCategory(category);
            IList<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(4, categories.Count);
        }

        [TestMethod]
        public void CheckDeleteCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory();
            ps.DeleteCategory(category.Id);
            IList<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(3, categories.Count);
        }
    }
}
