using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<List<CategoryViewModel>>> GetAll(string LanguageId);
        Task<ApiResult<int>> Update(CategoryUpdateRequest request);
        Task<ApiResult<int>> Create(CategoryCreateRequest request);
        Task<ApiResult<int>> Delete(int id);
    }
}
