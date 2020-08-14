
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return
                new[]
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email(),
                    new IdentityResource
                    {
                        Name = "customprofile",
                        DisplayName = "custom profile",
                        UserClaims = new[] { "role" },
                    }
                };
        }


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "api",
                    DisplayName = "API",
                    Scopes = new List<Scope>{ new Scope("api", new List<string> { "role" }) },
                    UserClaims = new List<string> { "role" }
                }
            };
        }
    }
}
