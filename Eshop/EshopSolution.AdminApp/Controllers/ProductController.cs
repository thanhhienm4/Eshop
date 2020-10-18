using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.AdminApp.Services;
using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModel.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.AdminApp.Controllers
{


    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        

        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        [Authorize]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var session = HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            ViewBag.Keyword = keyword;
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            var data = await _productApiClient.GetProductPaging(request);
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _productApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["Result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _productApiClient.GetById(id);

            if (result.IsSuccessed)
            {
                var updateRequest = new ProductUpdateRequest()
                {
                    Id = id, 
                    Name = result.ResultObj.Name,
                    Description = result.ResultObj.Description,
                    Details = result.ResultObj.Details,
                    SeoDescription = result.ResultObj.SeoDescription,
                    SeoTitle = result.ResultObj.SeoTitle,
                    LanguageId = result.ResultObj.LanguageId,
                    SeoAlias = result.ResultObj.SeoAlias,
                    ThumbnailImage = result.ResultObj.ThumbnailImage

                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _productApiClient.Update(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["Result"] = "Chỉnh sửa thành công";
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _productApiClient.GetById(id);

            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _productApiClient.GetById(Id);

            if (result.IsSuccessed)
            {
                return View(new ProductDeleteRequest(Id));
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request.Id);
            }
            var result = await _productApiClient.Delete(request.Id);
            if (result.IsSuccessed)
            {
                TempData["Result"] = "Xóa thành công";
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", result.Message);
            return View(request.Id);
        }
     
    }
}
