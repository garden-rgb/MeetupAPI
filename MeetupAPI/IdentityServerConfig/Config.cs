using IdentityServer4.Models;

namespace MeetupAPI.Web.IdentityServerConfig
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { 
                new ApiScope("MeetupAPI", "Meetup Api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            { 
                new Client
                {
                    ClientId = "client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = { "MeetupAPI" }
                }
            };
    }
}
