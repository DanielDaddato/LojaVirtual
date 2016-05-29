using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Daddato.Lojavirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: null,
               url: "",
               defaults: new { controller = "Vitrine", action = "ListaProdutos",
                   categoria = (string)null,
                   pagina = 1 });

            routes.MapRoute(
               name: null,
               url: "Pagina{pagina}",
               defaults: new
               {
                   controller = "Vitrine",
                   action = "ListaProdutos",
                   categoria = (string)null,
                   pagina = @"\d+"
               });

            routes.MapRoute(
               name: null,
               url: "{categoria}",
               defaults: new
               {
                   controller = "Vitrine",
                   action = "ListaProdutos",
                   categoria = (string)null,
                   pagina = 1
               });
            routes.MapRoute(
               name: null,
               url: "{categoria}/Pagina{pagina}",
               defaults: new
               {
                   controller = "Vitrine",
                   action = "ListaProdutos",
                   categoria = (string)null,
                   pagina = @"\d+"
               });

            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new {controller = "Vitrine", action = "ListaProdutos"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
