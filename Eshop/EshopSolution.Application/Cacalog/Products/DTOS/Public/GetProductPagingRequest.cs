using EshopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Products.DTOS.Public
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
