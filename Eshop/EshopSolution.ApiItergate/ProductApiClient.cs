using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModels.Catalog.Products;
using EshopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, configuration, httpContextAccessor)
        { }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/Products/{id}/categories", request);
        }

        public async Task<ApiResult<bool>> Update(int id, ProductUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/Products/{id}/update", request);

        }

        public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        {
            HttpClient client = GetHttpClient();

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }
            if (request.Description != null)
                requestContent.Add(new StringContent(request.Description.ToString()), "Description");
            if (request.Details != null)
                requestContent.Add(new StringContent(request.Details.ToString()), "Details");
            if (request.LanguageId != null)
                requestContent.Add(new StringContent(request.LanguageId.ToString()), "LanguageId");
            if (request.Name != null)
                requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            //if (request.OriginalPrice != null)
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "OriginalPrice");
            //if (request.Price!= null)
            requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            if (string.IsNullOrWhiteSpace(request.SeoAlias))
                request.SeoAlias = "";
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "SeoAlias");

            if (string.IsNullOrWhiteSpace(request.SeoDescription))
                request.SeoDescription = "";
            requestContent.Add(new StringContent(request.SeoDescription.ToString()), "SeoDescription");

            if (string.IsNullOrWhiteSpace(request.SeoTitle))
                request.SeoTitle = "";
            requestContent.Add(new StringContent(request.SeoTitle.ToString()), "SeoTitle");
            //if (request.Stock != null)
            requestContent.Add(new StringContent(request.Stock.ToString()), "Stock");

            var response = await client.PostAsync($"/api/products/create", requestContent);

            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<bool>(response.IsSuccessStatusCode);
            }
            return new ApiErrorResult<bool>();
            //return await PostAsync<ApiResult<bool>>("/api/Products/create", request);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/Products/{id}");
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int id, string languageId = SystemConstants.AppSettings.DefaultLangaueId)
        {
            return await GetAsync<ApiResult<ProductViewModel>>($"/api/Products/{id}/{languageId}");
        }

        public async Task<ApiResult<PageResult<ProductViewModel>>> GetProductPaging(ProductPagingRequest request)
        {
            return await GetAsync<ApiResult<PageResult<ProductViewModel>>>($"/api/Products/{request.CategoryId}/paging?PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&Keyword={request.Keyword}&" +
               $"LanguageId={request.LanguageId}");
        }
        public async Task<List<ProductViewModel>> GetFeaturedProducts(string languageId,int take)
        {
            return (await GetAsync<ApiResult<List<ProductViewModel>>>($"/api/Products/featured/{languageId}/{take}")).ResultObj;
        }
        public async Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take)
        {
            return (await GetAsync<ApiResult<List<ProductViewModel>>>($"/api/Products/latest/{languageId}/{take}")).ResultObj;
        }
        public async Task<ProductDetailViewModel> GetProductDetail(string languageId, int id)
        {
            return (await GetAsync<ApiResult<ProductDetailViewModel>>($"/api/Products/Detail/{languageId}/{id}")).ResultObj;
        }
        public async Task<List<ImageViewModel>> GetproductImages(int id)
        {
            return (await GetAsync<ApiResult<List<ImageViewModel>>>($"api/products/{id}/images")).ResultObj;
        }

        public async Task<ApiResult<bool>> AddImage(ProductImageCreateRequest request)
        {
            HttpClient client = GetHttpClient();
            var requestContent = new MultipartFormDataContent();
            if(request.ImageFile!=null)
            {
                byte[] data;
                var br = new BinaryReader(request.ImageFile.OpenReadStream());
                data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                ByteArrayContent bytes = new ByteArrayContent(data);
                

                requestContent.Add(bytes, "ImageFile",request.ImageFile.FileName);
                if (string.IsNullOrWhiteSpace(request.Caption))
                    request.Caption = "";

                requestContent.Add(new StringContent(request.Caption),"Caption");
              

                requestContent.Add(new StringContent(request.ProductId.ToString()), "ProductId");

                requestContent.Add(new StringContent(request.SortOrder.ToString()), "SortOrder");

                var response = await client.PostAsync($"/api/products/addImage", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiSuccessResult<bool>(response.IsSuccessStatusCode);
                }
                return new ApiErrorResult<bool>();

            }
            return new ApiErrorResult<bool>();

        }

        public async Task<ApiResult<bool>> UpdateImage(ProductImageUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/Products/updateImage", request);
        }

        public async Task<ApiResult<bool>> DeleteImage(int imageId)
        {
            return await DeleteAsync<ApiResult<bool>> ($"/api/Products/deleteimage/{imageId}");
        }
        public async Task<ProductImageViewModel> GetProductImage(int imageId)
        {
            return (await GetAsync<ApiResult<ProductImageViewModel>>($"api/products/images/{imageId}")).ResultObj;
        }
        public async Task<bool> UpdateThumnail(int productId,int imageId)
        {
            return (await PutAsync<ApiResult<bool>>($"api/products/{productId}/updatethumnail/{imageId}",null)).ResultObj;
        }
    }
}