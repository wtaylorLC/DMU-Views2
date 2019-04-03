using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMUViews.Models;
using DMUViews.ViewModel;
using Microsoft.AspNet.Identity;

namespace DMUViews.Controllers
{
    public class MovieCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly UserManager<ApplicationUser> _userManager;
        // GET: MovieComments
        public ActionResult Index()
        {
            var movieComments = db.MovieComments.Include(m => m.Movie).Include(m => m.User);
            return View(movieComments.ToList());
        }

        // GET: MovieComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieComment movieComment = db.MovieComments.Find(id);
            if (movieComment == null)
            {
                return HttpNotFound();
            }

            return View(movieComment);
        }

        // GET: MovieComments/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieTitle");
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: MovieComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieCommentId,MovieId,UserId,Comment,Rating,CommentDate")] MovieComment movieComment)
        {
            if (ModelState.IsValid)
            {
                db.MovieComments.Add(movieComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieTitle", movieComment.MovieId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", movieComment.UserId);
            return View(movieComment);
        }

        // GET: MovieComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieComment movieComment = db.MovieComments.Find(id);
            if (movieComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieTitle", movieComment.MovieId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", movieComment.UserId);
            return View(movieComment);
        }

        // POST: MovieComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieCommentId,MovieId,UserId,Comment,Rating,CommentDate")] MovieComment movieComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieTitle", movieComment.MovieId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", movieComment.UserId);
            return View(movieComment);
        }

        // GET: MovieComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieComment movieComment = db.MovieComments.Find(id);
            if (movieComment == null)
            {
                return HttpNotFound();
            }
            return View(movieComment);
        }

        // POST: MovieComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieComment movieComment = db.MovieComments.Find(id);
            db.MovieComments.Remove(movieComment);
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

        //public List<MovieCommentsListViewModel> GetAllComments()
        //{

        //    List<MovieCommentsListViewModel> commentsList = new List<MovieCommentsListViewModel>();
        //    var movieComments = db.MovieComments.Include(m => m.Movie).Include(m => m.User);
        //    movieComments.ToList().ForEach(x => {
        //        MovieCommentsListViewModel productComments = new MovieCommentsListViewModel
        //        {
        //            Id = x.MovieCommentId,
        //            ModifiedDate = x.CommentDate,
        //            MovieId = x.MovieId,
        //            AddedDate = x.CommentDate,
        //            UserId = x.UserId,
        //            Comment = x.Comment,
        //        };
        //        ApplicationUser user = _userManager.FindByIdAsync(x.UserId).Result;
        //        movieComments.UserReacion = GetReactionOfComment(x.Comment);
        //    });
        //    return commentsList;

        //}

        //public string GetReactionOfComment(string comment)
        //{
        //    SentimentIntensityAnalyzer analyzer = new SentimentIntensityAnalyzer();

        //    var results = analyzer.PolarityScores(comment);
        //    string reaction = "";
        //    if (results.Positive > results.Compound && results.Positive >= results.Neutral && results.Positive > results.Negative)
        //    {
        //        reaction = "Positive " + results.Positive * 100 + "%";
        //    }



        //    else if (results.Negative > results.Compound && results.Negative > results.Neutral && results.Negative > results.Positive)
        //    {
        //        reaction = "Negative ";
        //    }
        //    else
        //    {
        //        reaction = "Neutral Reaction";
        //    }
        //    return reaction;
        //}
    }
}
