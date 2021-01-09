using System.Collections.Generic;

namespace EshopSolution.ViewModel.Common
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Item { get; set; }
    }
}