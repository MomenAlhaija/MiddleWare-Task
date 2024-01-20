using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes(); 

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "myroute",
               routeTemplate: "api/{controller}/{action}/{year}/{month}/{day}",
               defaults: new
               {
                   month = RouteParameter.Optional,
                   day = RouteParameter.Optional,

               },
               constraints: new
               {
                   year = @"\d{0,4}",
                   month = @"\d{0,2}",
                   day = @"{\d{0,2}}"
               }
           ); 
        }
    }
}
