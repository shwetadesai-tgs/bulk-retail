using Microsoft.AspNetCore.Authorization;

namespace OcelotGateway.Handlers
{
    public class RoleLevelRequirement : IAuthorizationRequirement
    {
        public RoleLevelRequirement(string role)
        {
            RequiredPermissionLevel = role;
        }
        public string RequiredPermissionLevel { get; set; }
    }
}
