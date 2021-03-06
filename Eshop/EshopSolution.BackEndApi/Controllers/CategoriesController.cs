﻿using EshopSolution.Application.Cacalog.Products;
using EshopSolution.ViewModels.Catalog.Categories;
using EshopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageCategoryPagingRequest request)
        {
            var data = await _categoryService.GetAllPaging(request);
            return Ok(data);
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var data = await _categoryService.GetAll(languageId);
            return Ok(data);
        }

        [HttpGet("GetById/{id}/{languageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var data = await _categoryService.GetById(id, languageId);
            if (data != null)
            {
                return Ok(new ApiSuccessResult<CategoryViewModel>(data));
            }
            else
                return Ok(new ApiErrorResult<CategoryViewModel>("Không tìm thấy"));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Edit")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoryService.Delete(id);
            return Ok(data);
        }

        [HttpPut("update")]
        [Authorize(Policy = "Edit")]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateRequest request)
        {
            var data = await _categoryService.Update(request);
            return Ok(data);
        }

        [HttpPost("create")]
        [Authorize(Policy = "Edit")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateRequest request)
        {
            var data = await _categoryService.Create(request);
            return Ok(data);
        }
    }
}