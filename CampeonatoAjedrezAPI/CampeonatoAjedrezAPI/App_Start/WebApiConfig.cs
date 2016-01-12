using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace CampeonatoAjedrezAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var xmlformatter = new XmlMediaTypeFormatter
            {
                MaxDepth = 1
            };
            var jsonformatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                                    {
                                        NullValueHandling = NullValueHandling.Ignore,
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                        MaxDepth= 1,PreserveReferencesHandling=PreserveReferencesHandling.None
                                        
                                    }
            };

            config.Formatters.RemoveAt(0);
            config.Formatters.Insert(0, jsonformatter);
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Insert(1, xmlformatter);

        }
    }
}
