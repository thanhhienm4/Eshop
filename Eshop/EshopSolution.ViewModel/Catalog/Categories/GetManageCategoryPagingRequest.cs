using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Categories
{
    public class GetManageCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }

    }
}
