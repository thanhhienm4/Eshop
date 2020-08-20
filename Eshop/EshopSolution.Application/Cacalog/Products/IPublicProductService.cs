using EshopSolution.Application.Cacalog.Products.DTOS;
using EshopSolution.Application.Cacalog.Products.DTOS.Public;
using EshopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Products
{
    public interface IPublicProductService
    {
        Task< PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
        
    }
}