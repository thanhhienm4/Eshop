using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.System.Users;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> Update(Guid id, UpdateRequest request);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid Id);

        Task<Guid> GetUserId(ClaimsPrincipal claimsPrincipal);
    }
}