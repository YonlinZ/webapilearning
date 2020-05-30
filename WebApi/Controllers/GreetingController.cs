using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class GreetingController : ApiController
    {
        public static List<Greeting> _greetings = new List<Greeting>();
        //public string GetGreeting(int id)
        //{
        //    var greeting = _greetings.FirstOrDefault(g => g.Id == id);
        //    if (greeting == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return $"{greeting.Message}, {greeting.Name}";
        //}

        //public HttpResponseMessage PostGreeting(HttpRequestMessage request)
        //{
        //    var id = int.Parse(request.RequestUri.ParseQueryString().Get("id"));
        //    var name = request.RequestUri.ParseQueryString().Get("name");
        //    var msg = request.RequestUri.ParseQueryString().Get("message");
        //    var greeting = new Greeting
        //    {
        //        Id = id,
        //        Name = name,
        //        Message = msg
        //    };
     
        //    _greetings.Add(greeting);
        //    var greetingLocation = new Uri(request.RequestUri.Authority + request.RequestUri.LocalPath + id);
        //    var response = this.Request.CreateResponse(HttpStatusCode.Created);
        //    response.Headers.Location = greetingLocation;
        //    return response;
        //}


        public HttpResponseMessage GetGreeting(Greeting greeting)
        {
            if (greeting == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "failed");
            }
            _greetings.Add(greeting);
            var greetingLocation = new Uri(Request.RequestUri.Authority + Request.RequestUri.LocalPath + greeting.Id);

            //Redirect(Request.RequestUri.Authority + Request.RequestUri.LocalPath + greeting.Id);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = greetingLocation;
            return response;
        }

    }
}
