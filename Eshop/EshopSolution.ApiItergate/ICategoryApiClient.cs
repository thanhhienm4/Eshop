using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<CategoryViewModel>> GetById(int id, string languageId);

        Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetManageCategoryPagingRequest request);

        Task<List<CategoryViewModel>> GetAll(string LanguageId);

        Task<ApiResult<bool>> Update(CategoryUpdateRequest request);

        Task<ApiResult<bool>> Create(CategoryCreateRequest request);

        Task<ApiResult<bool>> Delete(int id);
    }
}