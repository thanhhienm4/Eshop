using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductDeleteRequest
    {
        public int Id { get; set; }
        public ProductDeleteRequest(int id)
        {
            Id = id;
        }
    }
}
