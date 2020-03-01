using System;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi.Tests.Controllers
{
    [TestClass]
    public class GreetingControllerTest
    {
        [TestMethod]
        public void PostGreeting()
        {
            //arrange
            var name = "greetingName";
            var message = "greetingMessage";
            var greeting = new Greeting(){Name = name, Message = message};
            var fakeRequest = new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost:5581/api/greeting"));
            var service = new GreetingController();
            service.Request = fakeRequest;
            // act
            var response = service.PostGreeting(greeting);
            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(new Uri("http://localhost:5581/api/greeting/greetingName"), response.Headers.Location);


        }
    }
}
