using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(WebAPI.Admin.Startup))]

namespace WebAPI.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            //app.Map("/odata", path =>
            //{
            //    path.UseCors(CorsOptions.AllowAll);
            //});
            app.Map("/signalr", path =>
            {
                path.UseCors(CorsOptions.AllowAll);
                path.RunSignalR();
            });

            ConfigureAuth(app);
            
            //app.Map("/OAuth", path =>
            //{
            //    path.UseCors(CorsOptions.AllowAll);
            //});

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            var serializer = JsonSerializer.Create(serializerSettings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);
        }
    }
}
