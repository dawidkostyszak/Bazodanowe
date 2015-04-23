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

        public void CreateArtisCategoryAlbum(int id)
        {
            Album album = ProductObjectMother.CreateAlbum(id);
            Artist artist = ProductObjectMother.CreateArtist(id);
            Category category = ProductObjectMother.CreateCategory(id);
            ps.CreateNewArtist(artist);
            ps.CreateNewCategory(category);
            ps.CreateNewAlbum(album);
        }

//        [TestCleanup]
//        public void CleanAfterTest()
//        {
//            foreach (var a in ps.GetAllAlbums())
//            {
//                ps.DeleteAlbum(a.Id);
//            }
//            foreach (var a in ps.GetAllArtists())
//            {
//                ps.DeleteArtist(a.Id);
//            }
//            foreach (var c in ps.GetAllCategory())
//            {
//                ps.DeleteCategory(c.Id);
//            }
//        }

        //Album
        [TestMethod]
        public void CheckGetAllAlbumMethodResult()
        {
            CreateArtisCategoryAlbum(1);
            CreateArtisCategoryAlbum(2);

            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(2, albums.Count);
        }

        [TestMethod]
        public void CheckAddAlbumMethodResult()
        {
            CreateArtisCategoryAlbum(1);
            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckDeleteAlbumMethodResult()
        {
            CreateArtisCategoryAlbum(1);

            ps.DeleteAlbum(1);
            List<Album> albums = ps.GetAllAlbums();

            Assert.AreEqual(0, albums.Count);
        }

        [TestMethod]
        public void CheckFindAlbumMethodResult()
        {
            CreateArtisCategoryAlbum(1);

            Album result = ps.GetAlbum(1);

            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void CheckGetAlbumsForCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory(1);
            CreateArtisCategoryAlbum(1);

            List<Album> rec = ps.GetAllAlbums();
            List<Album> albums = ps.GetAllAlbumsForCategory(category);

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckGetAlbumsForArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist(1);
            CreateArtisCategoryAlbum(1);

            List<Album> albums = ps.GetAllAlbumsForArtist(artist);

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void CheckGetAlbumsForTypeMethodResult()
        {
            CreateArtisCategoryAlbum(1);

            List<Album> albums = ps.GetAllAlbumsForType("CD");

            Assert.AreEqual(1, albums.Count);
        }

        //Artist
        [TestMethod]
        public void CheckGetAllArtistsMethodResult()
        {
            CreateArtisCategoryAlbum(1);
            CreateArtisCategoryAlbum(2);
            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(2, artists.Count);
        }

        [TestMethod]
        public void CheckGetArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist(1);
            ps.CreateNewArtist(artist);
            Artist result = ps.GetArtist(artist.Id);

            Assert.AreEqual(artist.Id, result.Id);
        }

        [TestMethod]
        public void CheckCreateArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist(1);

            ps.CreateNewArtist(artist);
            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(1, artists.Count);
        }

        [TestMethod]
        public void CheckDeleteArtistMethodResult()
        {
            Artist artist = ProductObjectMother.CreateArtist(1);
            ps.CreateNewArtist(artist);

            ps.DeleteArtist(artist.Id);
            List<Artist> artists = ps.GetAllArtists();

            Assert.AreEqual(0, artists.Count);
        }

        //Category
        [TestMethod]
        public void CheckGetAllCategoriesMethodResult()
        {
            CreateArtisCategoryAlbum(1);
            CreateArtisCategoryAlbum(2);
            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(2, categories.Count);
        }

        [TestMethod]
        public void CheckCreateCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory(1);

            ps.CreateNewCategory(category);
            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(1, categories.Count);
        }

        [TestMethod]
        public void CheckDeleteCategoryMethodResult()
        {
            Category category = ProductObjectMother.CreateCategory(1);
            ps.CreateNewCategory(category);

            ps.DeleteCategory(category.Id);
            List<Category> categories = ps.GetAllCategory();

            Assert.AreEqual(0, categories.Count);
        }
    }
}
