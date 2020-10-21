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
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetManageProductPagingRequest request)
        {
           return Ok( await _productService.GetAllPaging (languageId, request));
            
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var result= await _productService.GetById(productId, languageId);
            if (result.IsSuccessed==false)
            {
                return BadRequest("Can't find product");
            }

            return Ok(result);
        }

        [HttpGet("{categoryId}/products/{languageId}")]
        public async Task<IActionResult> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            var result = await _productService.GetAllByCategoryId(languageId, request);
            if (result.IsSuccessed==false)
            {
                return BadRequest("Can't find product");
            }

            return Ok(result);
        }

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

            var product = _productService.GetById(result.ResultObj, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = result.ResultObj }, product);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
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

        [HttpDelete("productId")]
        public async Task<IActionResult> Delete([FromForm] int productId)
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
            var result= await _productService.UpdatePrice(productId, newPrice);
            if (result.IsSuccessed=false)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //ProductImage

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
            var image = _productService.GetImageById(result.ResultObj);
            return CreatedAtAction(nameof(GetImageById), new { id = result.ResultObj }, image);
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
            var result= await _productService.GetImageById(imageId);
            if (result.IsSuccessed == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
       

    }
}