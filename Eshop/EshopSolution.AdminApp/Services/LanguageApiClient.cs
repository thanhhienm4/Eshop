using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        
        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            //var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var respond = await client.GetAsync($"/api/Language/GetAll");
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                var deserializeObject = (List<LanguageViewModel>)JsonConvert.DeserializeObject(body, typeof(List<LanguageViewModel>));
                return new ApiSuccessResult<List<LanguageViewModel>>(deserializeObject);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<List<LanguageViewModel>>>(body);
        }
    }
}
