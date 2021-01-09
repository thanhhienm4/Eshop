using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet("{filePath}")]
        public IActionResult Get(string filePath)
        {
            return PhysicalFile($"{FileStorageService.USER_CONTENT_FOLDER_NAME}/{filePath}", "image/jpeg");
        }
    }
}
