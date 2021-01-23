using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Utilities
{
    public class CartViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public Decimal Price { get; set; }
    }
}
