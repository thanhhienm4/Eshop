using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name = "Giá")]
        public decimal Price { set; get; }

        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { set; get; }

        [Display(Name = "Số lượng tồn ")]
        public int Stock { set; get; }

        [Display(Name = "Tên")]
        public string Name { set; get; }

        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        [Display(Name = "Chi tiết")]
        public string Details { set; get; }

        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        [Display(Name = "Ảnh sản phẩm")]
        public IFormFile ThumbnailImage { get; set; }

        [Display(Name ="Sản phẩm nổi bật")]
        public bool isFeatured { get; set; }
    }
}