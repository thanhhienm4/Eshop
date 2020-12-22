using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public class CategoryApiClient :BaseApiClient, ICategoryApiClient 
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, configuration, httpContextAccessor)
        { }

        public Task<ApiResult<int>> Create(CategoryCreateRequest request)
        {
            return PostAsync<ApiResult<int>>("api/Categories/create", request);
        }

        public Task<ApiResult<int>> Delete(int id)
        {
            return DeleteAsync<ApiResult<int>>($"api/Categories/{id}");
        }

        public Task<ApiResult<List<CategoryViewModel>>> GetAll(String languageId)
        {
            return GetAsync<ApiResult<List<CategoryViewModel>>>($"api/Categories/GetAll?languageId={languageId}");
            
        }

        public Task<ApiResult<int>> Update(CategoryUpdateRequest request)
        {
            return PutAsync<ApiResult<int>>("api/Categories/update",request);
        }
    }
}
