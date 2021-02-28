using EshopSolution.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { set; get; }

        [Display(Name ="Tên")]
        public string Name { set; get; }

        [Display(Name="Mô tả")]
        public string Description { set; get; }

        [Display(Name ="Chi Tiết")]
        public string Details { set; get; }


        [Display(Name = "Ngôn ngữ ")]
        public string LanguageId { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { set; get; }

        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { set; get; }

        [Display(Name = "Khả dụng")]
        public Status Status { get; set; }

        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }


        public bool isFeatured { get; set; }
    }
}