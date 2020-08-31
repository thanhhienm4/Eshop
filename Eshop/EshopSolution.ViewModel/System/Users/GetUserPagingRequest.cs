using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.System.Users
{
    public class GetUserPagingRequest:PagingRequestBase 
    {
        public string Keyword { get; set; }
    }
}
