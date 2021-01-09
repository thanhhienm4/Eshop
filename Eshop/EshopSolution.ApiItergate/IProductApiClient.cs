using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface IProductApiClient
    {
        Task<ApiResult<PageResult<ProductViewModel>>> GetProductPaging(GetManageProductPagingRequest request);

        Task<ApiResult<bool>> Create(ProductCreateRequest request);

        Task<ApiResult<bool>> Update(int id, ProductUpdateRequest request);

        Task<ApiResult<ProductViewModel>> GetById(int id, string LanguageId);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<List<ProductViewModel>> GetFeaturedProducts(string languuageId, int take);
        Task<List<ProductViewModel>> GetLatestProducts(string languuageId, int take);
    }
}