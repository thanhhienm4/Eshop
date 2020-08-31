﻿namespace EshopSolution.ViewModel.Common
{
    public class PagingRequestBase :RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}