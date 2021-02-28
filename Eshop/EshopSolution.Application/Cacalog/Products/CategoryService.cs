using EshopSolution.Data.EF;
using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Products
{
    public class CategoryService : ICategoryService
    {
        public async Task<ApiResult<PageResult<CategoryViewModel>>> GetFeaturedP(GetManageCategoryPagingRequest request)
        {
            //1.filter
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        select new { c, ct };

            //2.filer by languageid
            query = query.Where(x => x.ct.LanguageId == request.LanguageId);

            //3/filter by keyword
            if (!String.IsNullOrWhiteSpace(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword)
                                    || x.ct.SeoAlias.Contains(request.Keyword)
                                    || x.ct.SeoDescription.Contains(request.Keyword)
                                    || x.ct.SeoTitle.Contains(request.Keyword)
                                    || x.ct.CategoryId.ToString().Contains(request.Keyword));

            //4. paging
            query = query.Skip((request.PageIndex - 1) * request.PageSize);
            var data = query.Select(x => new CategoryViewModel()
            {
                
                Id = x.c.Id,
                Name = x.ct.Name,
                IsShowOnHome = x.c.IsShowOnHome,
                ParentId = x.c.ParentId,
                LanguageId = x.ct.LanguageId,
                SeoAlias = x.ct.SeoAlias,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
                SortOrder = x.c.SortOrder,
                Status = x.c.Status
            }).ToList();

            var pageResult = new PageResult<CategoryViewModel>()
            {
                TotalRecord = data.Count(),
                Item = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PageResult<CategoryViewModel>>(pageResult);
        }
        public async Task<ApiResult<PageResult<CategoryViewModel>>> GetAllPaging(GetManageCategoryPagingRequest request)
        {
            //1.filter
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        select new { c, ct };

            //2.filer by languageid
            query = query.Where(x => x.ct.LanguageId == request.LanguageId);

            //3/filter by keyword
            if (!String.IsNullOrWhiteSpace(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword)
                                    || x.ct.SeoAlias.Contains(request.Keyword)
                                    || x.ct.SeoDescription.Contains(request.Keyword)
                                    || x.ct.SeoTitle.Contains(request.Keyword)
                                    || x.ct.CategoryId.ToString().Contains(request.Keyword));

            //4. paging
            query = query.Skip((request.PageIndex - 1) * request.PageSize);
            var data = query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                IsShowOnHome = x.c.IsShowOnHome,
                ParentId = x.c.ParentId,
                LanguageId = x.ct.LanguageId,
                SeoAlias = x.ct.SeoAlias,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
                SortOrder = x.c.SortOrder,
                Status = x.c.Status
            }).ToList();

            var pageResult = new PageResult<CategoryViewModel>()
            {
                TotalRecord = data.Count(),
                Item = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PageResult<CategoryViewModel>>(pageResult);
        }

        private readonly EshopDbContext _context;

        public CategoryService(EshopDbContext eshopDbContext)
        {
            _context = eshopDbContext;
        }

        public async Task<CategoryViewModel> GetById(int id, string languageId)
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

        public async Task<ApiResult<bool>> Create(CategoryCreateRequest request)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == request.LanguageId && ct.Name == request.Name

                        select new { c, ct };
            if (query.Count() != 0)
            {
                return new ApiErrorResult<bool>("Tên danh mục bị trùng ");
            }

            Category category = new Category()
            {
                SortOrder = request.SortOrder,
                IsShowOnHome = request.IsShowOnHome,
                ParentId = request.ParentId,
                Status = request.Status,
                CategoryTranslations = new List<CategoryTranslation>(){
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
            if (await _context.SaveChangesAsync() == 0)
                return new ApiErrorResult<bool>();
            else
                return new ApiSuccessResult<bool>();
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
                ParentId = x.c.ParentId,
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToList();

            return new ApiSuccessResult<List<CategoryViewModel>>(data);
        }

        public async Task<ApiResult<bool>> Update(CategoryUpdateRequest request)
        {
            CategoryViewModel categoryVD = await GetById(request.Id, request.LanguageId);
            if (categoryVD == null)

                return new ApiErrorResult<bool>();

            //check categorytranslation
            CategoryTranslation categoryTranslation = _context.CategoryTranslations.Where(x => x.CategoryId == request.Id
                         && x.LanguageId == request.LanguageId).FirstOrDefault();
            if (categoryTranslation == null)
                return new ApiErrorResult<bool>();

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

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            Category category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category == null)
                return new ApiErrorResult<bool>(true);

            if(_context.ProductInCategories.Where(x => x.CategoryId == id).First()==null)
                _context.Categories.Remove(category);
            else
                category.Status = Status.InActive;

            if (await _context.SaveChangesAsync() > 0)
                return new ApiSuccessResult<bool>();
            else
                return new ApiErrorResult<bool>();
        }
    }
}