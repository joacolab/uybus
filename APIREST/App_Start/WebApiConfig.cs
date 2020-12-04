using APIREST.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIREST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*
           config.Routes.MapHttpRoute(
               name: "CrearLinea",
               routeTemplate: "api/crear-linea"    ,
               defaults: new { controller = "Admin", action = "crearLinea"  }
           );
            */

        }
    }
}
