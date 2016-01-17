using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "recordsPost",
                url: "records",
                defaults: new { controller = "GuaranteedRate", action = "Records", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "recordsgenderSort",
                url: "records/gender",
                defaults: new { controller = "GuaranteedRate", action = "Gender", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "recordsDobSort",
                url: "records/birthdate",
                defaults: new { controller = "GuaranteedRate", action = "BirthDate", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "recordsLastNameSort",
                url: "records/name",
                defaults: new { controller = "GuaranteedRate", action = "Name", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
