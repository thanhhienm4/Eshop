using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Sale;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        public OrderApiClient(IHttpClientFactory httpClientFactory,
                     IHttpContextAccessor httpContextAccessor,
                      IConfiguration configuration)
              : base(httpClientFactory, configuration, httpContextAccessor)
        { }
        public async Task<ApiResult<bool>> Create(OrderCreateRequest request)
        {
            return await PostAsync<ApiResult<bool>>($"/api/Orders/Create", request);
        }

        public async Task<ApiResult<List<OrderViewModel>>> GetListActiveModel(string languageId)
        {
            return await GetAsync<ApiResult<List<OrderViewModel>>>($"/api/Orders/GetListActiveOrder/{languageId}");
        }

        public async Task<ApiResult<bool>> Remove(int id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/Orders/Delete/{id}");
        }

        public async Task<ApiResult<PageResult<OrderViewModel>>>GetAllPaging(OrderPagingRequest request)
        {
            return (await GetAsync<ApiResult<PageResult<OrderViewModel>>>($"/api/Orders/GetAllPaging?PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}&" +
               $"FromDate={request.FromDate}&ToDate={request.ToDate}&Status={request.Status}"));
        }

        public async Task<ApiResult<bool>> UpdateStatus(int orderId,int status)
        {
            return await PutAsync<ApiResult<bool>>($"/api/Orders/UpdateStatus/{orderId}/{status}", null);
        }

        public async Task<ApiResult<OrderViewModel>> GetById(int orderId, string languageId)
        {
            return await PostAsync<ApiResult<OrderViewModel>>($"/api/Orders/{orderId}/{languageId}", null);
        }


    }
}
