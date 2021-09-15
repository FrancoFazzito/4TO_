using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using ArtMarket.Hosts.Web;
using Swashbuckle.Application;

namespace ArtMarket.Hosts.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Remove "Controller" suffix.
            // Taken from http://www.strathweb.com/2013/02/but-i-dont-want-to-call-web-api-controllers-controller/
            var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, string.Empty);


            // Redirijo del root al índice de Swagger
            config.Routes.MapHttpRoute("DefaultPage",
                "",
                null,
                null,
                new RedirectHandler((url => url.RequestUri.ToString()), "swagger"));

            config.Services.Replace(typeof(IHttpControllerTypeResolver),
                new HttpServiceTypeResolver());

            // Web API routes
            config.MapHttpAttributeRoutes();

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // Ignoramos referencias circulares al serializar/deserializar.
            // Caso de uso: Order contiene un array de OrderDetail y OrderDetail "contiene"/referencia una Order.
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}