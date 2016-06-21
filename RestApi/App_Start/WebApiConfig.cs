using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using CFSE.RestApi.HelperClasses.Handlers;
using CFSE.RestApi.HelperClasses.Filters;
using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Formatting;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace CFSE.RestApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register(HttpConfiguration config)
        {
            App_Start.StructuremapWebApi.Start();

   
            
            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            
            config.Filters.Add(new ValidateModelStateFilterAttribute());
            config.Filters.Add(new AuditLogGetFilterAttribute());

            config.MessageHandlers.Add(new LanguageMessageHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}
