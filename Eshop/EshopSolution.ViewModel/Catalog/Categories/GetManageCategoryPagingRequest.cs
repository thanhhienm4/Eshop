using EshopSolution.ViewModel.Common;

namespace EshopSolution.ViewModel.Catalog.Categories
{
    public class GetManageCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
    }
}