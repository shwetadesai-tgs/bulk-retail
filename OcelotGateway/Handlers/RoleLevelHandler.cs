using Microsoft.AspNetCore.Authorization;

namespace OcelotGateway.Handlers
{
    public class RoleLevelHandler : AuthorizationHandler<RoleLevelRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleLevelRequirement requirement)
        {
            var role = context.User.Claims.FirstOrDefault(o => o.Type == "Role")?.Value;
            if (role != requirement.RequiredPermissionLevel)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
