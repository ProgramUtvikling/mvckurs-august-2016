using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using ImdbWeb.Filters;

namespace ImdbWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());
			
			GlobalFilters.Filters.Add(new HandleErrorAttribute());
			GlobalFilters.Filters.Add(new TimingAttribute());
			//GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());



			// Code that runs on application startup
			AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);        
        }
    }
}