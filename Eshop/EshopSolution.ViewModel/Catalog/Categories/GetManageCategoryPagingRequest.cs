using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Categories
{
    class GetManageCategoryPagingRequest : PagingRequestBase
    {
        string Keyword { get; set; }
        string LanguageId { get; set; }

    }
}
