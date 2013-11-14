using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QTec.Hrms.Web
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // if attribute route is not getting used then you can use convention route as below to get employee languages

            //config.Routes.MapHttpRoute(
            //    name: "EmployeeLanguagesRoute",
            //    routeTemplate: "api/{controller}/{id}/Languages",
            //    defaults: new { id = 0, controller = "Employees", action = "GetLanguages" });
           
            
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Remove default XML handler
            var matches = config.Formatters
                                .Where(f => f.SupportedMediaTypes.Any(m => m.MediaType.ToString() == "application/xml" ||
                                                                           m.MediaType.ToString() == "text/xml"))
                                .ToList();
            foreach (var match in matches)
            {
                config.Formatters.Remove(match);
            }

            config.EnsureInitialized();
        }
    }
}
