using EshopSolution.Data.EF;
using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EshopSolution.Data.Entities;

namespace EshopSolution.Application.Cacalog.Products
{
    public class CategoryService : ICategoryService
    {
        private readonly EshopDbContext _context ;
        public CategoryService(EshopDbContext eshopDbContext)
        {
            _context = eshopDbContext;
        }
        public CategoryViewModel GetById(int id,string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where id == c.Id && ct.LanguageId == languageId
                        select new { c, ct };

            if (query == null)
                return null;

            var categoryViewModel = query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                IsShowOnHome = x.c.IsShowOnHome,
                LanguageId = x.ct.LanguageId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                SeoAlias = x.ct.SeoAlias,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
                SortOrder = x.c.SortOrder,
                Status = x.c.Status
            }).FirstOrDefault();

            return categoryViewModel;

        }
        public async Task<ApiResult<int>> Create(CategoryCreateRequest request)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == request.LanguageId && ct.Name  == request.Name
       
                        select new { c, ct };
            if(query != null)
            {
                return new  ApiErrorResult<int>("Tên danh mục bị trùng ");
            }

            Category category = new Category()
            {
                SortOrder = request.SortOrder,
                IsShowOnHome = request.IsShowOnHome,
                ParentId = request.ParentId,
                Status = request.Status,
                CategoryTranslations  =  new List<CategoryTranslation>(){
                    new CategoryTranslation()
                    {
                        LanguageId = request.LanguageId,
                        Name = request.Name,
                        SeoAlias = request.SeoAlias,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle
                        
                    }
                },

            };
             _context.Categories.Add(category);
            if (_context.SaveChanges() == 0)
                return new ApiErrorResult<int>();
            else
                return new ApiSuccessResult<int>(category.Id);

            
        }
       
        public async Task<ApiResult<List<CategoryViewModel>>> GetAll(String languageId)
        {
            //1.fillter
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        select new { c, ct, };
            //2.filler with languageid
            query = query.Where(x => x.ct.LanguageId == languageId);
            var data = query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToList();

            return new ApiSuccessResult<List<CategoryViewModel>>(data);
        }
        

        public async Task<ApiResult <int>> Update(CategoryUpdateRequest request)
        {
            CategoryViewModel categoryVD= GetById(request.Id, request.LanguageId);
            if(categoryVD == null)
                return new ApiErrorResult<int>();

            //check categorytranslation
            CategoryTranslation categoryTranslation =  _context.CategoryTranslations.Where(x => x.CategoryId == request.Id
                          && x.LanguageId == request.LanguageId).FirstOrDefault();
            if(categoryTranslation == null)
                return new ApiErrorResult<int>();

            //update Category
            var category = new Category()
            {
                Id = categoryVD.Id,
                IsShowOnHome = categoryVD.IsShowOnHome,
                ParentId = categoryVD.ParentId,
                SortOrder = categoryVD.SortOrder,
                Status = categoryVD.Status
            };

            //update CategoryTranslation
            categoryTranslation.Name = request.Name;
            categoryTranslation.SeoAlias = request.SeoAlias;
            categoryTranslation.SeoDescription = request.SeoDescription;
            categoryTranslation.SeoTitle = request.SeoTitle;

            _context.Categories.Update(category);
            _context.CategoryTranslations.Update(categoryTranslation);

            _context.SaveChanges();
            return new ApiSuccessResult<int>();
            
            
        }

        public async Task<ApiResult<int>> Delete(int id)
        {
            Category category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category == null)
                return new ApiErrorResult<int>();

            _context.Categories.Remove(category);

            if (_context.SaveChanges() > 0)
                return new ApiSuccessResult<int>();
            else
                return new ApiErrorResult<int>();
        }
    }
}
