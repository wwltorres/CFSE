using CFSE.RestApi.DependencyResolution;
using CFSE.RestApi.SecurityToken;
using Microsoft.Owin;
using Owin;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(CFSE.RestApi.OwinStartup))]

namespace CFSE.RestApi
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new CustomOAuthOptions());
            app.UseJwtBearerAuthentication(new CustomJwtOptions());

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            IContainer container = IoC.Initialize();
            container.AssertConfigurationIsValid();
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }
    }
}