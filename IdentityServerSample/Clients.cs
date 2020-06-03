using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServerSample
{
    public static class Clients
    {
        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "zyl",
                    ClientId ="001",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("4A7421B2-40DC-458E-A336-07D45A793855".Sha256())
                    },
                    AllowedScopes = new List<string>{"Api1"},
            
                }
            };
        }
    }
}
