using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public abstract class ImdbControllerBase : Controller
    {
		protected ImdbContext Db = new ImdbContext();
		
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Db != null)
				{
					Db.Dispose();
				}
			}

			base.Dispose(disposing);
		}
	}
}