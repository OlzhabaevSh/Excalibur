using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAPI.Admin
{
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using Core.Admin.Models;

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
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            var applications = builder.EntitySet<Application>("Applications");
            var applicationUsers = builder.EntitySet<ApplicationUser>("ApplicationUsers");
            var applicationLists = builder.EntitySet<ApplicationList>("ApplicationLists");
            var applicationRoles = builder.EntitySet<ApplicationRoles>("ApplicationRoles");

            applicationRoles.EntityType.Action("AddToApplication")
                .Parameter<int>("applicationId");
            applicationRoles.EntityType.Action("RemoveFromApplication")
                .Parameter<int>("applicationId");
            applicationRoles.EntityType.Action("AddToApplications")
                .CollectionParameter<int>("applicationIds");
            applicationRoles.EntityType.Action("RemoveFromApplications")
                .CollectionParameter<int>("applicationIds");

            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

        }
    }
}
