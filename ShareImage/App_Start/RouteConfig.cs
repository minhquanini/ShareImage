using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace ShareImage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Homeuser", action = "Index", id = UrlParameter.Optional }
                
            );

            routes.MapRoute(
               name: "Register",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Login",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "UpPost",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Post", action = "UpPost", id = UrlParameter.Optional }
          );

        }
    }
}
