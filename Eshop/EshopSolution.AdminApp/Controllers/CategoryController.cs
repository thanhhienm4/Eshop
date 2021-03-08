using EshopSolution.ApiIntergate;
using EshopSolution.Data.Enums;
using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace EshopSolution.AdminApp.Controllers
{
    [Authorize(Policy ="Edit")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryApiClient _categoryApiCilent;
        private readonly ILanguageApiClient _languageApiClient;

        public CategoryController(ICategoryApiClient categoryApiClient, ILanguageApiClient languageApiClient)
        {
            _categoryApiCilent = categoryApiClient;
            _languageApiClient = languageApiClient;
        }

        public async Task<IActionResult> Index(string keyword,Status? status, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetManageCategoryPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = GetLanguageId(),
                Status = status
            };
            ViewBag.Statuss = Enum.GetValues(typeof(Status)).Cast<Status>()
                .Select(x => new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = status.HasValue && status.ToString() == x.ToString()
                }).ToList();
            ViewBag.Keyword = keyword;

            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            var data = await _categoryApiCilent.GetCategoryPaging(request);
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
          
            ViewBag.Categories =(await _categoryApiCilent.GetAll(GetLanguageId()));
            return View();
        }

        [HttpPost]
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
                return RedirectToAction("Index", "Category");
            }
            ModelState.AddModelError("", result.Message);
            ViewBag.Categories = (await _categoryApiCilent.GetAll(GetLanguageId()));
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoryApiCilent.GetById(id, GetLanguageId());
            ViewBag.Categories = (await _categoryApiCilent.GetAll(GetLanguageId()));
            if (result.IsSuccessed)
            {
                var request = new CategoryUpdateRequest()
                {
                    Id = result.ResultObj.Id,
                    IsShowOnHome = result.ResultObj.IsShowOnHome,
                    LanguageId = result.ResultObj.LanguageId,
                    Name = result.ResultObj.Name,
                    ParentId = result.ResultObj.ParentId,
                    SeoAlias = result.ResultObj.SeoAlias,
                    SeoDescription = result.ResultObj.SeoDescription,
                    SeoTitle = result.ResultObj.SeoTitle,
                    SortOrder = result.ResultObj.SortOrder,
                    Status = result.ResultObj.Status
                };
                return View(request);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (request.LanguageId == null)
                request.LanguageId = GetLanguageId();
            var result = await _categoryApiCilent.Update(request);

            if (result.IsSuccessed)
            {
                TempData["Result"] = "Chỉnh sửa thành công";
                return RedirectToAction("Index", "Category");
            }
            ModelState.AddModelError("", result.Message);
            ViewBag.Categories = (await _categoryApiCilent.GetAll(GetLanguageId()));
            return View(request);
        }

        [HttpPost]
        public async Task<ApiResult<bool>> Delete(int id)
        {

            var result = await _categoryApiCilent.Delete(id);
            if (result.IsSuccessed)
            {
                TempData["Result"] = result.Message;
               
            }
            return result;
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _categoryApiCilent.GetById(id, GetLanguageId());

            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View();
        }
    }
}