using EshopSolution.ViewModel.Common;
using System.Collections.Generic;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectedItem> Categories { get; set; } = new List<SelectedItem>();
    }
}