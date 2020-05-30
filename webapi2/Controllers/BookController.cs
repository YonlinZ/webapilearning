using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi2.Models;

namespace webapi2.Controllers
{
    public class BookController : ApiController
    {
        public HttpResponseMessage Get(Book book)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
