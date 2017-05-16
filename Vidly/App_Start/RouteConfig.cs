using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Controllers;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Attribute Routing
            routes.MapMvcAttributeRoutes();

            //Below is a fragile map route as the action is hardcoded i.e. magic numbers
//            routes.MapRoute(
//                "MoviesByReleaseDate",
//                "movies/released/{year}/{month}",
//                new {controller = "Movies", action="ByReleaseDate"},
//                new {year = @"\d{4}", month = @"\d{2}"}
//                );

            routes.MapRoute(
                name: "Default",
                //Value of id is always id therefore cannot be an movieID as an example
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
