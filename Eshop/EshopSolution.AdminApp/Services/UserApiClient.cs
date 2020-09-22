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
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult <string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.PostAsync("/api/Users/authenticate", httpContent);
            var result =await respond.Content.ReadAsStringAsync();
            if(respond.IsSuccessStatusCode)
            {
                return  JsonConvert.DeserializeObject<ApiSuccessResult<string>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(result);
        }

        public async Task<ApiResult< PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.GetAsync("/api/Users/paging?PageIndex=" +
                $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}");
            var body = await respond.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiSuccessResult< PageResult<UserViewModel>>>(body);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.PostAsync("/api/Users/register", httpContent);
            var result = await respond.Content.ReadAsStringAsync();
           if( respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>("Error");
        }
        public async Task<ApiResult<bool>> Update(Guid id, UpdateRequest request)
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.PutAsync($"/api/Users/{id}/update", httpContent);
            var result = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return  JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return  JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            //var json = JsonConvert.SerializeObject(id);
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            //var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.GetAsync($"/api/Users/{id}/getbyid");
            var body = await respond.Content.ReadAsStringAsync();
            if(respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<UserViewModel>>(body);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<UserViewModel>>(body);
        }
        public async Task<ApiResult<bool>> Delete(DeleteRequest request)
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.DeleteAsync($"/api/Users/{request.Id}");
            var result = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.PutAsync($"/api/Users/{id}/roles", httpContent);
            var result = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result); 
        }
    }
}