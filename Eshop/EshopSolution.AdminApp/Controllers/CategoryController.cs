using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.AdminApp.Services;
using EshopSolution.ViewModel.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.AdminApp.Controllers
{
    
    public class CategoryController : BaseController
    {
        private readonly ICategoryApiClient _categoryApiCilent;
        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            _categoryApiCilent = categoryApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //public IActionResult Index(int pageIndex, int pageSize, string keyword)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        r
        //    }
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            request.LanguageId = GetLanguageId();
            var result = await _categoryApiCilent.Create(request);
            if (result.IsSuccessed)
            {
                TempData["Result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}
