using EshopSolution.ViewModel.Common;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}