using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using webapi2.Controllers;
using webapi2.Models;

namespace webapi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.ParameterBindingRules.Insert(0, descriptor =>
            {
                if (descriptor.ParameterType == typeof(Book))
                {
                    return new CustomBookParameterBinding(descriptor);
                }

                return null;
            });
        }
    }
}
