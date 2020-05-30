using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Controllers;
using WebApi.Extensions.Filter;
using WebApi.Extensions.ModelBinding;
using WebApi.Models;

namespace WebApi
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
            //config.ParameterBindingRules.Insert(0, descriptor =>
            //{
            //    if (descriptor.ParameterType == typeof(Book))
            //    {
            //        return new CustomBookParameterBinding(descriptor);
            //    }

            //    return null;
            //});
            config.ParameterBindingRules.Add(descriptor =>
            {
                if (descriptor.ParameterType == typeof(Greeting))
                {
                    return new CustomGreetingParameterBinding(descriptor);
                }

                return null;
            });
            config.Filters.Add(new ValidationActionFilterAttribute());
        }
    }
}
