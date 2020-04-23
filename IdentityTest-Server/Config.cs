using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityTest_Server
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis => new List<ApiResource>
        {
            new ApiResource
            {
                Name = "TestApi",
                ApiSecrets = { new Secret("scopeSecret".Sha256()) },
                Scopes = { new Scope("TestApi") }
            }
        };

        public static IEnumerable<Client> Client => new List<Client>
        {
            new Client
            {
                ClientId = "TestClient",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                AllowedScopes = { "TestApi" },
                RedirectUris = { "https://localhost:5003" }
            },
            new Client
            {
                ClientId = "testApiClient",
                ClientName = "Test Api Client",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowedScopes = { "TestApi" },
                RedirectUris = { "https://localhost:5001/signin-oidc"},
                PostLogoutRedirectUris = { "https://localhost:5001/" }
            }
        };
    }
}
