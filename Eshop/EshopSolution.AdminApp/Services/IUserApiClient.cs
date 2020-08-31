using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
    }
}
