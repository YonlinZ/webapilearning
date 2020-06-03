using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Extensions.CustomDelegatingHandler
{
    public class CustomDelegatingHandler1:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"请求进入：{nameof(CustomDelegatingHandler)}, URI: {request.RequestUri}，METHOD: {request.Method}");
            var response = base.SendAsync(request, cancellationToken);
            Console.WriteLine($"响应进入：{nameof(CustomDelegatingHandler)}, RESULT: {response.Result}，METHOD: {request.Method}");
            return response;
        }
    }
}