using ImdbWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class MovieController : ImdbControllerBase
    {
		[OutputCache(CacheProfile = "Short")]
		public ViewResult Index()
		{
			var movies = Db.Movies;

			ViewData.Model = movies;
			return View();
		}


		public ActionResult Details(string id)
		{
			var movie = Db.Movies.Find(id);

			if(movie == null)
			{
				return HttpNotFound();
			}
			
			ViewData.Model = movie;
			return View();
		}

		[OutputCache(CacheProfile = "Long")]
		public ViewResult Genres()
		{
			var genres = Db.Genres;

			ViewData.Model = genres;
			return View();
		}

		[Route("Movie/Genre/{genrename}")]
		public ActionResult MoviesByGenre(string genrename)
		{
			var genre = Db.Genres.SingleOrDefault(g => g.Name == genrename);
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