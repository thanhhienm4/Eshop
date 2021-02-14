using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, configuration, httpContextAccessor)
        { }

        public async Task<ApiResult<bool>> Create(CategoryCreateRequest request)
        {
            return await PostAsync<ApiResult<bool>>("api/Categories/create", request);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            return await DeleteAsync<ApiResult<bool>>($"api/Categories/{id}");
        }

        public async Task<ApiResult<CategoryViewModel>> GetById(int id, string languageId)
        {
            return await GetAsync<ApiResult<CategoryViewModel>>($"api/Categories/GetbyId/{id}/{languageId}");
        }

        public async Task<List<CategoryViewModel>> GetAll(string languageId)
        {
            return (await GetAsync<ApiResult<List<CategoryViewModel>>>($"api/Categories/GetAll?languageId={languageId}")).ResultObj;
        }

        public async Task<ApiResult<bool>> Update(CategoryUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>>("api/Categories/update", request);
        }

        public async Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetManageCategoryPagingRequest request)
        {
            return await GetAsync<ApiResult<PageResult<CategoryViewModel>>>($"/api/Categories/Paging?PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}&" +
               $"LanguageId={request.LanguageId}");
        }
    }
}