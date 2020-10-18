using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
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
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, configuration, httpContextAccessor)
        { }
        public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        {
        
            return await PostAsync<ApiResult<bool>>("/api/Products/create",request);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
          
            return await DeleteAsync<ApiResult<bool>>($"/api/Products/{id}");
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int id)
        {
            return await GetAsync< ApiResult<ProductViewModel>>($"/api/Products/{id}");
        }

        public async Task<ApiResult<PageResult<ProductViewModel>>> GetProductPaging(GetManageProductPagingRequest request)
        {
  
            return await GetAsync<ApiResult<PageResult<ProductViewModel>>>($"/api/Products/{request.LanguageId}/paging?PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}");
        }

        public async Task<ApiResult<bool>> Update(int id, ProductUpdateRequest request)
        {
           
            return await PutAsync<ApiResult<bool>>($"/api/Products/{id}/update", request);
           
        }
    }
}
