﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Common;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Repositories;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Web;
using System.Web.Http.Cors;


namespace WebApiDepartments
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //DI
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            config.DependencyResolver = UnityRegistrator.RegisterRepository<Department, DepartmentRepository>(connectionString);
        }
    }
}
