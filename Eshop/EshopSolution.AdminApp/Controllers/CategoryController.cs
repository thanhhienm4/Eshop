using EshopSolution.AdminApp.Services;
using EshopSolution.ViewModel.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryApiClient _categoryApiCilent;

        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            _categoryApiCilent = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetManageCategoryPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = GetLanguageId(),
            };

            ViewBag.Keyword = keyword;

            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            var data = await _categoryApiCilent.GetCategoryPaging(request);
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
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
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoryApiCilent.GetById(id, GetLanguageId());
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
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            var category = await _categoryApiCilent.GetById(id, GetLanguageId());
            if (category != null)
            {
                return View(new CategoryDeleteRequest(id));
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _categoryApiCilent.Delete(request.Id);

            if (result.IsSuccessed)
            {
                TempData["Result"] = "Xóa thành công";
                return RedirectToAction("Index", "Category");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}