using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hand2hand
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // page 1 of all products
            routes.MapRoute(
                null,
                "",
                new { controller = "Products", action = "Index", page = 1, category = (string)null }
                );

            //outputs specific page of all products
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Products", action = "Index", category = (string)null }, 
                constraints: new { page = @"\d+" }
                );

            //page 1 of specific product's category
            routes.MapRoute(
                null,
                "{category}",
                new { controller = "Products", action = "Index", page = 1 }
                );

            routes.MapRoute(
                null,
                "{controller}/{action}");
        }
    }
}
