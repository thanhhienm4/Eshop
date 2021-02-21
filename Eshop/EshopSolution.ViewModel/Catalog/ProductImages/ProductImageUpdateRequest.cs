using Microsoft.AspNetCore.Http;

namespace EshopSolution.ViewModels.Catalog.ProductImages
{
    public class ProductImageUpdateRequest
    {
        public int imageId { get; set; }

        public string Caption { get; set; }


        public int SortOrder { get; set; }

       
    }
}