using EshopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.Application;
using EshopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{categoryId}/paging/")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging(int categoryId, [FromQuery] ProductPagingRequest request)
        {
            request.CategoryId = categoryId;
            return Ok(await _productService.GetAllPaging(request));
        }
        [AllowAnonymous]
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var result = await _productService.GetById(productId, languageId);
            if (result.IsSuccessed == false)
            {
                return BadRequest("Can't find product");
            }
            return Ok(result);
        }

        //[HttpGet("{categoryId}/products/{languageId}")]
        //public async Task<IActionResult> GetAllByCategoryId(string languageId, ProductPagingRequest request)
        //{
        //    var result = await _productService.GetAllByCategoryId(languageId, request);
        //    if (result.IsSuccessed == false)
        //    {
        //        return BadRequest("Can't find product");
        //    }
        //    return Ok(result);
        //}

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _productService.Create(request);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{productId}/update")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _productService.Update(request);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _productService.Delete(productId);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var result = await _productService.UpdatePrice(productId, newPrice);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _productService.AddImages(productId, request);
            if (result.IsSuccessed == false)
            {
                return BadRequest("Can't add image to product");
            }

            //var product = _productService.GetById(productId, request.LanguageId);
            return Ok(result);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _productService.UpdateImages(imageId, request);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage([FromForm] int imageId)
        {
            var result = await _productService.DeleteImages(imageId);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var result = await _productService.GetImageById(imageId);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{productId}/categories")]
        public async Task<IActionResult> CategoryAssign(int productId, [FromBody] CategoryAssignRequest request)
        {
            var result = await _productService.CategoryAssign(request);
            if (result.IsSuccessed == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("featured/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(string languageId, int take)
        {
            var result = await _productService.GetFeaturedProducts(languageId, take);
            if (result.IsSuccessed == false)
            {
                return BadRequest("Can't find product");
            }
            return Ok(result);
        }
        [HttpGet("latest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(string languageId, int take)
        {
            var result = await _productService.GetLatestProducts(languageId, take);
            if (result.IsSuccessed == false)
            {
                return BadRequest("Can't find product");
            }
            return Ok(result);
        }
        [HttpGet("detail/{languageId}/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDetailProduct(string languageId, int id)
        {
            var result = await _productService.GetProductDetail(languageId,id);
            if (result.IsSuccessed == false)
            {
                return BadRequest("Can't find product");

            }
            return Ok(result);
        }

    }
}