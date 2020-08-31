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

        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.PostAsync("/api/Users/authenticate", httpContent);
            var token = await respond.Content.ReadAsStringAsync();
            return token;
        }

        public async Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.GetAsync("/api/Users/paging?PageIndex=" +
                $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}");
            var body = await respond.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<PageResult<UserViewModel>>(body);
            return user;
        }
    }
}