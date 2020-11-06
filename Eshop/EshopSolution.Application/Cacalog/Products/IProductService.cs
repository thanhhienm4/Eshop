using eShopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.Application
{
    public interface IProductService
    {

        Task<ApiResult<int>> Create(ProductCreateRequest request);

        Task<ApiResult<int>> Update(ProductUpdateRequest request);
       

        Task<ApiResult<bool>> Delete(int ProductId);

        Task<ApiResult<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request);

        Task<ApiResult<bool>> UpdatePrice(int productId, decimal newPrice);

        Task<ApiResult<bool>> UpdateStock(int productId, int addedQuantity);

        Task<ApiResult<int>> AddImages(int productId, ProductImageCreateRequest request);

        Task<ApiResult<bool>> DeleteImages(int imageId);

        Task<ApiResult<int>> UpdateImages(int imageId, ProductImageUpdateRequest request);

        Task AddViewCount(int productId);

        Task<ApiResult<ProductViewModel>> GetById(int productId, string languageId);

        Task<ApiResult<ProductImageViewModel>> GetImageById(int imageId);

        Task<ApiResult<List<ProductImageViewModel>>> GetListImages(int productId);

        Task<ApiResult<PageResult<ProductViewModel>>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}