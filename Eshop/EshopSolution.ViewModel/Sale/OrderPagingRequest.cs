using EshopSolution.Data.Enums;
using EshopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Sale
{
    public class OrderPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public OrderStatus? Status {get; set;}
    }
}
