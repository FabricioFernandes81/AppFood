

using IdentityServer4;
using IdentityServer4.Models;

namespace Authentication
{
    public class Config
    {
        public const string Admin = "Admin";
        public const string Client = "Client";


        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
               new IdentityResources.OpenId(),
               new IdentityResources.Email(),
               new IdentityResources.Profile()
           };


        public static IEnumerable<ApiScope> ApiScopes=>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API")
            };


        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "ropc.client",
                    ClientName = "ROPC Client Application",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {new Secret("secret".Sha256())},
                  //  AllowedScopes = { "openid","profile","api1","offline_access"},
                   AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,

                        IdentityServerConstants.StandardScopes.OfflineAccess,
                       "api1",
                    },
                    AllowOfflineAccess = true,

                },new Client
                {
                    ClientId = "spa.client",
                    ClientName = "SPA Client ",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true, // Requer PKCE para segurança adicional

                    RedirectUris = { "http://localhost:5003/callback" }, // URLs de redirecionamento
                    PostLogoutRedirectUris = { "http://localhost:5003/logout-callback" }, // URLs de pós-logout
                    AllowedCorsOrigins = { "http://localhost:5003" }, // Para aplicações SPA

                  //  AllowedScopes = { "openid", "profile", "api1" },
                    AllowOfflineAccess = true,
                }
            };
    }
}
