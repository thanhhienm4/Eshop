using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.System.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}