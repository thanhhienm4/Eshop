using EshopSolution.ViewModels.Common;
using System.Collections.Generic;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectedItem> Categories { get; set; } = new List<SelectedItem>();
    }
}