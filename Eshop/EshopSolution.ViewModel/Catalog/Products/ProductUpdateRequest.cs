using Microsoft.AspNetCore.Http;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { get; set; }
        public string SeoAlias { get; set; }

        public IFormFile ThumbnailImage { get; set; }
        public bool isFeatured { get; set; }
    }
}