using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public class UserApiClient :BaseApiClient ,IUserApiClient
    {

        public UserApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, configuration, httpContextAccessor)
        {}

        public async Task<ApiResult <string>> Authenticate(LoginRequest request)
        {
            return await PostAsync<ApiResult<string>>("/api/Users/authenticate", request);
        }

        public async Task<ApiResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            return await GetAsync<ApiResult<PageResult<UserViewModel>>>($"/api/Users/paging?PageIndex=" +
                $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}");
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            return await PostAsync<ApiResult<bool>>("/api/Users/register", request);
        }
        public async Task<ApiResult<bool>> Update(Guid id, UpdateRequest request)
        {
         
            return await PutAsync<ApiResult<bool>>($"/api/Users/{id}/update", request);
        }
        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
           
            return await GetAsync<ApiResult<UserViewModel>>($"/api/Users/{id}/getbyid");
        }
        public async Task<ApiResult<bool>> Delete(DeleteRequest request)
        {
          
            return await DeleteAsync<ApiResult<bool>>($"/api/Users/{request.Id}");
        }
        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {         
            return await PutAsync<ApiResult<bool>>($"/api/Users/{id}/roles",request);
        }
    }
}