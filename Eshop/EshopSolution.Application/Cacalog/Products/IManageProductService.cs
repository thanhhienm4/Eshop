using EshopSolution.Application.Cacalog.Products.DTOS;
using EshopSolution.Application.Cacalog.Products.DTOS.Manage;
using EshopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int ProductId);
        Task<List <ProductViewModel>> GetAll();
        Task<PagResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewCount(int productId);
    }
}
