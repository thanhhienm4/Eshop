using EshopSolution.Application.Cacalog.Products.DTOS;
using EshopSolution.Application.Cacalog.Products.DTOS.Public;
using EshopSolution.Application.DTOs;
using EshopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EshopSolution.Application.Cacalog.Products
{
    class PublicProductService : IPublicProductService
    {
        public readonly EshopDbContext _context;
        public PublicProductService(EshopDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            //1.Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id

                        select new { p, pt, pic };
            //2.Filter
            
            if (request.CategoryId != null && request.CategoryId.Value >0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.Price,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.DateCreated,
                    ProductId = x.pt.ProductId
                }).ToListAsync();

            //4.Select and Projection
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Item = await data
            };

            return pageResult;


        }
    }
}
