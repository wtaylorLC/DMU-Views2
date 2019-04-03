using System;
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
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movie
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
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

            var ActorsList = from actor in db.Actors
                             select new
                             {
                                 actor.ActorId,
                                 actor.FullName,
                                 Checked = ((from anActor in db.Casts
                                             where (anActor.MovieId == id) & (anActor.ActorId == anActor.ActorId)
                                             select anActor).Count() > 0)

                             };
            var DirectorList = from director in db.Directors
                               select new
                               {
                                   director.DirectorId,
                                   director.FullName,
                                   Checked = ((from aDirector in db.Filmographies
                                               where (aDirector.MovieId == id) & (aDirector.DirectorId == aDirector.DirectorId)
                                               select aDirector).Count() > 0)

                               };


            var MyViewModel = new MoviesViewModel();

            MyViewModel.MovieId = id.Value;
            MyViewModel.MovieTitle = movie.MovieTitle;
            MyViewModel.Image = movie.Image;
            MyViewModel.Description = movie.Description;
            MyViewModel.Genre = movie.Genre;
            MyViewModel.Writer = movie.Writer;
            MyViewModel.DateReleased = Convert.ToString(movie.DateReleased);

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in ActorsList)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ActorId, Name = item.FullName, Checked = item.Checked });
            }

            foreach (var item in DirectorList)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.DirectorId, Name = item.FullName, Checked = item.Checked });
            }


            MyViewModel.Actors = MyCheckBoxList;
            MyViewModel.Directors = MyCheckBoxList;
            return View(MyViewModel);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieTitle,Image,Description,Genre,Writer,DateReleased")] Movie movie, HttpPostedFileBase file)
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

            var ActorsList = from actor in db.Actors
                          select new
                          {
                              actor.ActorId,
                              actor.FullName,
                              Checked = ((from anActor in db.Casts
                                          where (anActor.MovieId == id) & (anActor.ActorId == anActor.ActorId)
                                          select anActor).Count() > 0)

                          };
            var DirectorList = from director in db.Directors
                          select new
                          {
                              director.DirectorId,
                              director.FullName,
                              Checked = ((from aDirector in db.Filmographies
                                          where (aDirector.MovieId == id) & (aDirector.DirectorId == aDirector.DirectorId)
                                          select aDirector).Count() > 0)

                          };


            var MyViewModel = new MoviesViewModel();

            MyViewModel.MovieId = id.Value;
            MyViewModel.MovieTitle = movie.MovieTitle;
            MyViewModel.Image = movie.Image;
            MyViewModel.Description = movie.Description;
            MyViewModel.Genre = movie.Genre;
            MyViewModel.Writer = movie.Writer;
            MyViewModel.DateReleased = Convert.ToString(movie.DateReleased);

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in ActorsList)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ActorId, Name = item.FullName, Checked = item.Checked });
            }

            foreach (var item in DirectorList)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.DirectorId, Name = item.FullName, Checked = item.Checked });
            }


            MyViewModel.Actors = MyCheckBoxList;
            MyViewModel.Directors = MyCheckBoxList;
            return View(MyViewModel);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoviesViewModel movie, HttpPostedFileBase file)
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
                movie.Image = file != null ? pic : movie.Image;

                var MyMovie = db.Movies.Find(movie.MovieId);

                MyMovie.MovieTitle = movie.MovieTitle;
                MyMovie.Image = movie.Image;
                MyMovie.Description = movie.Description;
                MyMovie.Genre = movie.Genre;
                MyMovie.Writer = movie.Writer;
                MyMovie.DateReleased = Convert.ToDateTime(movie.DateReleased);

                foreach (var item in db.Casts)
                {
                    if (item.MovieId == movie.MovieId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in movie.Actors)
                {
                    if (item.Checked)
                    {
                        db.Casts.Add(new Cast() { MovieId = movie.MovieId, ActorId = item.Id });
                    }
                }


                foreach (var item in db.Filmographies)
                {
                    if (item.MovieId == movie.MovieId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in movie.Directors)
                {
                    if (item.Checked)
                    {
                        db.Filmographies.Add(new Filmography() { MovieId = movie.MovieId, DirectorId= item.Id });
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
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
    }
}
