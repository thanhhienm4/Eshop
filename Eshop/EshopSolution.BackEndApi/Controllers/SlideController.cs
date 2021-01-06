using EshopSolution.Application.System.Role;
using EshopSolution.Application.Unilities.Slides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var slides = await _slideService.GetAll();
            return Ok(slides);
        }
    }
}