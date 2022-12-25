﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiVersioning.custom
{
    public class CustomControllerSelector:DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor
            SelectController(HttpRequestMessage request)
        {
            // Get all the available Web API controllers
            var controllers = GetControllerMapping();
            // Get the controller name and parameter values from the request URI
            var routeData = request.GetRouteData();

            // Get the controller name from route data.
            // The name of the controller in our case is "Students"
            var controllerName = routeData.Values["controller"].ToString();

            // Default version number to 1
            string versionNumber = "1";
            //var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            //if (versionQueryString["v"] != null)
            //{
            //    versionNumber = versionQueryString["v"];
            //}

            //string customHeader = "x-studentservice-Version";
            //if (request.Headers.Contains(customHeader))
            //{
            //    versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
            //    if (versionNumber.Contains(","))
            //    {
            //        versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
            //    }
            //}


            //var acceptHeader = request.Headers.Accept.
            //    Where(a => a.Parameters.Count(p=>p.Name.ToLower()=="version") > 0);

            //if (acceptHeader.Any())
            //{
            //    versionNumber=acceptHeader.First().Parameters.First(p=>p.Name.ToLower()=="version").Value;  
            //}

            string regex =
                @"application\/vnd\.pragimtech\.([a-z]+)\.v(?<version>[0-9]+)\+([a-z]+)";
            var acceptHeader = request.Headers.Accept.
                Where(a => Regex.IsMatch(a.MediaType,regex,RegexOptions.IgnoreCase));

            if (acceptHeader.Any())
            {
               var match= Regex.Match(acceptHeader.First().MediaType,regex,RegexOptions.IgnoreCase);
                versionNumber = match.Groups["version"].Value;
            }

            if (versionNumber == "1")
            {
                // if version number is 1, then append V1 to the controller name.
                // So at this point the, controller name will become StudentsV1
                controllerName = controllerName + "V1";
            }
            else
            {
                // if version number is 2, then append V2 to the controller name.
                // So at this point the, controller name will become StudentsV2
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            return null;
        }
    }
}