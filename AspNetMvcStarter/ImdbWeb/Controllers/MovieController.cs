using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class MovieController : Controller
    {
		// GET: Movie
		public ViewResult Index()
		{
			var db = new MovieDAL.ImdbContext();

			var movies = db.Movies;

			ViewData.Model = movies;
			return View();
		}

		public ViewResult Details(string id)
		{
			var db = new MovieDAL.ImdbContext();

			var movie = db.Movies.Find(id);

			ViewData.Model = movie;
			return View();
		}

		public ViewResult Genres()
		{
			var db = new MovieDAL.ImdbContext();

			var genres = db.Genres;

			ViewData.Model = genres;
			return View();
		}

		[Route("Movie/Genre/{genrename}")]
		public ViewResult MoviesByGenre(string genrename)
		{
			var db = new MovieDAL.ImdbContext();

			var movie = db.Movies.Where(m => m.Genre.Name == genrename);

			ViewData.Model = movie;
			return View("Index");
		}
	}
}