using EshopSolution.Data.EF;
using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EshopSolution.Application.Cacalog.Products
{
    public class CategoryService : ICategoryService
    {
        private readonly EshopDbContext _context ;
        public CategoryService(EshopDbContext eshopDbContext)
        {
            _context = eshopDbContext;
        }
        public Task<ApiResult<int>> Create()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<List<CategoryViewModel>>> GetAll(string languageId)
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

    
    }
}
