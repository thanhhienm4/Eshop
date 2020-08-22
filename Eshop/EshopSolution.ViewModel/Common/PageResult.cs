using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Common
{
    public class PageResult<T> :PagingRequestBase
    {
        public List<T> Item { get; set; }

        public int TotalRecord { get; set; }
    }
}
