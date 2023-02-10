using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using learn.Controllers;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting.Jsonp;

namespace learn
{
    public static class WebApiConfig
    {
        public class CustomMediaType:JsonMediaTypeFormatter
        {
            public CustomMediaType()
            {
                this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            }
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "defaults",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "version1",
                routeTemplate: "api/v1/students/{id}",
                defaults: new { id = RouteParameter.Optional ,controller="StudentV1"}
            );
            config.Routes.MapHttpRoute(
                name: "Version2",
                routeTemplate: "api/v2/students/{id}",
                defaults: new { id = RouteParameter.Optional,controller="StudentV2" }
            );

        }
    }
}
