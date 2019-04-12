using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMUViews.Models;
using DMUViews.ViewModel;

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


        //public PartialViewResult GenreListPartial(int? page, int? genre)
        //{
        //    var movie = new Movie();
        //    movie.Genres = new List<Genre>();
        //    movie.Actors = new List<Actor>();
        //    movie.Directors = new List<Director>();
        //    //PopulateAssignedGenreData(movie);
        //    //PopulateAssignedActorData(movie);
        //    //PopulateAssignedDirectorData(movie);

        //    var pageNumber = page ?? 1;
        //    var pageSize = 10;
        //    if (genre != null)
        //    {
        //        var movieList = db.Movies
        //                        .OrderByDescending(m => m.MovieId)
        //                        .Where(m => m.Genres == Genre)
        //                        .ToPagedList(pageNumber, pageSize);
        //        return PartialView(movieList);
        //    }
        //    else
        //    {
        //        var movieList = db.Movies.OrderByDescending(m => m.MovieId).ToPagedList(pageNumber, pageSize);
        //        return PartialView(movieList);
        //    }
        //}

        // GET: Movie/Details/5
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

        // GET: Movie/Create
        public ActionResult Create()
        {
            var movie = new Movie();
            movie.Genres = new List<Genre>();
            movie.Actors = new List<Actor>();
            movie.Directors = new List<Director>();
            PopulateAssignedGenreData(movie);
            PopulateAssignedActorData(movie);
            PopulateAssignedDirectorData(movie);
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieTitle,Image,Description,DateReleased")] Movie movie, HttpPostedFileBase file, string[] selectedGenres, string[] selectedActors, string[] selectedDirectors)
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

            if (selectedGenres != null)
            {
                movie.Genres = new List<Genre>();
                foreach (var genre in selectedGenres)
                {
                    var genreToAdd = db.Genres.Find(int.Parse(genre));
                    movie.Genres.Add(genreToAdd);
                }
            }

            if (selectedActors != null)
            {
                movie.Actors = new List<Actor>();
                foreach (var actor in selectedActors)
                {
                    var actorToAdd = db.Actors.Find(int.Parse(actor));
                    movie.Actors.Add(actorToAdd);
                }
            }

            if (selectedDirectors != null)
            {
                movie.Directors = new List<Director>();
                foreach (var director in selectedDirectors)
                {
                    var directorToAdd = db.Directors.Find(int.Parse(director));
                    movie.Directors.Add(directorToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                movie.Image = pic;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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

            PopulateAssignedGenreData(movie);
            PopulateAssignedActorData(movie);
            PopulateAssignedDirectorData(movie);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = db.Movies.Find(id);
            Movie movie = db.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .Where(i => i.MovieId == id)
                .Single();

            if (movie == null)
            {
                return HttpNotFound();
            }
            PopulateAssignedGenreData(movie);
            PopulateAssignedActorData(movie);
            PopulateAssignedDirectorData(movie);
            return View(movie);
        }

   
        private void PopulateAssignedGenreData(Movie movie)
        {
            var allGenres = db.Genres;
            var movGenres = new HashSet<int>(movie.Genres.Select(g => g.GenreId));
            var viewModelAvailable = new List<MovieViewModel>();
            var viewModelSelected = new List<MovieViewModel>();
            foreach (var genre in allGenres)
            {
                if (movGenres.Contains(genre.GenreId))
                {
                    viewModelSelected.Add(new MovieViewModel
                    {
                        GenreID = genre.GenreId,
                        genreName = genre.GenreName,
                    });
                }
                else
                {
                    viewModelAvailable.Add(new MovieViewModel
                    {
                        GenreID = genre.GenreId,
                        genreName = genre.GenreName,
                        //Assigned = false
                    });
                }

            }
            ViewBag.selGenres = new MultiSelectList(viewModelSelected, "GenreID", "genreName");
            ViewBag.availGenres = new MultiSelectList(viewModelAvailable, "GenreID", "genreName");
        }
        private void PopulateAssignedActorData(Movie movie)
        {
            var allActors = db.Actors;
            var movActors = new HashSet<int>(movie.Actors.Select(a => a.ActorId));
            var viewModelAvailable = new List<MovieViewModel>();
            var viewModelSelected = new List<MovieViewModel>();
            foreach (var actor in allActors)
            {
                if (movActors.Contains(actor.ActorId))
                {
                    viewModelSelected.Add(new MovieViewModel
                    {
                        ActorID = actor.ActorId,
                        actorName = actor.ActorName,
                    });

                }
                else
                {
                    viewModelAvailable.Add(new MovieViewModel
                    {
                        ActorID = actor.ActorId,
                        actorName = actor.ActorName,
                        //Assigned = false
                    });
                }
                ViewBag.selActors = new MultiSelectList(viewModelSelected, "ActorID", "actorName");
                ViewBag.availActors = new MultiSelectList(viewModelAvailable, "ActorID", "actorName");

            }
        }

        private void PopulateAssignedDirectorData(Movie movie)
        {
            var allDirectors = db.Directors;
            var movDirectors = new HashSet<int>(movie.Directors.Select(d => d.DirectorId));
            var viewModelAvailable = new List<MovieViewModel>();
            var viewModelSelected = new List<MovieViewModel>();
            foreach (var director in allDirectors)
            {
                if (movDirectors.Contains(director.DirectorId))
                {
                    viewModelSelected.Add(new MovieViewModel
                    {
                        DirectorID = director.DirectorId,
                        directorName = director.DirectorName,

                    });
                }
                else
                {
                    viewModelAvailable.Add(new MovieViewModel
                    {
                        DirectorID = director.DirectorId,
                        directorName = director.DirectorName,
                        //Assigned = false
                    });
                }
                ViewBag.selDirectors = new MultiSelectList(viewModelSelected, "DirectorID", "directorName");
                ViewBag.availDirectors = new MultiSelectList(viewModelAvailable, "DirectorID", "directorName");

            }
        }


        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieTitle,Image,Description,DateReleased")] Movie movie, HttpPostedFileBase file, string[] selectedGenres, string[] selectedActors, string[] selectedDirectors,  int? id)
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

            if (ModelState.IsValid)
            {
                movie.Image = file != null ? pic : movie.Image;

                var MyMovie = db.Movies.Find(movie.MovieId);

                MyMovie.MovieTitle = movie.MovieTitle;
                if (movie.Image != null)
                {
                    MyMovie.Image = movie.Image;
                }
                MyMovie.Description = movie.Description;

                MyMovie.DateReleased = Convert.ToDateTime(movie.DateReleased);
                MyMovie.Genres = movie.Genres;
                MyMovie.Actors = movie.Actors;
                MyMovie.Directors = movie.Directors;

                UpdateMovieGenres(selectedGenres, MyMovie);
                UpdateMovieActors(selectedActors, MyMovie);
                UpdateMovieDirectors(selectedDirectors, MyMovie);

                db.Movies.Add(movie);
                db.SaveChanges();

                //Display Image
                //int id = 0;
                Movie image = new Movie();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    image = db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
                    if (image != null)
                    {
                        movie.MovieTitle = image.Image;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(movie);


            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //var movieToUpdate = db.Movies
            //    .Include(m => m.Genres)
            //    .Include(m => m.Actors)
            //    .Include(m => m.Directors)
            //    .Where(i => i.MovieId == id)
            //    .Single();

            //if (TryUpdateModel(movieToUpdate, "",
            //       new string[] { "MovieId", "MovieTitle","Image", "Description", "DateReleased" }))
            //{
            //    //if (file == null)
            //    //{
            //    //    Movie thisMovie = db.Movies.Where(m => m.MovieId == movie.MovieId).FirstOrDefault();
            //    //    movie.Image = thisMovie.Image;
            //    //}

            //    try
            //    {
            //        UpdateMovieGenres(selectedGenres, movieToUpdate);
            //        UpdateMovieActors(selectedActors, movieToUpdate);
            //        UpdateMovieDirectors(selectedDirectors, movieToUpdate);

            //        db.Entry(movieToUpdate).State = EntityState.Modified;
            //        db.SaveChanges();

            //        return RedirectToAction("Index");

            //    }
            //    catch (RetryLimitExceededException /* dex */)
            //    {
            //        //Log the error (uncomment dex variable name and add a line here to write a log.
            //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            //    }
            //}

            //PopulateAssignedGenreData(movieToUpdate);
            //PopulateAssignedActorData(movieToUpdate);
            //PopulateAssignedDirectorData(movieToUpdate);
            //return View(movieToUpdate);


            //movieToUpdate.MovieTitle = movie.MovieTitle;
            //if (movie.Image != null)
            //{
            //    movieToUpdate.Image = movie.Image;
            //}
            //movieToUpdate.Description = movie.Description;
            //movieToUpdate.DateReleased = Convert.ToDateTime(movie.DateReleased);


            ////Display Image
            //Movie image = new Movie();
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
            //    image = db.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            //    if (image != null)
            //    {
            //        movie.MovieTitle = image.Image;
            //    }
            //}
        }

        private void UpdateMovieDirectors(string[] selectedDirectors, Movie movieToUpdate)
        {
            if (selectedDirectors == null)
            {
                movieToUpdate.Directors = new List<Director>();
                return;
            }

            var selectedDirectorsHS = new HashSet<string>(selectedDirectors);
            var movieDirectors = new HashSet<int>
                (movieToUpdate.Directors.Select(m => m.DirectorId));
            foreach (var director in db.Directors)
            {
                if (selectedDirectorsHS.Contains(director.DirectorId.ToString()))
                {
                    if (!movieDirectors.Contains(director.DirectorId))
                    {
                        movieToUpdate.Directors.Add(director);
                    }
                }
                else
                {
                    if (movieDirectors.Contains(director.DirectorId))
                    {
                        movieToUpdate.Directors.Remove(director);
                    }
                }
            }
        }

        private void UpdateMovieActors(string[] selectedActors, Movie movieToUpdate)
        {
            if (selectedActors == null)
            {
                movieToUpdate.Actors = new List<Actor>();
                return;
            }

            var selectedActorsHS = new HashSet<string>(selectedActors);
            var movieActors = new HashSet<int>
                (movieToUpdate.Actors.Select(m => m.ActorId));
            foreach (var actor in db.Actors)
            {
                if (selectedActorsHS.Contains(actor.ActorId.ToString()))
                {
                    if (!movieActors.Contains(actor.ActorId))
                    {
                        movieToUpdate.Actors.Add(actor);
                    }
                }
                else
                {
                    if (movieActors.Contains(actor.ActorId))
                    {
                        movieToUpdate.Actors.Remove(actor);
                    }
                }
            }
        }

        private void UpdateMovieGenres(string[] selectedGenres, Movie movieToUpdate)
        {
            if (selectedGenres == null)
            {
                movieToUpdate.Genres = new List<Genre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var movieGenres = new HashSet<int>
                (movieToUpdate.Genres.Select(m => m.GenreId));
            foreach (var genre in db.Genres)
            {
                if (selectedGenresHS.Contains(genre.GenreId.ToString()))
                {
                    if (!movieGenres.Contains(genre.GenreId))
                    {
                        movieToUpdate.Genres.Add(genre);
                    }
                }
                else
                {
                    if (movieGenres.Contains(genre.GenreId))
                    {
                        movieToUpdate.Genres.Remove(genre);
                    }
                }
            }
        }



        // GET: Movie/Delete/5
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

        // POST: Movie/Delete/5
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
