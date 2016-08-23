using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult CreateImage(string fmt, string id)
        {
			var path = Server.MapPath($"~/App_Data/covers/{id}.jpg");
			if (!System.IO.File.Exists(path))
			{
				return HttpNotFound();
			}

			var img = new WebImage(path);

			switch (fmt.ToLower())
			{
				case "thumb":
					img.Resize(100, 1000).Write();
					break;

				case "medium":
					img
						.Resize(300, 3000)
						.AddTextWatermark("Ingars Movie Database", "Black", padding: 5)
						.AddTextWatermark("Ingars Movie Database", "White", padding: 7)
						.Write();
					break;

				default:
					return HttpNotFound();
			}

			return new EmptyResult();
        }
    }
}