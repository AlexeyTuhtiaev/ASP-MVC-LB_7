using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _50331_TUHTIAEV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "menu",
                defaults: new { controller = "AutoPart", action = "list", page = 1, category = (string)null });

            routes.MapRoute(
                name: "",
                url: "menu/page{page}",
                defaults: new { controller = "AutoPart", action = "list", category = (string)null }, constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "",
                url: "AutoPartMenu/{category}",
                defaults: new { controller = "AutoPart", action = "list", page = 1 });

            routes.MapRoute(
                name: "",
                url: "menu/{category}/page{page}",
                defaults: new { controller = "AutoPart", action = "list" }, constraints: new { page = @"\d+" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
