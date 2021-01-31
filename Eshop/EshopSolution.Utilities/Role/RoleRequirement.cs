
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Utilities.Role
{
    public class RoleRequirement :IAuthorizationRequirement 
    {
        public string [] Roles { get; set;}

        public RoleRequirement(string roles)
        {
            Roles = roles.Split(";");

        }
    }
}
