using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.DTOs
{
    public class PagResult <T>
    {
        public List<T> Item { get; set; }

        public int TotalRecord { get; set; }
    }
}
