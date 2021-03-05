using EshopSolution.Data.Enums;
using EshopSolution.ViewModels.Common;

namespace EshopSolution.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public Status? Status { get; set; }
    }
}