using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImdbWeb
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapMvcAttributeRoutes();
									
			//routes.MapRoute("Movies by genres",
			//	"Movie/Genre/{genrename}", new { Controller = "Movie", Action = "MoviesByGenre" });

			//routes.MapRoute("Person details",
			//	"Person/{id}", new { Controller = "Person", Action = "Details" }, new { id = @"\d+"});

			routes.MapRoute("Movie Covers",
				"Image/{fmt}/{id}.jpg", new { Controller = "Image", Action = "CreateImage" });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

		}
	}
}
