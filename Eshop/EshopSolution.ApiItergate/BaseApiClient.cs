using EshopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public class BaseApiClient
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IConfiguration _configuration;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        // http get data form Api
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.ServerSettings.ServerBackEnd);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(SystemConstants.AppSettings.Bearer, sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert
                    .DeserializeObject(body, typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        // post data to Api
        protected async Task<TResponse> PostAsync<TResponse>(string url, object obj)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(SystemConstants.ServerSettings.ServerBackEnd);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(SystemConstants.AppSettings.Bearer, sessions);
            var response = await client.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert
                    .DeserializeObject(body, typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        // send delete request to API
        protected async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SystemConstants.AppSettings.Bearer, BearerToken);
            client.BaseAddress = new Uri(SystemConstants.ServerSettings.ServerBackEnd);
            var respond = await client.DeleteAsync(url);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert
                    .DeserializeObject(body, typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        // send update request to Api
        protected async Task<TResponse> PutAsync<TResponse>(string url, object obj)
        {
            var BearerToken = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SystemConstants.AppSettings.Bearer, BearerToken);
            client.BaseAddress = new Uri(SystemConstants.ServerSettings.ServerBackEnd);
            var respond = await client.PutAsync(url, httpContent);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert
                    .DeserializeObject(body, typeof(TResponse));
                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
    }
}