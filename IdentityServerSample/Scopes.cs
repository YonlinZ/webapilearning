using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServerSample
{
    public static class  Scopes
    {
        public static List<Scope> GetScopes()
        {
            var scopes = new List<Scope>
            {
                new Scope{Name = "Api1"},
                new Scope{Name = "Api2"}
            };

            return scopes; 
        }
    }
}
