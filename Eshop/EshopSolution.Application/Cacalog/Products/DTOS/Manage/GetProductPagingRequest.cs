using EshopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Products.DTOS.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIDs { get; set; }
    }
}
