using System;
using System.Linq;
using System.Web.Mvc;
using NHibernate;
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
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var albums = productService.GetAllAlbums();

            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(s => s.Name.Contains(searchString)).ToList();
            }
//            switch (sortOrder)
//            {
//                case "name_desc":
//                    albums = albums.OrderByDescending(s => s.LastName);
//                    break;
//                case "Date":
//                    albums = albums.OrderBy(s => s.EnrollmentDate);
//                    break;
//                case "date_desc":
//                    albums = albums.OrderByDescending(s => s.EnrollmentDate);
//                    break;
//                default:
//                    albums = albums.OrderBy(s => s.LastName);
//                    break;
//            }
////            return View(students.ToList());
            return View(albums);
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
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,Name,Price,PublishDate,Type")] Album album)
        {
            if (ModelState.IsValid)
            {
                var transaction = session.BeginTransaction();
                productService.CreateAlbum(album);
                transaction.Commit();
                return RedirectToAction("Index");
            }

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
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Name,Price,PublishDate,Type")] Album album)
        {
            if (ModelState.IsValid)
            {
                var transaction = session.BeginTransaction();
                productService.EditAlbum(album);
                transaction.Commit();
                return RedirectToAction("Index");
            }
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
