﻿using EshopSolution.AdminApp.Services;
using EshopSolution.Data.Entities;
using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModel.Catalog.Categories;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        [Authorize]
        public async Task<IActionResult> Index(string keyword,int? categoryId, int pageIndex = 1, int pageSize = 3)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = GetLanguageId(),
                
            };
            if (categoryId != null)
                request.CategoryId = (int)categoryId;
            ViewBag.Keyword = keyword;
            ApiResult<List<CategoryViewModel>> categories = await _categoryApiClient.GetAll(GetLanguageId());
            ViewBag.Categories = categories.ResultObj.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });
            
            

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
            request.LanguageId = GetLanguageId();
            var result = await _productApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["Result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Product");
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
            var result = await _productApiClient.GetById(id, GetLanguageId());

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
            var result = await _productApiClient.GetById(id, GetLanguageId());

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
            var result = await _productApiClient.GetById(Id, GetLanguageId());

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

        private string GetLanguageId()
        {
            string languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.LanguageId);
            if (string.IsNullOrEmpty(languageId))
                languageId = SystemConstants.AppSettings.DefaultLangaueId;
            return languageId;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AssignsCategory(int Id)
        {
            if (!ModelState.IsValid)
            {
                return View(Id);
            }
            var result = await _productApiClient.RoleAssign(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["Result"] = "Gán quyền thành công";
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetRoleAssignRequest(request.Id);
            return View(roleAssignRequest);
        }
    }
}