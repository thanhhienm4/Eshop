using System.Collections.Generic;

namespace EshopSolution.ViewModels.Common
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Item { get; set; }
    }
}