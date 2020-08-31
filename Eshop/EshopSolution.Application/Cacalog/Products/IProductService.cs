using eShopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.Application
{
    public interface IProductService
    {

        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int ProductId);

        Task<PageResult<ProductViewModel>> GetAllPaging(string languageId, GetManageProductPagingRequest request);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task<int> AddImages(int productId, ProductImageCreateRequest request);

        Task<int> DeleteImages(int imageId);

        Task<int> UpdateImages(int imageId, ProductImageUpdateRequest request);

        Task AddViewCount(int productId);

        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}