using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //Disposing _context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
            
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    //Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            //If movie.Id == 0 add to db else find in db and update properties
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        //Route Attribute URL Template initalized in RouteConfig.cs
        //        [Route("movies/released/{year:max(2017)}/{month:regex(\\d{2}):range(1,12)}")]
        //        public ActionResult ByReleaseDate(int? year, int? month)
        //        {
        //            return Content(string.Format("Month={0}, Year={1}", month, year));
        //
        //        }




        public ActionResult Details(int id)
        {
            var selectedMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (selectedMovie == null)
            {
                return HttpNotFound();
            }
            return View(selectedMovie);
        }
    }
}