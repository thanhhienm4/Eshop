using System.Collections.Generic;

namespace EshopSolution.ViewModel.Common
{
    public class PageResult<T> : PagingRequestBase
    {
        public List<T> Item { get; set; }

        public int TotalRecord { get; set; }
    }
}