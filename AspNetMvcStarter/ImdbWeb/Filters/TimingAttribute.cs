using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Filters
{
	public class TimingAttribute : FilterAttribute, IActionFilter
	{
		private Stopwatch _stopwatch;

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			_stopwatch = Stopwatch.StartNew();
		}
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var elapsed = _stopwatch.Elapsed;
			filterContext.HttpContext.Response.Headers.Add("X-Time-Taken", elapsed.ToString());
		}
	}
}