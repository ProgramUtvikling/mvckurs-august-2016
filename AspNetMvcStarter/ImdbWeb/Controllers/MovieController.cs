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

			// hente alle filmer
			var movies = db.Movies;

			// legg dem i ViewData.Model
			ViewData.Model = movies;

			return View();
		}

		[Route("movie-{id}")]
		public ViewResult Details(string id)
		{
			var db = new MovieDAL.ImdbContext();

			// hente film fra db
			var movie = db.Movies.Find(id);

			// legg den i ViewData.Model
			ViewData.Model = movie;

			return View();
		}

		public string Genres()
		{
			return "MovieController.Genres()";
		}

		[Route("Movie/Genre/{genrename}")]
		public string MoviesByGenre(string genrename)
		{
			return $"MovieController.MoviesByGenre({genrename})";
		}
	}
}