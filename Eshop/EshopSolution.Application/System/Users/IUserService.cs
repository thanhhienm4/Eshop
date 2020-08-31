using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
    }
}