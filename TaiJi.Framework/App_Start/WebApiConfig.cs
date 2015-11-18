
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace TaiJi.Framework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{version}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute("DefaultApiWithId",
                                       "api/{controller}/{version}/{id}",
                                       new { id = RouteParameter.Optional },
                                       new { id = @"\d+" });

            config.Routes.MapHttpRoute("DefaultApiWithAction",
                                       "api/{controller}/{version}/{action}");

            config.Routes.MapHttpRoute("DefaultApiGet",
                                       "api/{controller}/{version}",
                                       new { action = "Get" },
                                       new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });

            config.Routes.MapHttpRoute("DefaultApiPost",
                                       "api/{controller}/{version}",
                                       new { action = "Post" },
                                       new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
        }
    }
}
