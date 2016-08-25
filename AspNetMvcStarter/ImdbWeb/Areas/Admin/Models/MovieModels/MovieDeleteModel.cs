using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieDeleteModel
	{
		[Display(Name = "EAN kode")]
		public string Id { get; set; }

		[Display(Name = "Tittel")]
		public string OriginalTitle { get; internal set; }

		[Display(Name = "Tittel")]
		public string ProductionYear { get; internal set; }

		[Display(Name = "Tittel")]
		public string Title { get; internal set; }
	}
}