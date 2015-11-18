
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FooBar.Framework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "svcDefault",
                url: "services/{action}/{id}/{version}",
                defaults: new { controller = "Services", action = "Index", id = UrlParameter.Optional, version = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "hubsDefault",
                url: "hubs/{action}/{id}/{version}",
                defaults: new { controller = "Hubs", action = "Index", id = UrlParameter.Optional, version = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "vwDefault",
                url: "views/{action}/{id}/{version}",
                defaults: new { controller = "Views", action = "Index", id = UrlParameter.Optional, version = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "default",
                url: "{viewName}/{version}",
                defaults: new { controller = "Views", action = "ServeView" }
            );
        }
    }
}
