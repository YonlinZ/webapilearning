using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CustomBookParameterBinding : HttpParameterBinding
    {
        public CustomBookParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
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
            var id = actionContext.Request.RequestUri.ParseQueryString().Get("id");
            var name = actionContext.Request.RequestUri.ParseQueryString().Get("name");
            SetValue(actionContext, new Book
            {
                ID = 10,
                Name = name
            });
            //actionContext.ActionArguments[Descriptor.ParameterName] = new BookController
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