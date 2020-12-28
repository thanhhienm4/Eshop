using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Categories
{
    public class CategoryDeleteRequest
    {
        public int Id { get; set; }
        public CategoryDeleteRequest() { }
        public CategoryDeleteRequest(int id)
        {
            this.Id = id;
        }
    }
}
