using EshopSolution.ApiIntergate;
using EshopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Category(string culture, int id ,int pageIndex = 1, int pageSize = 6)
        {
            var productPagingRequest = new ProductPagingRequest()
            {
                LanguageId = culture,
                CategoryId = id,
                PageIndex = pageIndex,
                PageSize = pageSize
                
            };
            var data = await _productApiClient.GetProductPaging(productPagingRequest);
   
            return View(data.ResultObj);
        }
        public async Task<IActionResult> Detail(string culture,int id)
        {
            ProductDetailViewModel productDetailViewModel = await _productApiClient.GetProductDetail(culture,id);
            return View(productDetailViewModel);
        }
    }
}
