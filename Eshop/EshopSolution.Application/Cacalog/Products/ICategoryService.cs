using EshopSolution.Data.Entities;
using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Products
{
    public interface ICategoryService 
    {
        Task <ApiResult<List<CategoryViewModel>>> GetAll(String languageId);
        Task<ApiResult<int>> Create(CategoryCreateRequest request);
        Task<ApiResult<int>> Update(CategoryUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        CategoryViewModel GetById(int id,string languageId);


    }
}
