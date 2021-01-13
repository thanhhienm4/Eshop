using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Products
{
    public interface ICategoryService
    {
        Task<ApiResult<PageResult<CategoryViewModel>>> GetAllPaging(GetManageCategoryPagingRequest request);

        Task<ApiResult<List<CategoryViewModel>>> GetAll(String languageId);

        Task<ApiResult<bool>> Create(CategoryCreateRequest request);

        Task<ApiResult<bool>> Update(CategoryUpdateRequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<CategoryViewModel> GetById(int id, string languageId);
    }
}