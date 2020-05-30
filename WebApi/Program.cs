using System;
using System.Web.Http.SelfHost;

namespace WebApi
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("服务开始启动......");

            var config = new HttpSelfHostConfiguration(new Uri("http://localhost:8848"));
            WebApiConfig.Register(config);
            //config.Routes.MapHttpRoute(
            //    "API Default", "api/{controller}/{action}/{id}",
            //    new { id = RouteParameter.Optional });
            ////重新定义接口返回信息内容
            //config.Filters.Add(new ApiResultAttribute());
            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

                Console.WriteLine("服务启动成功！！");

                Console.ReadLine();
            }
        }
    }
}