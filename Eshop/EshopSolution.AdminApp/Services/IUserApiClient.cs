using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using System;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UpdateRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(DeleteRequest request);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}