﻿namespace EshopSolution.ViewModels.Catalog.Products
{
    public class ProductDeleteRequest
    {
        public int Id { get; set; }

        public ProductDeleteRequest()
        {
        }

        public ProductDeleteRequest(int id)
        {
            Id = id;
        }
    }
}