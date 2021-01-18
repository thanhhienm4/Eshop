using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Catalog.ProductImages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class ProductDetailViewModel
    {
        public CategoryViewModel Category {get ;set;}
        public ProductViewModel Product { get; set; }

        public List<ProductViewModel> RetalatedProducts { get; set; }
        public List<ProductImageViewModel> productImages { get; set; }


    }
}
