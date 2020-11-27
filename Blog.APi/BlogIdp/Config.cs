// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace BlogIdp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("restapi", "My RESTful API",new List<string>()
                {
                    "name",
                    "gender",
                    JwtClaimTypes.PreferredUserName,
                    JwtClaimTypes.Picture
                }),
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                // implicit
                new Client
                {
                    ClientId = "blog-client",
                    ClientName="BlogClient",
                    ClientUri = "http://localhost:4200",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    //是否允许accessToken通过浏览器传送
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    //有效期
                    AccessTokenLifetime = 180,
                    RequireClientSecret = false,
                    RedirectUris =
                    {
                        "http://localhost:4200/signin-oidc",
                        "http://localhost:4200/redirect-silentrenew"
                    },
                    PostLogoutRedirectUris = {"http://localhost:4200/"},
                    //跨域允许
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "restapi"
                    }
                },
            };
    }
}