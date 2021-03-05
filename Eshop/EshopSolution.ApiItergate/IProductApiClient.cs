using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModels.Catalog.Products;
using EshopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface IProductApiClient
    {
        Task<ApiResult<PageResult<ProductViewModel>>> GetProductPaging(ProductPagingRequest request);

        Task<ApiResult<bool>> Create(ProductCreateRequest request);

        Task<ApiResult<bool>> Update(int id, ProductUpdateRequest request);

        Task<ApiResult<ProductViewModel>> GetById(int id, string LanguageId = SystemConstants.AppSettings.DefaultLangaueId);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<List<ProductViewModel>> GetFeaturedProducts(string languuageId, int take);
        Task<List<ProductViewModel>> GetLatestProducts(string languuageId, int take);
        Task<ProductDetailViewModel> GetProductDetail(string languageId, int id);
        Task<List<ImageViewModel>> GetproductImages(int id);
        Task<ApiResult<bool>> AddImage(ProductImageCreateRequest request);
        Task<ApiResult<bool>> UpdateImage(ProductImageUpdateRequest request);
        Task<ApiResult<bool>> DeleteImage(int id);
        Task<ProductImageViewModel> GetProductImage(int imageId);
        Task<bool> UpdateThumnail(int productId, int imageId);


    }
}