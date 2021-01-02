using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}