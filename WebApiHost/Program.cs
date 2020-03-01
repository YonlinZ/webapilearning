using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Forms;
using System.Web.Http.SelfHost;

namespace WebApiHost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Assembly.Load("WebApi");
            var config = new HttpSelfHostConfiguration(new Uri("http://localhost:8848"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var host = new HttpSelfHostServer(config);
            host.OpenAsync().Wait();

            //Console.WriteLine("HttpSelfHostServer服务已启动，如果需要退出，请按任意键。");
            //Console.ReadKey();
            Application.Run(new Form1());
            host.CloseAsync().Wait();
        }
    }
}
