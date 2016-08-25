using ImdbWeb.Filters;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class MovieController : ImdbControllerBase
    {
		[OutputCache(CacheProfile = "Short")]
		public async Task<ViewResult> Index()
		{
			var movies = Db.Movies;

			ViewData.Model = await movies.ToListAsync();
			return View();
		}


		public async Task<ActionResult> Details(string id)
		{
			//await Task.Delay(2000);

			var movie = await Db.Movies.FindAsync(id);

			if(movie == null)
			{
				return HttpNotFound();
			}
			
			ViewData.Model = movie;
			if (Request.IsAjaxRequest())
			{
				return PartialView();
			}

			return View();
		}

		[OutputCache(CacheProfile = "Long")]
		public async Task<ViewResult> Genres()
		{
			var genres = Db.Genres;

			ViewData.Model = await genres.ToListAsync();
			return View();
		}

		[Route("Movie/Genre/{genrename}")]
		public async Task<ActionResult> MoviesByGenre(string genrename)
		{
			var genre = await Db.Genres.SingleOrDefaultAsync(g => g.Name == genrename);
			if(genre == null)
			{
				return HttpNotFound();
			}

			//TODO: Hvordan hente async
			var movies = genre.Movies;

			ViewData.Model = movies;
			//ViewData["Tittel"] = genrename;
			ViewBag.Tittel = genre.Name;
			return View("Index");
		}
	}
}