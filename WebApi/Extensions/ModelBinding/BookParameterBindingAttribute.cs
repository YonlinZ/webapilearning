using System.Web.Http;
using System.Web.Http.Controllers;
using WebApi.Controllers;

namespace WebApi.Extensions.ModelBinding
{
    public class BookParameterBindingAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new CustomBookParameterBinding(parameter);
        }
    }
}