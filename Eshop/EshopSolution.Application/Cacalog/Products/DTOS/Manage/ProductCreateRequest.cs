using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Products.DTOS.Manage
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        public int LanguageId { get; set; }
    }
}
