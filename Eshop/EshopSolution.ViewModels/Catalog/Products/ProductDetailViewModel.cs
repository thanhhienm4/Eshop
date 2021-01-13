using EshopSolution.ViewModel.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductDetailViewModel
    {
        public CategoryViewModel Category { get; set; }
        public ProductViewModel Product { get; set; }
        public List<ProductViewModel> RelativeProducts { get; set; }
        //public List<Prodc>
    }
}
