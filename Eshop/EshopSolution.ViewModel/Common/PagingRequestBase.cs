using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Common
{
    public class PagingRequestBase
    {
        public string LanguageId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
