﻿using ImdbWeb.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieCreateModel
	{
		[Display(Name = "EAN kode")]
		[MaxLength(30)]
		[Required]
		[CustomValidation(typeof(MovieController), "CheckIdLocal")]
		[Remote("CheckIdRemote", "Movie", HttpMethod = "POST")]
		public string Id { get; set; }

		[Display(Name = "Tittel")]
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }

		[Display(Name = "Original Tittel")]
		[MaxLength(100)]
		public string OriginalTitle { get; set; }

		[Display(Name = "Beskrivelse")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Display(Name = "Produksjonsår")]
		[MaxLength(4)]
		public string ProductionYear { get; set; }

		[Range(0, int.MaxValue/60-1)]
		[Display(Name = "Timer")]
		public int RunningLengthHours { get; set; }

		[Range(0,59)]
		[Display(Name = "Minutter")]
		public int RunningLengthMinutes { get; set; }

		[Display(Name = "Sjanger")]
		public int GenreId { get; set; }
	}
}