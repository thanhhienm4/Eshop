using eShopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.Application;
using EshopSolution.Application.Cacalog.Products;
using EshopSolution.ViewModel.Catalog.Products;
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

        public ProductsController( IProductService productService)
        {
            _productService = productService;
        }

        

        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var product = await _productService.GetAllByCategoryId(languageId, request);
            return Ok(product);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
            {
                return BadRequest("Can't find product");
            }

            return Ok(product);
        }

        [HttpGet("{categoryId}/products/{languageId}")]
        public async Task<IActionResult> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            var product = await _productService.GetAllByCategoryId(languageId, request);
            if (product == null)
            {
                return BadRequest("Can't find product");
            }

            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
            {
                return BadRequest("Can't create product");
            }

            var product = _productService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> Delete([FromForm] int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccessful == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        //ProductImage

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var productImageId = await _productService.AddImages(productId, request);
            if (productImageId == 0)
            {
                return BadRequest("Can't add image to product");
            }

            //var product = _productService.GetById(productId, request.LanguageId);
            var image = _productService.GetImageById(productImageId);
            return CreatedAtAction(nameof(GetImageById), new { id = productImageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var affectedResult = await _productService.UpdateImages(imageId, request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage([FromForm] int imageId)
        {
            var affectedResult = await _productService.DeleteImages(imageId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
            {
                return BadRequest();
            }
            return Ok(image);
        }
       

    }
}