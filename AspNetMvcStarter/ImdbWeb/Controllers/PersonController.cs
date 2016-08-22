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
			ViewData.Model = from p in _db.Persons
							 where p.ActedMovies.Any()
							 select p;

			return View("Index");
		}
		public ViewResult Producers()
		{
			ViewData.Model = from p in _db.Persons
							 where p.ProducedMovies.Any()
							 select p;

			return View("Index");
		}
		public ViewResult Directors()
		{
			ViewData.Model = from p in _db.Persons
							 where p.DirectedMovies.Any()
							 select p;

			return View("Index");
		}

		[Route("{id:int}")]
		public ViewResult Details(int id)
		{
			var person = _db.Persons.Find(id);

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