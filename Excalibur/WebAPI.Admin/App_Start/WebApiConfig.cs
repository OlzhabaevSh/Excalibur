using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Core.Admin.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAPI.Admin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ApplicationUser>("ApplicationUsers");
            builder.EntitySet<ApplicationList>("ApplicationLists");

            builder.EntitySet<ApplicationRoles>("ApplicationRoles");
            builder.EntitySet<Application>("Applications");
            
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
