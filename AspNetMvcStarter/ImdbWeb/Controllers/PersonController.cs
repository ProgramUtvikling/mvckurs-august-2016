using ImdbWeb.Model.PersonModels;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Person")]
	public class PersonController : Controller
	{
		private ImdbContext _db = new ImdbContext();

		public ViewResult Actors()
		{
			var movies = from p in _db.Persons
						 where p.ActedMovies.Any()
						 select p;
			ViewData.Model = new PersonIndexModel
			{
				Movies = movies,
				Title = "Skuespillere"
			};
			return View("Index");
		}
		public ViewResult Producers()
		{
			var movies = from p in _db.Persons
						 where p.ProducedMovies.Any()
						 select p;
			ViewData.Model = new PersonIndexModel
			{
				Movies = movies,
				Title = "Produsenter"
			};
			return View("Index");
		}
		public ViewResult Directors()
		{
			var movies = from p in _db.Persons
						 where p.DirectedMovies.Any()
						 select p;
			ViewData.Model = new PersonIndexModel
			{
				Movies = movies,
				Title = "Regisører"
			};
			return View("Index");
		}

		[Route("{id:int}")]
		public ActionResult Details(int id)
		{
			var person = _db.Persons.Find(id);
			if(person == null)
			{
				return HttpNotFound();
			}

			ViewData.Model = person;
			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_db != null)
				{
					_db.Dispose();
				}
			}

			base.Dispose(disposing);
		}
	}
}