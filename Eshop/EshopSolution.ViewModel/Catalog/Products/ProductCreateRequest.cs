using Microsoft.AspNetCore.Http;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        public string LanguageId { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
