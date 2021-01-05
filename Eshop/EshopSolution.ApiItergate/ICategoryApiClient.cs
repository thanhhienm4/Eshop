using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<CategoryViewModel>> GetById(int id, string languageId);

        Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetManageCategoryPagingRequest request);

        Task<ApiResult<List<CategoryViewModel>>> GetAll(string LanguageId);

        Task<ApiResult<bool>> Update(CategoryUpdateRequest request);

        Task<ApiResult<bool>> Create(CategoryCreateRequest request);

        Task<ApiResult<bool>> Delete(int id);
    }
}