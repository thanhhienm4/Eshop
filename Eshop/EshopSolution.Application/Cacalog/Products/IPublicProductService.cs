
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Products
{
    public interface IPublicProductService
    {
        Task<List<ProductViewModel>> GetAll(string languageId);
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}