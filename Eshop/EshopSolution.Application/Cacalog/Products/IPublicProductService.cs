using EshopSolution.Application.Cacalog.Products.DTOS;
using EshopSolution.Application.Cacalog.Products.DTOS.Public;
using EshopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Products
{
    public interface IPublicProductService
    {
        PagResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request);
        
    }
}