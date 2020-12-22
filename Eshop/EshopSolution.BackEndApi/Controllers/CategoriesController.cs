using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Application.Cacalog.Products;
using EshopSolution.ViewModel.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var data = await _categoryService.GetAll(languageId);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoryService.Delete(id);
            return Ok(data);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateRequest request)
        {
            var data = await _categoryService.Update(request);
            return Ok(data);
        }

        [HttpPost("crete")]
        public async Task<IActionResult> Create([FromForm]CategoryCreateRequest request)
        {
            var data = await _categoryService.Create(request);
            return Ok(data);
        }
    }
}
