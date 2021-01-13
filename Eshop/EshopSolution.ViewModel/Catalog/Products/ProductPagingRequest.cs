using EshopSolution.ViewModel.Common;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
        public int CategoryId { get; set; }
    }
}