using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FrikiTeamWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                     name: "ActionApi",
                     routeTemplate: "api/{controller}/{action}/{id}",
                     defaults: new { action = "SearchByName", id = RouteParameter.Optional }
                 );

            config.Routes.MapHttpRoute(
                     name: "ActionApi2",
                     routeTemplate: "api/{controller}/{action}/{id}",
                     defaults: new { action = "SearchByDistrito", id = RouteParameter.Optional }
                 );
            config.Routes.MapHttpRoute(
                     name: "ActionApi3",
                     routeTemplate: "api/{controller}/{action}/{id}",
                     defaults: new { action = "SearchByCalle", id = RouteParameter.Optional }
                 );
        }
    }
}
