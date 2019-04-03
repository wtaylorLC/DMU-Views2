using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMUViews.Models;

namespace DMUViews.Controllers
{
    public class AdminControllerOld : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult Index(string search)
        {

            //IEnumerable<Movie> data = db.Database.SqlQuery<Movie>("GetBySearch", param).ToList();

            List<Genre> list = db.Genres.ToList();
            ViewBag.GenreList = new SelectList(list, "GenreId", "GenreName");
            return View(db.Movies.ToList());

        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //movie.Genres = db.Genres.ToList();
            }
            IEnumerable<Genre> list = db.Genres.ToList();
            ViewBag.GenreList = new SelectList(list, "GenreId", "GenreName");
            return View(movie);

        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieTitle,Image,IsPrefferedMovie,Description,DateReleased")] Movie movie, HttpPostedFileBase file)
        {
            string pic = null;
            //Movie newImage = movie;
            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/ImageVideoFiles/"), pic);

                //file is uploaded
                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                movie.Image = pic;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pic = file.FileName;
            ViewBag.Message = "Movie Uploaded Successfully";

            //Display Image
            int id = 0;
            Movie image = new Movie();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               image = db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
                if (image != null)
                {
                    movie.MovieTitle = image.Image;
                }
            }

            return View(movie);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieTitle,Image,IsPrefferedMovie,Description,DateReleased")] Movie movie, HttpPostedFileBase file)
        {
            string pic = null;
            //Movie newImage = movie;
            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/ImageVideoFiles/"), pic);

                //file is uploaded
                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                movie.Image = file != null? pic : movie.Image;
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Movie Uploaded Successfully";

            //Display Image
            int id = 0;
            Movie image = new Movie();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                image = db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
                if (image != null)
                {
                    movie.MovieTitle = image.Image;
                }
            }

            return View(movie);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult GetImage(int id)
        {
            //Display Image
            Movie movie = new Movie();
            Movie image = new Movie();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                image = db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
                if (image != null)
                {
                    movie.MovieTitle = image.Image;
                }
            }
            return View(movie);
        }
    }
}
