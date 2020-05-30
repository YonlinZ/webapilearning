using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using WebApi.Models;

namespace WebApi.Extensions.ModelBinding
{
    public class CustomGreetingParameterBinding : HttpParameterBinding
    {
        public CustomGreetingParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            //return Task.Run(() =>
            //{
            //    var name = actionContext.Request.RequestUri.ParseQueryString().Get("name");
            //    var msg = actionContext.Request.RequestUri.ParseQueryString().Get("message");
            //    SetValue(actionContext, new Greeting
            //    {
            //        Id = 1,
            //        Name = name,
            //        Message = msg
            //    });
            //}, cancellationToken);
            var name = actionContext.Request.RequestUri.ParseQueryString().Get("name");
            var msg = actionContext.Request.RequestUri.ParseQueryString().Get("message");
            SetValue(actionContext, new Greeting
            {
                Id = 1,
                Name = name,
                Message = msg
            });
            //actionContext.ActionArguments[Descriptor.ParameterName] = new Greeting
            //{
            //    Id = 1,
            //    Name = name,
            //    Message = msg
            //};

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
    }
}