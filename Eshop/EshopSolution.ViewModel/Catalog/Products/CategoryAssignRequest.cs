using EshopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectedItem> Categories { get; set; } = new List<SelectedItem>();
    }
}
