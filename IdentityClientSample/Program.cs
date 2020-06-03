using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenClient = new TokenClient("http://localhost:8848/connect/token", "001", "4A7421B2-40DC-458E-A336-07D45A793855");
            var token = tokenClient.RequestClientCredentialsAsync("Api1").Result;

            var client = new HttpClient();
            client.SetBearerToken(token.AccessToken);
            var result = client.GetStringAsync("http://localhost:8848/test").Result;
            Console.WriteLine(result);
            Console.ReadLine();


        }
    }
}
