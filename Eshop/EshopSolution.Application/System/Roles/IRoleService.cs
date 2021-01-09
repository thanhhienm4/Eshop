using EshopSolution.ViewModel.System.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Role
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetAll();
    }
}