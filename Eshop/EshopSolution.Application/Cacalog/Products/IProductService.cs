using EshopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModels.Catalog.Products;
using EshopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.Application
{
    public interface IProductService
    {
        Task<ApiResult<bool>> Create(ProductCreateRequest request);

        Task<ApiResult<bool>> Update(ProductUpdateRequest request);

        Task<ApiResult<bool>> Delete(int ProductId);

        Task<ApiResult<PageResult<ProductViewModel>>> GetAllPaging(ProductPagingRequest request);

        Task<ApiResult<bool>> UpdatePrice(int productId, decimal newPrice);

        Task<ApiResult<bool>> UpdateStock(int productId, int addedQuantity);

        Task<ApiResult<bool>> AddImages(ProductImageCreateRequest request);

        Task<ApiResult<bool>> DeleteImages(int imageId);

        Task<ApiResult<bool>> UpdateImages(ProductImageUpdateRequest request);

        Task AddViewCount(int productId);

        Task<ApiResult<ProductViewModel>> GetById(int productId, string languageId);

        Task<ApiResult<ProductImageViewModel>> GetImageById(int imageId);

        Task<ApiResult<List<ImageViewModel>>> GetListImages(int productId);

        //Task<ApiResult<PageResult<ProductViewModel>>> GetAllByCategoryId(string languageId, ProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssign(CategoryAssignRequest request);

        Task<ApiResult<List<ProductViewModel>>> GetFeaturedProducts(string languageId, int number);
        Task<ApiResult<List<ProductViewModel>>> GetLatestProducts(string languageId, int number);
        Task<ApiResult<ProductDetailViewModel>> GetProductDetail(string languageId, int id);
        Task<ApiResult<bool>> UpdateThumnail(int productId, int imageId);
    }
}