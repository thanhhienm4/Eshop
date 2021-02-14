using EshopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace EshopSolution.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectedItem> Roles { get; set; } = new List<SelectedItem>();
    }
}