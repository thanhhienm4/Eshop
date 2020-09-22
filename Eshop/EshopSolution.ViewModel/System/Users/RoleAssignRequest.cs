using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectedItem> Roles { get; set; } = new List<SelectedItem>();
    }
}
