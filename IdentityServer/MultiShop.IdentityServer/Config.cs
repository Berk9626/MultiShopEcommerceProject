// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        //Apiresource çağrıldığı zaman ben her bir microservicem için, o serviceye erişim sağlayabilencek bir key belirleyeceğim.
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            //ResourceCatalog ismine sahip bir mikroservis kullanıcısı, catalog full per. işlemini gerçekleştirecek

            new ApiResource("ResourceCatalog") 
            {
                Scopes={"CatalogFullPermission","CatalogReadPermission"} // aralığı şu
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes={"DiscountFullPermission"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes={"OrderFullPermission"}
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            //identity kaynağına sahip olan kişi hangi değerlere erişim sağlayacak ?

            new IdentityResources.OpenId(), //herkese açık olan id'ye erişim sağlayacak.
            new IdentityResources.Email(), //herkese açık olan email'ye erişim sağlayacak.
            new IdentityResources.Profile(),

            //IdentityResources ifadesiyle tokenının aldığım kullanıcı o token içerisindeki hangi bilgilere erişim sağlayacağını bildirdim.
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] //bir yetkiye sahip olduğunda yapacağı işlemler
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"), //CatalogFullPermission'a sahip olan kişinin yapabileceği işlemler
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitorın sahip olacağı izinler !!
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="MultiShop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials, //AllowedGrantTypes= neye izin verdiğiyle alakalı
                ClientSecrets= {new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" }
            },

            //manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="MultiShop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials, //AllowedGrantTypes= neye izin verdiğiyle alakalı
                ClientSecrets= {new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
            },

            //admin
              new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="MultiShop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials, //AllowedGrantTypes= neye izin verdiğiyle alakalı
                ClientSecrets= {new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                  IdentityServerConstants.LocalApi.ScopeName, //yerelde tuttuğum api üzerinden scope'un yani kapsamın adına ulaş
                  IdentityServerConstants.StandardScopes.Email, //adminin emailini göster
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile
                  },
                AccessTokenLifetime=600 // 5 DAKİKA SONRA TOKEN ÖMRÜ SONA ERECEK

              }



        };







        //public static IEnumerable<IdentityResource> IdentityResources =>
        //           new IdentityResource[]
        //           {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //           };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //    new ApiScope[]
        //    {
        //        new ApiScope("scope1"),
        //        new ApiScope("scope2"),
        //    };

        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
    }
}