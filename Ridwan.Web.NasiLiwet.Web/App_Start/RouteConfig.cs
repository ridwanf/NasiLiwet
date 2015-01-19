using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;

namespace Ridwan.Web.NasiLiwet.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Index" }

            );

          //  routes.MapRoute(
          //    name: "Product",
          //    url: "Home/Contact",
          //    defaults: new { controller = "Home", action = "Contact" }

          //);

          //  routes.MapRoute(
          //     name: "DefaultApiMvc",
          //     url: "{controller}/{action}",
          //     defaults: new { controller = "Home", action = "Index" }

          // );

            routes.MapRoute(
        name: "Default",
        url: "{*url}",
        defaults: new { controller = "Home", action = "Index" });


            //routes.MapRoute(
            //  name: "Default2",
            //  url: "app/{*.}",
            //  defaults: new { controller = "Home", action = "Index" }
            // );
        }
    }
}
