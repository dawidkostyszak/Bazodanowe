using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using NHibernate;
using PagedList;
using Shop.Application;
using Shop.Domain.Model.Album;
using Shop.Infrastructure;

namespace WebApplication.Controllers
{
    public class AlbumsController : Controller
    {
        private static ISession session = NHibernateHelper.OpenSession();
        private static IProductService productService = new ProductService();

        // GET: Albums
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "category_asc" ? "category_desc" : "category_asc";
            ViewBag.ArtistSortParm = sortOrder == "artist_asc" ? "artist_desc" : "artist_asc";
            ViewBag.TypeSortParm = sortOrder == "type_asc" ? "type_desc" : "type_asc";
            var albums = productService.GetAllAlbums(sortOrder);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                albums = productService.GetAlbumsForName(searchString);
            }

            ViewBag.CurrentFilter = searchString;

            int pageNumber = (page ?? 1);
            const int pageSize = 10;
            return View(albums.ToPagedList(pageNumber, pageSize));
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            Album album = productService.GetAlbum(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            var artists = productService.GetAllArtists();
            var categories = productService.GetAllCategory();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.ArtistId = new SelectList(artists, "Id", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                var transaction = session.BeginTransaction();
                album.Artist = productService.GetArtist(album.ArtistId);
                album.Category = productService.GetCategory(album.CategoryId);
                productService.CreateAlbum(album);
                transaction.Commit();
                return RedirectToAction("Index");
            }

            var artists = productService.GetAllArtists();
            var categories = productService.GetAllCategory();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", album.CategoryId);
            ViewBag.ArtistId = new SelectList(artists, "Id", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = productService.GetAlbum(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            var artists = productService.GetAllArtists();
            var categories = productService.GetAllCategory();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", album.Category != null ? album.Category.Id : 0);
            ViewBag.ArtistId = new SelectList(artists, "Id", "Name", album.Artist != null ? album.Artist.Id : 0);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                var transaction = session.BeginTransaction();
                album.Artist = productService.GetArtist(album.ArtistId);
                album.Category = productService.GetCategory(album.CategoryId);
                productService.EditAlbum(album);
                transaction.Commit();
                return RedirectToAction("Index");
            }

            var artists = productService.GetAllArtists();
            var categories = productService.GetAllCategory();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", album.Category != null ? album.Category.Id : 0);
            ViewBag.ArtistId = new SelectList(artists, "Id", "Name", album.Artist != null ? album.Artist.Id : 0);
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = productService.GetAlbum(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var transaction = session.BeginTransaction();
            productService.DeleteAlbum(id);
            transaction.Commit();
            return RedirectToAction("Index");
        }
    }
}
