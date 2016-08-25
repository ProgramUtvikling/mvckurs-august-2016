using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class DemoModel
	{
		public string Overskrift { get; set; }

		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string Artikkel { get; set; }
	}
}