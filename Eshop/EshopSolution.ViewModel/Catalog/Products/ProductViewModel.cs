﻿using EshopSolution.Data.Entities;
using EshopSolution.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { get; set; }
        public string ThumbnailImage { get; set; }
        public bool IsFeatured { get; set; }
        public Status Status { get; set; }

        public List<String> Categories { get; set; } = new List<string>();
    }
}