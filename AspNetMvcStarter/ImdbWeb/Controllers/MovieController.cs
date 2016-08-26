using ImdbWeb.Filters;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using MovieDAL;
using ImdbWeb.Model.MovieModels;

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

			if (movie == null)
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
			if (genre == null)
			{
				return HttpNotFound();
			}

			var movies = genre.Movies;

			ViewData.Model = movies;
			//ViewData["Tittel"] = genrename;
			ViewBag.Tittel = genre.Name;
			return View("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Vote(string id, int vote)
		{
			if (vote < 0 || vote > 5)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var movie = await Db.Movies.FindAsync(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			movie.Ratings.Add(new Rating { Vote = vote });
			await Db.SaveChangesAsync();

			ViewData.Model = new VoteResultModel
			{
				MovieId = movie.MovieId,
				YourVote = vote,
				VoteCount = movie.Ratings.Count(),
				AverageVote = movie.Ratings.Average(r => r.Vote)
			};

			if (Request.IsAjaxRequest())
			{
				return PartialView("_VoteResult");
			}

			return View("VoteResult");

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Comment(string id, string author, string headline)
		{
			var movie = await Db.Movies.FindAsync(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			var comment = new Comment { Author = author, Headline = headline };
			movie.Comments.Add(comment);
			await Db.SaveChangesAsync();

			ViewData.Model = comment;

			if (Request.IsAjaxRequest())
			{
				return PartialView("_Comment");
			}

			return RedirectToAction("Details", "Movie", new { id });
		}
	}
}