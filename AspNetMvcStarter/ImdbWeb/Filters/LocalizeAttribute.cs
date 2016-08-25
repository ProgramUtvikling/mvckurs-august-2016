using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Filters
{
	public class LocalizeAttribute : FilterAttribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			// Nada, nothing, niks
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			// kode for å sette riktig språk, slik:
			Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nb-no");
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("nb-no");
		}
	}
}