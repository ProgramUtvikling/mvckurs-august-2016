﻿using ImdbWeb.Model.PersonModels;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class PersonController : ImdbControllerBase
	{
		public ViewResult Actors()
		{
			var movies = from p in Db.Persons
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
			var movies = from p in Db.Persons
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
			var movies = from p in Db.Persons
						 where p.DirectedMovies.Any()
						 select p;
			ViewData.Model = new PersonIndexModel
			{
				Movies = movies,
				Title = "Regisører"
			};
			return View("Index");
		}

		[Route("Person/{id:int}")]
		public ActionResult Details(int id)
		{
			var person = Db.Persons.Find(id);
			if(person == null)
			{
				return HttpNotFound();
			}

			ViewData.Model = person;
			return View();
		}
	}
}