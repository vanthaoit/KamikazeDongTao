using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KamikazeChicken.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Contact Detail",
                url: "lien-he.html",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeChicken.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Product Category",
                url:"{alias}.pc-{productCategoryId}.html",
                defaults: new {controller = "Product", action="Category", productCategoryId = UrlParameter.Optional},
                namespaces: new string [] { "KamikazeChicken.Web.Controllers" }    
                
            );

            routes.MapRoute(
                name: "Page",
                url: "trang/{alias}.html",
                defaults: new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeChicken.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Product Detail",
                url: "{alias}.p-{productId}.html",
                defaults: new { controller = "Product", action = "Detail", productId = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeChicken.Web.Controllers" }

            );

            routes.MapRoute(
               name: "Search",
               url: "tim-kiem.html",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
               namespaces: new string[] { "KamikazeChicken.Web.Controllers" }

           );


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
