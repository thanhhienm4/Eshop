using EshopSolution.Application.Cacalog.Products.DTOS;
using EshopSolution.Application.Cacalog.Products.DTOS.Public;
using EshopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Products
{
    class PublicProductService : IPublicProductService
    {
        public int CategoryId { get; set; }

        public PagResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
