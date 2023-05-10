using IdentityServer4.Models;

namespace IdentityServer.API
{
    public class Configuration
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("AuthenticationAPI", "AuthenticationAPI")
                {
                    Scopes = new List<string>()
                    {
                        "BulkRetailAPI"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope(name: "BulkRetailAPI",   displayName: "Bulk Retail Access API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // for public api
                new Client
                {
                    ClientId = "zuber@tgs.com",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("Knj13LzlVaEBHQwOenlHuMW4Fdt62HGY5awO6ukv+3UY7Qnz9rfRjkXxWYKTxJPAD6V1A/uVMcHWDMF8bz6ksw==".Sha256())
                    },
                    AllowedScopes = { "BulkRetailAPI" }
                }
            };
        }
    }
}
