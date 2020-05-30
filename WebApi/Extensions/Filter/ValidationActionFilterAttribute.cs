using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Extensions.Filter
{
    public class ValidationActionFilterAttribute : ActionFilterAttribute

    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var error = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0).Select(e => new { name = e.Key, message = e.Value.Errors.FirstOrDefault()?.ErrorMessage });
                var response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new ObjectContent<object>(error, new JsonMediaTypeFormatter());
                actionContext.Response = response;
            }
        }
    }
}