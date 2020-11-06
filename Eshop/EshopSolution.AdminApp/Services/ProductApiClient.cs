using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
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

        public Task<ApiResult<bool>> AssignCategory(int id, int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(SystemConstants.AppSettings.Bearer, sessions);
            
            var requestContent = new MultipartFormDataContent();

            if(request.ThumbnailImage!=null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }
            if(request.Description!=null)
                requestContent.Add(new StringContent(request.Description.ToString()),"Description");
            if (request.Details != null)
                requestContent.Add(new StringContent(request.Details.ToString()),"Details");
            if (request.LanguageId != null)
                requestContent.Add(new StringContent(request.LanguageId.ToString()), "LanguageId");
            if (request.Name != null)
                requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            //if (request.OriginalPrice != null)
                requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "OriginalPrice");
            //if (request.Price!= null)
                requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            if (request.SeoAlias != null)
                requestContent.Add(new StringContent(request.SeoAlias.ToString()), "SeoAlias");
            if (request.SeoDescription != null)
                requestContent.Add(new StringContent(request.SeoDescription.ToString()), "SeoDescription");
            if (request.SeoTitle != null)
                requestContent.Add(new StringContent(request.SeoTitle.ToString()), "SeoTitle");
            //if (request.Stock != null)
                requestContent.Add(new StringContent(request.Stock.ToString()), "Stock");

            var response = await client.PostAsync($"/api/products/create", requestContent);
           
            if(response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<bool>(response.IsSuccessStatusCode);
            }
            return new ApiErrorResult<bool>();
            //return await PostAsync<ApiResult<bool>>("/api/Products/create", requestContent);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/Products/{id}");
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int id, string languageId)
        {
            return await GetAsync<ApiResult<ProductViewModel>>($"/api/Products/{id}/{languageId}");
        }

        public async Task<ApiResult<PageResult<ProductViewModel>>> GetProductPaging(GetManageProductPagingRequest request)
        {
            return await GetAsync<ApiResult<PageResult<ProductViewModel>>>($"/api/Products/{request.CategoryId}/paging?PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}&" +
               $"LanguageId={request.LanguageId}");
        }

        public async Task<ApiResult<bool>> Update(int id, ProductUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/Products/{id}/update", request);
        }
    }
}