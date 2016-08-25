using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImdbWeb.Areas.Admin.Models.MovieModels;
using ImdbWeb.Controllers;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImdbWeb.Areas.Admin.Controllers
{
	public class MovieController : ImdbControllerBase
	{
		// GET: Admin/Movie
		public async Task<ActionResult> Index()
		{
			var db = new MovieDAL.ImdbContext();

			ViewData.Model = await db.Movies
				.OrderBy(m => m.Title)
				.ThenBy(m => m.RunningLength)
				.Select(m => new MovieIndexModel { Id = m.MovieId, Title = m.Title, RunningLength = m.RunningLength })
				.ToListAsync();
			return View();
		}

		public async Task<ActionResult> Create()
		{
			ViewBag.Genres = new SelectList(await Db.Genres.ToListAsync(), "GenreId", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(MovieCreateModel model)
		{
			if (ModelState.IsValid)
			{
				var newMovie = new MovieDAL.Movie
				{
					MovieId = model.Id,
					Title = model.Title,
					OriginalTitle = model.OriginalTitle,
					Description = model.Description,
					ProductionYear = model.ProductionYear,
					RunningLength = model.RunningLengthHours * 60 + model.RunningLengthMinutes,
					Genre = await Db.Genres.FindAsync(model.GenreId)
				};
				Db.Movies.Add(newMovie);
				await Db.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return await Create();
		}

		public ActionResult CheckIdRemote(string id)
		{
			if (Db.Movies.Any(m => m.MovieId == id))
			{
				return Json("Filmen er allerede registrert (Remote)");
			}
			return Json(true);
		}

		public static ValidationResult CheckIdLocal(string id)
		{
			using (var db = new MovieDAL.ImdbContext())
			{
				if (db.Movies.Any(m => m.MovieId == id))
				{
					return new ValidationResult("Filmen er allerede registrert (Local)");
				}
				return ValidationResult.Success;
			}
		}

		public async Task<ActionResult> Delete(string id)
		{
			var movie = await Db.Movies.FindAsync(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			ViewData.Model = new MovieDeleteModel
			{
				Id = movie.MovieId,
				Title = movie.Title,
				OriginalTitle = movie.OriginalTitle,
				ProductionYear = movie.ProductionYear
			};
			return View();
		}

		[HttpDelete]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public async Task<ActionResult> DeleteConfirmed(string id)
		{
			var movie = await Db.Movies.FindAsync(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			Db.Movies.Remove(movie);
			await Db.SaveChangesAsync();

			return RedirectToAction("Index");

		}
	}
}