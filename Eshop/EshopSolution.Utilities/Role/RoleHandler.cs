using EshopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Utilities.Role
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
         {
           
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Issuer == SystemConstants.Token.Issuer))
            {
                return Task.CompletedTask;
            }

            var roles = context.User.FindFirst(c => c.Type == ClaimTypes.Role && c.Issuer == SystemConstants.Token.Issuer).Value.ToString().Split(";");
            foreach (string userRole in requirement.Roles)
            {
                foreach (string role in roles)
                {
                    if (role == userRole)
                    {
                        context.Succeed(requirement);
                        
                    }

                }
            }
           
            return Task.CompletedTask;

        }

        
    }
}
