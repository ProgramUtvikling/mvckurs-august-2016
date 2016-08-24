using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ImdbWeb.Controllers
{
	public class ImdbApiController : ImdbControllerBase
	{
		public ActionResult Movies(string fmt = "xml")
		{
			switch (fmt.ToLower())
			{
				case "xml": return MoviesAsXml();
				case "json": return MoviesAsJson();
				default: return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
		}
		private ActionResult MoviesAsXml()
		{ 
			var doc = new XElement("movies",
								from movie in Db.Movies.ToList()
								select new XElement("movie",
									new XAttribute("title", movie.Title),
									new XAttribute("id", movie.MovieId)
								)
				);

			return Content(doc.ToString(), "application/xml");
		}

		private ActionResult MoviesAsJson()
		{
			var doc = from movie in Db.Movies.ToList()
					  select new { movie.Title, movie.MovieId };

			return Json(doc,JsonRequestBehavior.AllowGet);
		}

		[Route("Movie/Details/{id}.xml")]
		public ActionResult Movie(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			var doc = new XElement("movie",
								new XAttribute("title", movie.Title),
								new XAttribute("id", movie.MovieId),
								new XAttribute("genre", movie.Genre.Name),
								new XAttribute("prodYear", movie.ProductionYear),
								new XAttribute("runLen", movie.RunningLength),
								from p in movie.Actors select new XElement("actor", p.Name),
								from p in movie.Producers select new XElement("prducer", p.Name),
								from p in movie.Directors select new XElement("director", p.Name),
								new XCData(movie.Description)
				);

			return Content(doc.ToString(), "application/xml");
		}
	}
}