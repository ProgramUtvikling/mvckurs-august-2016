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

		public ActionResult Details(string id)
		{
			var db = new MovieDAL.ImdbContext();

			var movie = db.Movies.Find(id);

			if(movie == null)
			{
				return HttpNotFound();
			}


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
		public ActionResult MoviesByGenre(string genrename)
		{
			var db = new MovieDAL.ImdbContext();
			var genre = db.Genres.SingleOrDefault(g => g.Name == genrename);
			if(genre == null)
			{
				return HttpNotFound();
			}

			var movies = genre.Movies;

			ViewData.Model = movies;
			//ViewData["Tittel"] = genrename;
			ViewBag.Tittel = genre.Name;
			return View("Index");
		}
	}
}