using EshopSolution.Application.Cacalog.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/{Controller}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //[HttpPost]
        private readonly IPublicProductService _publicProductService;
        public ProductController(IPublicProductService publicProductService)
        {
            _publicProductService = publicProductService;
        }
        public async Task<IActionResult> GetAsync()
        {
            var product =  await _publicProductService.GetAll();

            return Ok(product);
        }
    }
}
