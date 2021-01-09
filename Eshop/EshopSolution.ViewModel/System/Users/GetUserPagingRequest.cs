using EshopSolution.ViewModel.Common;

namespace EshopSolution.ViewModel.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}