using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApi.Extensions.ModelBinding;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BookController : ApiController
    {
        public HttpResponseMessage Get([FromUri]Book book)
        {
           
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
