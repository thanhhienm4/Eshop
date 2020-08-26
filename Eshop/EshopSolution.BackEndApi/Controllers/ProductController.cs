using EshopSolution.Application.Cacalog.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.Application;
using eShopSolution.ViewModels.Catalog.ProductImages;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {

        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        //[HttpGet("{languageId}")]
        //public async Task<IActionResult> GetAll(string languageId)
        //{
        //    var product = await _publicProductService.GetAll(languageId);

        //    return Ok(product);
        //}

        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var product = await _publicProductService.GetAllByCategoryId(languageId, request);
            return Ok(product);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null)
            {
                return BadRequest("Can't find product");
            }

            return Ok(product);
        }
        [HttpGet("{categoryId}/{languageId}")]
        public async Task<IActionResult> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            var product = await _manageProductService.GetAllByCategoryId(languageId, request);
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
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest("Can't create product");
            }

            var product = _manageProductService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> Delete([FromForm] int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(productId, newPrice);
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
            var productImageId = await _manageProductService.AddImages(productId, request);
            if (productImageId == 0)
            {
                return BadRequest("Can't add image to product");
            }

            //var product = _manageProductService.GetById(productId, request.LanguageId);
            var image = _manageProductService.GetImageById(productImageId);
            return CreatedAtAction(nameof(GetImageById), new { id = productImageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId,[FromForm] ProductImageUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var affectedResult = await _manageProductService.UpdateImages(imageId, request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage([FromForm] int imageId)
        {
            var affectedResult = await _manageProductService.DeleteImages(imageId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _manageProductService.GetImageById(imageId);
            if (image == null)
            {
                return BadRequest();
            }
            return Ok(image);
        }

    }
}
