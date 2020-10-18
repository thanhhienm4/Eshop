using EshopSolution.ViewModel.Common;
using System.Collections.Generic;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public string LanguageId { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}