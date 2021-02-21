using Microsoft.AspNetCore.Http;

namespace EshopSolution.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {
        public int ProductId { get; set; }

        public string Caption { get; set; }


        public int SortOrder { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}